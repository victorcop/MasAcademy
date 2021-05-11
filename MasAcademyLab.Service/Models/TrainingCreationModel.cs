using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MasAcademyLab.Service.Models
{
    public class TrainingCreationModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public DateTime EventDate { get; set; } = DateTime.MinValue;
        [Range(1, 100)]
        public int Length { get; set; } = 1;
        public LocationModel Location { get; set; }
        public IEnumerable<TalkModel> Talks { get; set; }
    }
}
