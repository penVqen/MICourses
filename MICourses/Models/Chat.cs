namespace MICourses.Models
{
    public class Chat
    {
        public int ChatID { get; set; }
        public int StudentID { get; set; }
        public User Student { get; set; }
        public int TeacherID { get; set; }
        public User Teacher { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
