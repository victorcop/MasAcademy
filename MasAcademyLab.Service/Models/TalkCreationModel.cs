using System;
using System.ComponentModel.DataAnnotations;

namespace MasAcademyLab.Service.Models
{
    public class TalkCreationModel
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        public string Abstract { get; set; }
        [Range(100, 800)]
        public int Level { get; set; }
        public SpeakerModel Speaker { get; set; }
    }
}
