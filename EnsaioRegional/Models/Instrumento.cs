using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnsaioRegional.Models
{
    public class Instrumento
    {
        [Key]
        public int IdInstrumento { get; set; }

        [Required(ErrorMessage = "O nome do instrumento é obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Instrumento")]
        public string NomeInstrumento { get; set; }

        [ForeignKey("TipoInstrumento")]
        [Required]
        [DisplayName("Tipo Instrumento")]
        public int IdTipoInstrumento { get; set; }

        public TipoInstrumento TipoInstrumento { get; set; }

    }
}
