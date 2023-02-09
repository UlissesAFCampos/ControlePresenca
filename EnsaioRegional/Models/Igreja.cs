using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EnsaioRegional.Models
{
    public class Igreja
    {
        [Key]
        public int IdIgreja { get; set; }
                
        [Required(ErrorMessage = "O código do relatório é obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Número do Relatório")]
        public string NumeroRelatorio { get; set; }
        
        [Required(ErrorMessage = "O nome da igreja é obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Igreja")]
        public string Nomeigreja { get; set; }
        
        [Required(ErrorMessage = "O nome da cidade é obrigatório", AllowEmptyStrings = false)]
        [DisplayName("Cidade")]
        public string Cidade { get; set; }
    }
}
