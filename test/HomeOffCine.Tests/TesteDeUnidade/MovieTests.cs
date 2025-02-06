using HomeOffCine.Tests.TesteDeUnidade.Fixtures;
using FluentAssertions;
using HomeOffCine.Business.Models;
using Moq.AutoMock;
using HomeOffCine.Business.Services;
using HomeOffCine.Business.Interfaces.Repository;
using Moq;

namespace HomeOffCine.Tests.TesteDeUnidade;

[Collection(nameof(MovieCollection))]
public class MovieTests
{
    private readonly MovieTestsFixture _movieTestsFixture;
    private readonly AutoMocker _mocker;
    private readonly MovieService _movieService;

    public MovieTests(MovieTestsFixture movieTestsFixture)
    {
        _mocker = new AutoMocker();
        _movieService = _mocker.CreateInstance<MovieService>();

        _movieTestsFixture = movieTestsFixture;
    }

    [Fact(DisplayName = "Novo filme valido")]
    [Trait("Categoria", "HomeOffCine - Movie")]
    public void Movie_NewMovie_HasBeValid()
    {
        // Arrange
        var movie = _movieTestsFixture.GenerateValidMovie();

        // Act
        var result = movie.Validate();

        // Assert 
        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();
    }

    [Fact(DisplayName = "Novo filme invalido")]
    [Trait("Categoria", "HomeOffCine - Movie")]
    public void Movie_NewMovie_HasBeInvalid()
    {
        // Arrange
        var movie = _movieTestsFixture.GenerateInvalidMovie();

        // Act
        var result = movie.Validate();

        // Assert 
        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCountGreaterThanOrEqualTo(1);
        result.Errors
            .First()
            .ErrorMessage
            .Should()
            .Be(MovieValidator.NameErrorMessage);
    }

    [Fact(DisplayName = "Adicionando novo filme")]
    [Trait("Categoria", "HomeOffCine - Movie")]
    public void Movie_AddMovie_MustExecuteSucessfully()
    {
        // Arrange
        var movie = _movieTestsFixture.GenerateValidMovie();

        // Act
        var result = _movieService.AddMovie(movie);

        // Assert 
        movie.Validate().IsValid.Should().BeTrue();
        _mocker.GetMock<IMovieRepository>().Verify(r => r.Add(It.IsAny<Movie>()), Times.Once());
    }

    [Fact(DisplayName = "Adicionando novo filme invalido")]
    [Trait("Categoria", "HomeOffCine - Movie")]
    public void Movie_AddMovie_MustExecuteErrorBecauseValidation()
    {
        // Arrange
        var movie = _movieTestsFixture.GenerateInvalidMovie();

        // Act
        var result = _movieService.AddMovie(movie);

        // Assert 
        movie.Validate().IsValid.Should().BeFalse();
        _mocker.GetMock<IMovieRepository>().Verify(r => r.Add(It.IsAny<Movie>()), Times.Never());
    }

    [Fact(DisplayName = "Atualizando filme")]
    [Trait("Categoria", "HomeOffCine - Movie")]
    public void Movie_UpdateMovie_MustExecuteSucessfully()
    {
        // Arrange
        var movie = _movieTestsFixture.GenerateValidMovie();
        movie.UpdateMovie("It a coisa", movie.Description, "Terror", movie.Imdb, movie.ReleaseDate, movie.Image, movie.ImageBanner, movie.UrlTrailer);

        // Act
        var result = _movieService.UpdateMovie(movie);

        // Assert 
        movie.Validate().IsValid.Should().BeTrue();
        movie.Name.Should().Be("It a coisa");
        movie.Gender.Should().Be("Terror");
        _mocker.GetMock<IMovieRepository>().Verify(r => r.Update(It.IsAny<Movie>()), Times.Once());
    }

    [Fact(DisplayName = "Atualizar filme")]
    [Trait("Categoria", "HomeOffCine - Movie")]
    public void Movie_UpdateMovie_AfterUpdateNameMustBeSame()
    {
        // Arrange
        var movie = _movieTestsFixture.GenerateValidMovie();

        // Act 
        movie.UpdateMovie("It a coisa", movie.Description, "Terror", movie.Imdb, movie.ReleaseDate, movie.Image, movie.ImageBanner, movie.UrlTrailer);

        // Assert
        movie.Name.Should().Be("It a coisa");
        movie.Gender.Should().Be("Terror");
    }

    [Fact(DisplayName = "Deletar filme")]
    [Trait("Categoria", "HomeOffCine - Movie")]
    public void Movie_DeleteMovie_MustExecuteSucessfully()
    {
        // Arrange
        var movie = _movieTestsFixture.GenerateValidMovie();

        // Act
        var result = _movieService.DeleteMovie(movie.Id);

        // Assert
        _mocker.GetMock<IMovieRepository>().Verify(r => r.Remove(It.IsAny<Movie>()), Times.Once());
    }

}