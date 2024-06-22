using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HomeOffCine.App.ViewModels;

public class RatingViewModel
{
    [Key]
    public Guid Id { get; set; }

    public Guid MovieId { get; set; }

    public Guid UserId { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [DisplayName("Cometario")]
    public string Description { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Range(0, 10)]
    [DisplayName("Avaliação")]
    public long Assessments { get; set; }

    [DisplayName("Data da avaliação")]
    public DateTime RatingDate { get; set; }
}
