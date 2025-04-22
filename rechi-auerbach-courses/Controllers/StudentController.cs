using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly DataContext _context;

        public StudentController(DataContext context)
        {
            _context = context;
        }

        // GET: api/<Student>
        [HttpGet("GetAllStudents")]
        public IEnumerable<Student> GetAllStudents()
        {
            return _context.students;
        }

        // GET api/<Student>/5
        [HttpGet("{id}/GetStudentById")]
        public Student GetStudentById(int id)
        {
            return _context.students.Find(s => s.Id == id);
        }

        // POST api/<Student>
        [HttpPost("AddStudent")]
        public void AddStudent(Student value)
        {
            _context.students.Add(value);
        }

        // PUT api/<Student>/5
        [HttpPut("{id}/UpdateName")]
        public void UpdateName(int id, string name)
        {
            _context.students.Find(s => s.Id == id).Name = name;
        }

        // PUT api/<Student>/5
        [HttpPut("{id}/UpdatePhone")]
        public void UpdatePhone(int id, string phone)
        {
            _context.students.Find(s => s.Id == id).Phone = phone;
        }

        // PUT api/<Student>/5
        [HttpPut("{id}/UpdateAddress")]
        public void UpdateAddress(int id, string address)
        {
            _context.students.Find(s => s.Id == id).Address = address;
        }

        // PUT api/<Student>/5
        [HttpPut("{id}/UpdateAge")]
        public void UpdateAge(int id, int age)
        {
            _context.students.Find(s => s.Id == id).Age = age;
        }

        // DELETE api/<Student>/5
        [HttpDelete("{id}/DeleteStudent")]
        public void DeleteStudent(int id)
        {
            _context.students.Remove(_context.students.Find(s => s.Id == id));
        }
    }
}
