using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnsaioRegional.Models
{
    public class Musico
    {
        [Key]
        public int IdMusico { get; set; }

        [Required(ErrorMessage = "O nome do músico é obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Nome")]
        public string NomeMusico { get; set; }

        [Required(ErrorMessage = "O tipo de músico é obrigatório (musico/organista)", AllowEmptyStrings = false)]
        [DisplayName("Músico/Organista")]
        public int IdTipoMusico { get; set; } //Músico ou Organista

        [Required(ErrorMessage = "O tipo de formação é obrigatório (Oficializado: sim/não)", AllowEmptyStrings = false)]
        [DisplayName("Oficializado (sim/não")]
        public bool IdTipoFormacao { get; set; } //Oficializado ou não

        [ForeignKey("Instrumento")]
        [Required]
        [DisplayName("Instrumento Musical")]
        public int IdInstrumento { get; set; }

        public Instrumento Instrumento { get; set; }


        [ForeignKey("Igreja")]
        [Required]
        [DisplayName("Igreja (Comum)")]
        public int IdIgreja { get; set; }

        public Igreja Igreja { get; set; }  
    }
}
