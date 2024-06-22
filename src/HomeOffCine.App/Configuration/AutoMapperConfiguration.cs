using AutoMapper;
using HomeOffCine.App.ViewModels;
using HomeOffCine.Business.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace HomeOffCine.App.Configuration;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<Rating, RatingViewModel>().ReverseMap();
        CreateMap<Movie, MovieViewModel>()
            .ForMember(o => o.Ratings, m => m.MapFrom(x => x.Rating))
            .ReverseMap();
    }
}
