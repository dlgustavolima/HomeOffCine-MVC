using AutoMapper;
using HomeOffCine.App.ViewModels;
using HomeOffCine.Business.Interfaces;
using HomeOffCine.Business.Interfaces.Service;
using HomeOffCine.Business.Models;
using HomeOffCine.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static HomeOffCine.App.Extensions.IdentityUser.CustomAuthorization;

namespace HomeOffCine.App.Controllers;

[Route("[controller]")]
public class MovieController : BaseController
{
    private readonly IMovieService _movieService;
    private readonly IRatingService _ratingService;
    private readonly ILogger<HomeController> _logger;
    private readonly IMapper _mapper;


    public MovieController(IMovieService movieService,
                           IRatingService ratingService,
                           ILogger<HomeController> logger,
                           IMapper mapper,
                           INotificator notificator,
                           IIdentityUser user) : base(notificator, user)
    {
        _movieService = movieService;
        _ratingService = ratingService;
        _mapper = mapper;
        _logger = logger;
    }

    [Route("AdministratorMovies")]
    [ClaimsAuthorize("Filme", "Adm")]
    public async Task<IActionResult> AdministratorMovies([FromQuery] int ps = 8, [FromQuery] int page = 1, [FromQuery] string q = null, [FromQuery] string g = null)
    {
        var movies = await _movieService.GetMoviesPagination(ps, page, q, g);
        var movieViewModel = new PagedViewModel<MovieViewModel>();

        foreach (var movie in movies.List)
        {
            movieViewModel.List.Add(_mapper.Map(movie, new MovieViewModel()));
        }

        movieViewModel.TotalResults = movies.TotalResults;
        movieViewModel.PageSize = ps;
        movieViewModel.PageIndex = page;
        movieViewModel.Query = q;
        movieViewModel.ReferenceAction = "AdministratorMovies";

        ViewBag.Pesquisa = q;
        return View(movieViewModel);
    }


    [Route("lista-de-filmes")]

    public async Task<IActionResult> Index([FromQuery] int ps = 8, [FromQuery] int page = 1, [FromQuery] string q = null, [FromQuery] string g = null)
    {
        var movies = await _movieService.GetMoviesPagination(ps, page, q, g);
        var movieViewModel = new PagedViewModel<MovieViewModel>();

        foreach (var movie in movies.List)
        {
            movieViewModel.List.Add(_mapper.Map(movie, new MovieViewModel()));
        }

        movieViewModel.TotalResults = movies.TotalResults;
        movieViewModel.PageSize = ps;
        movieViewModel.PageIndex = page;
        movieViewModel.Query = q;
        movieViewModel.ReferenceAction = "lista-de-filmes";

        ViewBag.Pesquisa = q;
        return View(movieViewModel);
    }

    [Route("detalhe-filme")]
    public async Task<IActionResult> Detail(Guid id)
    {
        return View("MovieDetail", _mapper.Map(await _movieService.GetMovieById(id), new MovieViewModel()));
    }

    [Route("assistir-filme")]
    public async Task<IActionResult> WatchMovie(Guid id)
    {
        return View(_mapper.Map(await _movieService.GetMovieById(id), new MovieViewModel()));
    }

    [ClaimsAuthorize("Filme", "Adm")]
    [Route("adicionar-filme")]
    [HttpGet]
    public IActionResult AddMovie()
    {
        return View();
    }

