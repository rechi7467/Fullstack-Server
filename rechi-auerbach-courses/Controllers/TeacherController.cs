using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {

        private readonly DataContext _context;

        public TeacherController(DataContext context)
        {
            _context = context;
        }

        // GET: api/<Teacher>
        [HttpGet("GetAllTeachers")]
        public IEnumerable<Teacher> GetAllTeachers()
        {
            return _context.teachers;
        }

        // GET api/<Teacher>/5
        [HttpGet("{id}/GetTeacherById")]
        public ActionResult GetTeacherById(int id)
        {
            Teacher t = _context.teachers.Find(t => t.Id == id);
            if(t==null)
                return NotFound();
            return Ok(t);
        }

        // POST api/<Teacher>
        [HttpPost("AddTeacher")]
        public void AddTeacher(Teacher t)
        {
            _context.teachers.Add(t);
        }

        // PUT api/<Teacher>/5
        [HttpPut("{id}/UpdateName")]
        public void UpdateName(int id, string name)
        {
            _context.teachers.Find(t => t.Id == id).Name = name;
        }

        // PUT api/<Teacher>/5
        [HttpPut("{id}/UpdatePhone")]
        public void UpdatePhone(int id, string phone)
        {
            _context.teachers.Find(t => t.Id == id).Phone = phone;
        }

        // PUT api/<Teacher>/5
        [HttpPut("{id}/UpdateAddress")]
        public void UpdateAddress(int id, string address)
        {
            _context.teachers.Find(t => t.Id == id).Address = address;
        }

        // PUT api/<Teacher>/5
        [HttpPut("{id}/UpdateEmail")]
        public void UpdateEmailt(int id, string email)
        {
            _context.teachers.Find(t => t.Id == id).Email = email;
        }


        // DELETE api/<Teacher>/5
        [HttpDelete("{id}/DeleteTeacher")]
        public void Delete(int id)
        {
            _context.teachers.Remove(_context.teachers.Find(t => t.Id == id));
        }
    }
}
