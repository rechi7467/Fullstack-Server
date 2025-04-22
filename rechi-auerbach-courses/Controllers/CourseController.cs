using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {


        private readonly DataContext _context;

        public CourseController(DataContext context)
        {
            _context = context;
        }



        // GET: api/<Course>
        [HttpGet("GetAllCourses")]
        public IEnumerable<Course> GetAllCurses()
        {
            return _context.courses;
        }

        // GET api/<Course>/5
        [HttpGet("{id}/GetCourseById")]
        public Course GetCourseById(int id)
        {
            return _context.courses.Find(c => c.Id == id);
        }

        // POST api/<Course>
        [HttpPost("AddCourse")]
        public void AddCourse(Course value)
        {
            _context.courses.Add(value);
        }

        // PUT api/<Course>/5
        [HttpPut("{id}/UpdateDay")]
        public void Put(int Id,int day)
        {
            _context.courses.Find(c => c.Id == Id).Day = day;
        }

        // PUT api/<Course>/5
        [HttpPut("{id}/UpdateStart_Time")]
        public void UpdateStart_Time(int Id, TimeOnly start_Time)
        {
            _context.courses.Find(c => c.Id == Id).Start_Time = start_Time;
        }

        [HttpPut("{id}/UpdateTeacher")]
        public void UpdateTeacher(int Id,Teacher teacher)
        {

            _context.courses.Find(c => c.Id == Id).Teacher = teacher;
            //DataContext.courses.Find(c => c.Id == Id).Teacher.Name = Teacher.Name;
            //DataContext.courses.Find(c => c.Id == Id).Teacher.Address = Teacher.Address;
            //DataContext.courses.Find(c => c.Id == Id).Teacher.Phone = Teacher.Phone;
            //DataContext.courses.Find(c => c.Id == Id).Teacher.Email = Teacher.Email;
        }

        // POST api/<Course>
        [HttpPost("AddStudent")]
        public void AddStudent(int id,Student value)
        {
            _context.courses.Find(c=>c.Id==id).students.Add(value);
        }

        // DELETE api/<Course>/5
        [HttpDelete("{id}/DeleteCourse")]
        public void DeleteCourse(int id)
        {
            _context.courses.Remove(_context.courses.Find(c => c.Id == id));
        }

        [HttpDelete("{id}/DeleteStudentFromCourse")]
        public void DeleteStudentFromCourse(int idOfCourse, int idOfStudent)
        {
            _context.courses.Find(c => c.Id == idOfCourse).students.Remove(_context.courses.Find(c => c.Id == idOfCourse).students.Find(s => s.Id == idOfStudent));
            //courses.Remove(courses.Find(c => c.Id == idOfCourse).students.Find(s => s.Id == idOfStudent));
        }
    }
}
