using System;
using System.ComponentModel.DataAnnotations;

namespace MasAcademyLab.Service.Models
{
    public class TrainingUpdateModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public DateTime EventDate { get; set; } = DateTime.MinValue;
        [Range(1, 100)]
        public int Length { get; set; } = 1;
        public LocationModel Location { get; set; }
    }
}
