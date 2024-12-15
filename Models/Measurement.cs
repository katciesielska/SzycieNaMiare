using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SzycieNaMiare.Models
{
    public class Measurement
    {

        [Key]
        public int Id { get; set; }
        [Range(0, 250)]
        public double Height { get; set; }
        [Range(0, 250)]
        public double NeckCircumference { get; set; }
        [Required]
        [Range(0, 250)]
        public double ShouldersWidth { get; set; }
        [Range(0, 250)]
        public double WristCircumference { get; set; }
        [Required]
        [Range(0, 250)]
        public double ChestCircumference { get; set; }
        [Range(0, 250)]
        public double WaistCircumference { get; set; }
        [Required]
        [Range(0, 250)]
        public double HipsCircumference { get; set; }
        [Required]
        [Range(0, 250)]
        public double TighCircumference { get; set; }
        [Range(0, 250)]
        public double AnkleCircumference { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
