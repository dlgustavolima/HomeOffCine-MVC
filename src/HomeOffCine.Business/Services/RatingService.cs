using HomeOffCine.Business.Interfaces;
using HomeOffCine.Business.Interfaces.Repository;
using HomeOffCine.Business.Interfaces.Service;
using HomeOffCine.Business.Models;

namespace HomeOffCine.Business.Services;

public class RatingService : BaseService, IRatingService
{
    private readonly IRatingRepository _ratingRepository;

    public RatingService(IRatingRepository ratingRepository,
                         INotificator notificator) : base(notificator)
    {
        _ratingRepository = ratingRepository;
    }

    public async Task<Rating> GetRatingById(Guid id)
    {
        return await _ratingRepository.GetByIdAsync(id);
    }

    public async Task<Rating> GetRatingByIdNoTracking(Guid id)
    {
        return await _ratingRepository.GetRatingByIdNoTracking(id);
    }

    public async Task<List<Rating>> GetRatingsByMovieId(Guid movieId)
    {
        return await _ratingRepository.GetRatingsByMovieId(movieId);
    }

    public async Task AddRating(Rating rating)
    {
        var validate = rating.Validate();
        if (!validate.IsValid)
        {
            Notificar(validate);
            return;
        }

        _ratingRepository.Add(rating);
        await _ratingRepository.SaveChanges();
    }

    public async Task UpdateRating(Rating rating)
    {
        var validate = rating.Validate();
        if (!validate.IsValid)
        {
            Notificar(validate);
            return;
        }

        _ratingRepository.Update(rating);
        await _ratingRepository.SaveChanges();
    }

    public async Task DeleteRating(Guid id)
    {
        var rating = await _ratingRepository.GetByIdAsync(id);
        _ratingRepository.Remove(rating);
        await _ratingRepository.SaveChanges();
    }

}
