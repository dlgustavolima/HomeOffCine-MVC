using HomeOffCine.Business.Models;

namespace HomeOffCine.Tests.TesteDeUnidade.Fixtures;

[CollectionDefinition(nameof(RatingCollection))]
public class RatingCollection : ICollectionFixture<RatingTestsFixture>
{ }

public class RatingTestsFixture : IDisposable
{
    public Rating GenerateValidRating()
    {
        return new Rating(
                description: "Esse filme é muito bom",
                assessments: 10,
                ratingDate: DateTime.Now,
                Guid.NewGuid(),
                Guid.NewGuid()
            );
    }

    public Rating GenerateInvalidRating()
    {
        return new Rating(
            description: null,
            assessments: -1,
            ratingDate: DateTime.Now.AddDays(1),
            Guid.NewGuid(),
            Guid.NewGuid()
        );
    }

    public void Dispose()
    {
    }
}