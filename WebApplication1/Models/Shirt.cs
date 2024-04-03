using System.ComponentModel.DataAnnotations;
using FirstWebApi.Models.Validations;

namespace FirstWebApi.Models
{
    public class Shirt
    {
        public int ShirtId {get; set; }
        //model validation (data.anotation)!!!!!!!!!
        [Required]//brand is required
        public string? Brand {get; set; }
        [Required]//color is required
        public string? Color {get; set; }
        //model validation make own attribute
        [Shirt_EnsureCorrectSizingAttribure]
        public int Size {get; set; }
        [Required]//gender is required
        public string? Gender {get; set; }
        public double Price {get; set; }
    }
}