    [ClaimsAuthorize("Filme", "Adm")]
    [Route("adicionar-filme")]
    [HttpPost]
    public async Task<IActionResult> AddMovie(MovieViewModel movieViewModel)
    {
        var imgPrefixo = Guid.NewGuid() + "_";
        var imgBannerPrefixo = Guid.NewGuid() + "_";
        if (!await UploadFile(movieViewModel.ImagemUpload, imgPrefixo))
        {
            return View(movieViewModel);
        }

        movieViewModel.Image = imgPrefixo + movieViewModel.ImagemUpload.FileName;

        if (!await UploadFile(movieViewModel.ImageBannerUpload, imgBannerPrefixo))
        {
            return View(movieViewModel);
        }

        movieViewModel.ImageBanner = imgBannerPrefixo + movieViewModel.ImageBannerUpload.FileName;

        var movie = new Movie(movieViewModel.Name, movieViewModel.Description, movieViewModel.Gender, movieViewModel.Imdb, movieViewModel.ReleaseDate, movieViewModel.Image, movieViewModel.ImageBanner, movieViewModel.UrlTrailer);
        await _movieService.AddMovie(movie);

        return RedirectToAction("Index", controllerName: "Home");
    }

    [ClaimsAuthorize("Filme", "Adm")]
    [Route("atualizar-filme")]
    [HttpGet]
    public async Task<IActionResult> EditMovie(Guid id)
    {
        return View(_mapper.Map(await _movieService.GetMovieById(id), new MovieViewModel()));
    }

    [ClaimsAuthorize("Filme", "Adm")]
    [Route("atualizar-filme")]
    [HttpPost]
    public async Task<IActionResult> EditMovie(MovieViewModel movieViewModel)
    {
        var movie = await _movieService.GetMovieById(movieViewModel.Id);

        if (movieViewModel.ImagemUpload != null)
        {
            var imgPrefixo = Guid.NewGuid() + "_";
            if (!await UploadFile(movieViewModel.ImagemUpload, imgPrefixo))
            {
                return View(movieViewModel);
            }
            DeleteFile(movie.Image);
            movieViewModel.Image = imgPrefixo + movieViewModel.ImagemUpload.FileName;
            movieViewModel.Image = movieViewModel.Image;
        }

        if (movieViewModel.ImageBannerUpload != null)
        {
            var imgBannerPrefixo = Guid.NewGuid() + "_";
            if (!await UploadFile(movieViewModel.ImageBannerUpload, imgBannerPrefixo))
            {
                return View(movieViewModel);
            }
            DeleteFile(movie.ImageBanner);
            movieViewModel.Image = imgBannerPrefixo + movieViewModel.ImageBannerUpload.FileName;
            movieViewModel.Image = movieViewModel.Image;
        }

        movie.UpdateMovie(movieViewModel.Name, movieViewModel.Description, movieViewModel.Gender, movieViewModel.Imdb, movieViewModel.ReleaseDate, movieViewModel.Image ?? movie.Image, movieViewModel.ImageBanner ?? movie.ImageBanner, movieViewModel.UrlTrailer);
        await _movieService.UpdateMovie(movie);
        return RedirectToAction("AdministratorMovies");
    }

    [ClaimsAuthorize("Filme", "Adm")]
    [Route("deletar-filme")]
    [HttpGet]
    public async Task<IActionResult> DeleteMovie(Guid id)
    {
        return View(_mapper.Map(await _movieService.GetMovieById(id), new MovieViewModel()));
    }

    [ClaimsAuthorize("Filme", "Adm")]
    [Route("deletar-filme")]
    [HttpPost]
    public async Task<IActionResult> ConfirmDelete(Guid id)
    {
        var movie = await _movieService.GetMovieById(id);
        DeleteFile(movie.Image);
        await _movieService.DeleteMovie(id);
        return RedirectToAction("Index");
    }

    private async Task<bool> UploadFile(IFormFile arquivo, string imgPrefixo)
    {
        if (arquivo.Length <= 0) return false;

        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imgPrefixo + arquivo.FileName);

        if (System.IO.File.Exists(path))
        {
            ModelState.AddModelError(string.Empty, "Já existe um arquivo com este nome!");
            return false;
        }

        using (var stream = new FileStream(path, FileMode.Create))
        {
            await arquivo.CopyToAsync(stream);
        }

        return true;
    }

    private void DeleteFile(string imageName)
    {
        if (string.IsNullOrEmpty(imageName)) return;

        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imageName);

        if (System.IO.File.Exists(path))
        {
            System.IO.File.Delete(path);
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
