using Api.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace Api.Models.DTO
{
    public class MatematicsParams
    {
        [Required]
        public double num1 { get; set; }
        [Required]
        public double num2 { get; set; }
        [Required]
        public OperationType operation { get; set; }
    }
}
