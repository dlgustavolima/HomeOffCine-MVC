using HomeOffCine.Business.Interfaces.Repository;
using HomeOffCine.Business.Interfaces.Service;
using HomeOffCine.Business.Interfaces;
using HomeOffCine.Business.Notifications;
using HomeOffCine.Business.Services;
using HomeOffCine.Infra.Repository;
using HomeOffCine.App.Extensions.IdentityUser;
using AutoMapper;

namespace HomeOffCine.App.Configuration;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        services.AddScoped<IIdentityUser, IdentityUser>();

        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<IRatingRepository, RatingRepository>();

        services.AddScoped<INotificator, Notificator>();
        services.AddScoped<IMovieService, MovieService>();
        services.AddScoped<IRatingService, RatingService>();

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}
