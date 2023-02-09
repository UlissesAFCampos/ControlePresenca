using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnsaioRegional.Models
{
    public class Presenca
    {
        [Key]
        public int IdPresenca { get; set; }

        [ForeignKey("DataEnsaio")]
        [Required]
        [DisplayName("Data do Ensaio")]
        public int IdData { get; set; }

        public DataEnsaio DataEnsaio { get; set; }


        [ForeignKey("Musico")]
        [Required]
        [DisplayName("Registro do músico no Ensaio")]
        public int IdMusico { get; set; }

        public Musico Musico { get; set; }  

    }
}
