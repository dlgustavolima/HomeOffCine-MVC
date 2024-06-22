using AutoMapper;
using HomeOffCine.App.ViewModels;
using HomeOffCine.Business.Interfaces;
using HomeOffCine.Business.Interfaces.Service;
using HomeOffCine.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeOffCine.App.Controllers
{
    [Route("[controller]")]
    public class RatingController : BaseController
    {
        private readonly IRatingService _ratingService;
        private readonly ILogger<RatingController> _logger;
        private readonly IMapper _mapper;

        public RatingController(IRatingService ratingService,
                                ILogger<RatingController> logger,
                                IMapper mapper,
                                INotificator notificator,
                                IIdentityUser user) : base(notificator, user)
        {
            _ratingService = ratingService;
            _logger = logger;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [Route("adicionar-avaliacao")]
        [HttpGet]
        public IActionResult AddRating(Guid movieId)
        {
            ViewBag.MovieId = movieId;
            return View();
        }

        [Authorize]
        [Route("adicionar-avaliacao")]
        [HttpPost]
        public async Task<IActionResult> AddRating(RatingViewModel ratingViewModel)
        {
            if (!ModelState.IsValid) return RedirectToAction("WatchMovie", "Movie", new { id = ratingViewModel.MovieId });

            var rating = new Rating(ratingViewModel.Description, ratingViewModel.Assessments, DateTime.Now, ratingViewModel.MovieId, UserId);
            await _ratingService.AddRating(rating);

            return RedirectToAction("WatchMovie", "Movie", new { id = ratingViewModel.MovieId });
        }

        [Authorize]
        [Route("atualizar-avaliacao")]
        [HttpGet]
        public async Task<IActionResult> UpdateRating(Guid ratingId)
        {
            var ratingViewModel = _mapper.Map(await _ratingService.GetRatingById(ratingId), new RatingViewModel());

            ViewBag.Id = ratingId;
            ViewBag.MovieId = ratingViewModel.MovieId;
            ViewBag.UserId = ratingViewModel.UserId;
            return View(ratingViewModel);
        }

        [Authorize]
        [Route("atualizar-avaliacao")]
        [HttpPost]
        public async Task<IActionResult> UpdateRating(RatingViewModel ratingViewModel, Guid movieId)
        {
            var rating = await _ratingService.GetRatingByIdNoTracking(ratingViewModel.Id);

            if (UserId != rating.UserId)
                RedirectToAction("Error", new ErrorViewModel { Mensagem = "Não é permitido atualizar o comentario de outro usuario" });

            var ratingUpdate = new Rating(ratingViewModel.Description, ratingViewModel.Assessments, rating.RatingDate, movieId, UserId);
            ratingUpdate.Id = ratingViewModel.Id;
            await _ratingService.UpdateRating(ratingUpdate);
            return RedirectToAction("WatchMovie", "Movie", new { id = movieId });
        }

        [Authorize]
        [Route("remover-avaliacao")]
        [HttpGet]
        public async Task<IActionResult> DeleteRating(Guid ratingId)
        {
            var ratingViewModel = _mapper.Map(await _ratingService.GetRatingById(ratingId), new RatingViewModel());

            ViewBag.Id = ratingId;
            ViewBag.MovieId = ratingViewModel.MovieId;
            ViewBag.UserId = ratingViewModel.UserId;
            return View(ratingViewModel);
        }

        [Authorize]
        [Route("remover-avaliacao")]
        [HttpPost]
        public async Task<IActionResult> ConfirmDeleteRating(Guid id, Guid movieId)
        {
            await _ratingService.DeleteRating(id);
            return RedirectToAction("WatchMovie", "Movie", new { id = movieId });
        }
    }
}
