using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomeOffCine.App.ViewModels;

public class MovieViewModel
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [DisplayName("Nome do filme")]
    public string Name { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [DisplayName("Descrição do filme")]
    public string Description { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [DisplayName("Genero do filme")]
    public string Gender { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [DisplayName("Imdb")]
    public long Imdb { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [DisplayName("Data de lançamento")]
    public DateTime ReleaseDate { get; set; }

    [DisplayName("Imagem do filme")]
    public IFormFile ImagemUpload { get; set; }

    public string Image { get; set; }

    [DisplayName("Media da avaliação dos usuarios")]
    public decimal MediaRating { get; set; }

    public string UrlTrailer { get; set; }

    public string ImageBanner { get; set; }

    [DisplayName("Imagem do filme")]
    public IFormFile ImageBannerUpload { get; set; }

    public List<RatingViewModel> Ratings { get; set; } = new List<RatingViewModel>();

}
