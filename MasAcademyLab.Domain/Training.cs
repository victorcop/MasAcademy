using System;
using System.Collections.Generic;

namespace MasAcademyLab.Domain
{
    public class Training
    {
        public int TrainingId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Location Location { get; set; }
        public DateTime EventDate { get; set; } = DateTime.MinValue;
        public int Length { get; set; } = 1;
        public IEnumerable<Talk> Talks { get; set; }
    }
}
