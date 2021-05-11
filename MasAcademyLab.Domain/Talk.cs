namespace MasAcademyLab.Domain
{
    public class Talk
    {
        public int TalkId { get; set; }
        public Training Training { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public int Level { get; set; }
        public Speaker Speaker { get; set; }
        public int SpeakerId { get; set; }
    }
}
