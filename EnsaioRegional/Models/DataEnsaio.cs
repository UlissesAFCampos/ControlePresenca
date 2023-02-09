using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EnsaioRegional.Models
{
    public class DataEnsaio
    {
        [Key]
        public int IdData { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [DisplayName("Data do Ensaio")]       
        public DateTime Data { get; set; } = DateTime.Now;

        [Required]
        [DisplayName("Descrição do Ensaio: (Local/Regional)")]
        public string DescricaoEnsaio { get; set; }

        [Required]
        [DisplayName("Cidade de realização do Ensaio")]
        public string CidadeRealizacao { get; set; }

    }
}
