using HomeOffCine.Business.Models;

namespace HomeOffCine.Tests.TesteDeUnidade.Fixtures;

[CollectionDefinition(nameof(MovieCollection))]
public class MovieCollection : ICollectionFixture<MovieTestsFixture>
{ }

public class MovieTestsFixture : IDisposable
{
    public Movie GenerateValidMovie()
    {
        return new Movie(
            name: "Interestelar",
            description: "As reservas naturais da Terra estão chegando ao fim e um grupo de astronautas recebe a missão de verificar possíveis planetas para receberem a população mundial, possibilitando a continuação da espécie.",
            gender: "Ficção cientifica",
            imdb: 10,
            releaseDate: DateTime.Now,
            image: "teste",
            imageBanner: "teste",
            urlTrailer: "teste"
        );
    }

    public Movie GenerateInvalidMovie()
    {
        return new Movie(
            name: null,
            description: "null",
            gender: "",
            imdb: -1,
            releaseDate: DateTime.Now.AddDays(1),
            image: null,
            imageBanner: null,
            urlTrailer: null
        );
    }

    public void Dispose()
    {
    }
}
