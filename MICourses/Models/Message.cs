namespace MICourses.Models
{
    public class Message
    {
        public int MessageID { get; set; }
        public int ChatID { get; set; }
        public Chat Chat { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
