using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Tbl_Humano
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Nombre { get; set; }
        [MaxLength(1)]
        public char Sexo { get; set; }
        public int Edad { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
    }
}
