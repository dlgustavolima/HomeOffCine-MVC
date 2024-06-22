using HomeOffCine.App.Data;
using HomeOffCine.Infra.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace HomeOffCine.App.Configuration
{
    public static class EnsureCreatedConfiguration
    {
        public static WebApplication UseEnsureCreatedConfig(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var dbIdentity = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var dbHomeOffCine = scope.ServiceProvider.GetRequiredService<HomeOffCineDbContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                if (dbIdentity.Database.EnsureCreated())
                {
                    var user = new Microsoft.AspNetCore.Identity.IdentityUser
                    {
                        UserName = "teste@teste.com.br",
                        NormalizedUserName = "teste@teste.com.br",
                        Email = "teste@teste.com.br",
                        NormalizedEmail = "teste@teste.com.br",
                        EmailConfirmed = true,
                        PhoneNumber = null,
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnd = null,
                        LockoutEnabled = true,
                        AccessFailedCount = 0
                    };

                    userManager.AddPasswordAsync(user, "Teste@123").Wait();
                    userManager.CreateAsync(user).Wait();

                    user = dbIdentity.Users.FirstOrDefault();

                    if (user != null)
                    {
                        dbIdentity.UserClaims.Add(new Microsoft.AspNetCore.Identity.IdentityUserClaim<string>
                        {
                            UserId = user.Id,
                            ClaimType = "Filme",
                            ClaimValue = "Adm"
                        });
                    }

                    dbIdentity.SaveChanges();
                    dbIdentity.ChangeTracker.Clear();

                    var dataBaseCreator = dbHomeOffCine.GetService<IRelationalDatabaseCreator>();
                    dataBaseCreator.CreateTables();

                    dbHomeOffCine.Movies.AddRange(
                        new Business.Models.Movie(
                            name: "It a coisa",
                            description: "Quando crianças começam a desaparecer misteriosamente na pequena cidade de Derry...",
                            gender: "Terror",
                            imdb: 10,
                            releaseDate: DateTime.Now.AddDays(-10),
                            image: "414735f0-ff9a-4d21-b8cb-cf6ad6cf831b_IT.png",
                            imageBanner: "4e2a1443-e57b-4379-a2fa-4976ec79eb4a_destaque-it.jpg",
                            urlTrailer: "https://www.youtube.com/embed/dD264ZjfKlk?si=QV3dy1ZRvYCv32p_"
                            ),
                            new Business.Models.Movie(
                            name: "Duna: Parte Dois",
                            description: "Diante da difícil escolha entre o amor de sua vida e o destino do universo conhecido...",
                            gender: "Ficcao",
                            imdb: 10,
                            releaseDate: DateTime.Now.AddDays(-10),
                            image: "b19e061b-d967-4769-b33c-a5a9b18b3d80_Duna.jpg",
                            imageBanner: "4db4e45b-f256-4e11-bec4-45f185b2cdee_Duna 2 capa.jpg",
                            urlTrailer: "https://www.youtube.com/embed/QqmbrvluQRA?si=2SzJ9mKFtIKBWzEi"
                            ),
                            new Business.Models.Movie(
                            name: "Oppenheimer",
                            description: "A história do físico americano J. Robert Oppenheimer...",
                            gender: "Drama",
                            imdb: 10,
                            releaseDate: DateTime.Now.AddDays(-10),
                            image: "2c0c3a95-b213-4648-bd2f-c3ea5d9ce746_Oppenheimer.jpg",
                            imageBanner: "9dbc5665-8878-43e9-a8df-686381ebf6e7_Oppenheimer capa.jpg",
                            urlTrailer: "https://www.youtube.com/embed/F3OxA9Cz17A?si=LhN0vrSyJuLtIIpF"
                            ),
                            new Business.Models.Movie(
                            name: "Godzilla e Kong: o novo império",
                            description: "Godzilla e o todo-poderoso Kong enfrentam uma ameaça colossal escondida nas profundezas do planeta...",
                            gender: "Aventura",
                            imdb: 10,
                            releaseDate: DateTime.Now.AddDays(-10),
                            image: "b45af3d2-7a87-4c9c-86ae-a174ea9bf315_GodzillaEKong.webp",
                            imageBanner: "924e7548-02fd-4e7c-a9de-aa8976015863_godzillaEKongCapa.webp",
                            urlTrailer: "https://www.youtube.com/embed/LOIMD084NlE?si=IYYTzhzMdXR42wfD"
                            ),
                            new Business.Models.Movie(
                            name: "Como eu era antes de você",
                            description: "Louisa Clark não tem muitas ambições...",
                            gender: "Romance",
                            imdb: 10,
                            releaseDate: DateTime.Now.AddDays(-10),
                            image: "d12473ec-8e68-4bdc-b787-2a28be8cce94_ea1b6edf-f204-4910-b798-bfb7d11fc67e_Me before you.jpg",
                            imageBanner: "c3eee2c4-ed67-4e85-b32c-e115bb5d6488_como eu era antes de voce capa.webp",
                            urlTrailer: "https://www.youtube.com/embed/PnqUs3xiAVI?si=kvXm-1uFQxNgkqXe"
                            ),
                            new Business.Models.Movie(
                            name: "Kung Fu Panda 4",
                            description: "Após ser escolhido para se tornar o Líder Espiritual do Vale da Paz...",
                            gender: "Aventura",
                            imdb: 10,
                            releaseDate: DateTime.Now.AddDays(-10),
                            image: "57f9a7c3-2a21-4422-9791-66fb234cdde5_Kung fu panda 4.jpg",
                            imageBanner: "373ab8c8-a45d-4a55-b7ee-05c94b448387_Kung fu panda 4 capa.jpg",
                            urlTrailer: "https://www.youtube.com/embed/hI1jyNTMBFI?si=cVb1fa0EGewIKaOO"
                            ),
                            new Business.Models.Movie(
                            name: "O Dublê",
                            description: "Após um acidente que quase acabou com sua carreira...",
                            gender: "Acao",
                            imdb: 10,
                            releaseDate: DateTime.Now.AddDays(-10),
                            image: "92b90e30-9575-4e3e-894a-050bb7ea4bc6_O duble.jpg",
                            imageBanner: "2056ef5c-23cb-46e5-b2cb-75d39a898473_O duble capa.jpg",
                            urlTrailer: "https://www.youtube.com/embed/3ArnMu7JKyU?si=Dpevw-tfZHdo7JLR"
                            )
                        );

                    dbHomeOffCine.SaveChanges();
                    dbHomeOffCine.ChangeTracker.Clear();
                }
            }

            return app;
        }
    }
}
