using FluentAssertions;
using HomeOffCine.Business.Interfaces.Repository;
using HomeOffCine.Business.Interfaces.Service;
using HomeOffCine.Business.Models;
using HomeOffCine.Business.Services;
using HomeOffCine.Tests.TesteDeUnidade.Fixtures;
using Moq;
using Moq.AutoMock;

namespace HomeOffCine.Tests.TesteDeUnidade;

[Collection(nameof(RatingCollection))]
public class RatingTests
{
    private readonly RatingTestsFixture _ratingTestsFixture;
    private readonly AutoMocker _mocker;
    private readonly RatingService _ratingService;

    public RatingTests(RatingTestsFixture ratingTestsFixture)
    {
        _mocker = new AutoMocker();
        _ratingService = _mocker.CreateInstance<RatingService>();

        _ratingTestsFixture = ratingTestsFixture;
    }

    [Fact(DisplayName = "Nova avaliação valida")]
    [Trait("Categoria", "HomeOffCine - Rating")]
    public void Rating_NewRating_HasBeValid()
    {
        // Arrange
        var rating = _ratingTestsFixture.GenerateValidRating();

        // Act
        var result = rating.Validate();

        // Assert 
        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();
    }

    [Fact(DisplayName = "Nova avaliação invalida")]
    [Trait("Categoria", "HomeOffCine - Rating")]
    public void Rating_NewRating_HasBeInvalid()
    {
        // Arrange
        var movie = _ratingTestsFixture.GenerateInvalidRating();

        // Act
        var result = movie.Validate();

        // Assert 
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCountGreaterThanOrEqualTo(1);
        result.Errors
            .First()
            .ErrorMessage
            .Should()
            .Be(RatingValidator.DescriptionErrorMessage);
    }

    [Fact(DisplayName = "Adicionando avaliação valida")]
    [Trait("Categoria", "HomeOffCine - Rating")]
    public void Rating_AddRating_MustExecuteSucessfully()
    {
        // Arrange
        var rating = _ratingTestsFixture.GenerateValidRating();

        // Act
        var result = _ratingService.AddRating(rating);

        // Assert 
        rating.Validate().IsValid.Should().BeTrue();
        _mocker.GetMock<IRatingRepository>().Verify(r => r.Add(It.IsAny<Rating>()), Times.Once());
    }

    [Fact(DisplayName = "Adicionando avaliação invalida")]
    [Trait("Categoria", "HomeOffCine - Rating")]
    public void Rating_AddRating_MustExecuteErrorBecauseValidation()
    {
        // Arrange
        var rating = _ratingTestsFixture.GenerateInvalidRating();

        // Act
        var result = _ratingService.AddRating(rating);

        // Assert 
        rating.Validate().IsValid.Should().BeFalse();
        _mocker.GetMock<IRatingRepository>().Verify(r => r.Add(It.IsAny<Rating>()), Times.Never());
    }

    [Fact(DisplayName = "Atualizando avaliação")]
    [Trait("Categoria", "HomeOffCine - Rating")]
    public void Rating_UpdateRating_MustExecuteSucessfully()
    {
        // Arrange
        var rating = _ratingTestsFixture.GenerateValidRating();

        // Act
        var result = _ratingService.UpdateRating(rating);

        // Assert 
        rating.Validate().IsValid.Should().BeTrue();
        _mocker.GetMock<IRatingRepository>().Verify(r => r.Update(It.IsAny<Rating>()), Times.Once());
    }

    [Fact(DisplayName = "Removendo avaliação")]
    [Trait("Categoria", "HomeOffCine - Movie")]
    public void Movie_RemoveRating_MustExecuteSucessfully()
    {
        // Arrange
        var rating = _ratingTestsFixture.GenerateValidRating();

        // Act 
        var result = _ratingService.DeleteRating(rating.Id);

        // Assert
        _mocker.GetMock<IRatingRepository>().Verify(r => r.Remove(It.IsAny<Rating>()), Times.Once());
    }

}