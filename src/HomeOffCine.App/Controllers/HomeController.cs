using AutoMapper;
using HomeOffCine.App.ViewModels;
using HomeOffCine.Business.Interfaces;
using HomeOffCine.Business.Interfaces.Service;
using HomeOffCine.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace HomeOffCine.App.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IMovieService _movieService;
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;

        public HomeController(
            IMovieService movieService,
            ILogger<HomeController> logger,
            IMapper mapper,
            INotificator notificator,
            IIdentityUser user) : base(notificator, user)
        {
            _movieService = movieService;
            _mapper = mapper;
            _logger = logger;
            
        }

        [Route("Index")]
        [Route("")]
        public async Task<IActionResult> Index([FromQuery] int ps = 6, [FromQuery] int page = 1, [FromQuery] string q = null, [FromQuery] string g = null)
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
            movieViewModel.ReferenceAction = "Index";

            ViewBag.Pesquisa = q;
            return View(movieViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Errors(int id)
        {
            var modelErro = new ErrorViewModel();

            if (id == 500)
            {
                modelErro.Mensagem = "Ocorreu um erro! Tente novamente mais tarde ou contate nosso suporte.";
                modelErro.Titulo = "Ocorreu um erro!";
                modelErro.ErroCode = id;
            }
            else if (id == 404)
            {
                modelErro.Mensagem = "A página que está procurando não existe! <br />Em caso de dúvidas entre em contato com nosso suporte";
                modelErro.Titulo = "Ops! Página não encontrada.";
                modelErro.ErroCode = id;
            }
            else if (id == 403)
            {
                modelErro.Mensagem = "Você não tem permissão para fazer isto.";
                modelErro.Titulo = "Acesso Negado";
                modelErro.ErroCode = id;
            }
            else
            {
                return StatusCode(500);
            }

            return View("Error", modelErro);
        }
    }
}
