

namespace project
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Teacher Teacher { get; set; }
        public List<Student> students { get; set; }
        public int Day {  get; set; }   
        public TimeOnly Start_Time { get; set; }
        public int Minutse { get; set; }
    }
}
