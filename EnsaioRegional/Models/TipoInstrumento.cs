using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EnsaioRegional.Models
{
    public class TipoInstrumento
    {
        [Key]
        public int IdTipoInstrumento { get; set; }

        [Required(ErrorMessage = "A descrição do tipo é obrigatório (cordas/metais/madeiras)", AllowEmptyStrings = false)]
        [DisplayName("Família do instrumento")]
        public string Descricao { get; set; }


    }
}
