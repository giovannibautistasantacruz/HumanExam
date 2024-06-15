using System.ComponentModel.DataAnnotations;

namespace Api.Models.DTO
{
    public class Tbl_HumanoDTO
    {
        public int? Id { get; set; }
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
