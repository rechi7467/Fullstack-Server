using Fullstack.Core.Models;
using Fullstack.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fullstack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/<Category>
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetAllCategories()
        {
            var categories = _categoryService.GetList();
            return Ok(categories);
        }

        // GET api/<Category>/5
        [HttpGet("{id}")]
        public ActionResult<Category> GetCategoryById(int id)
        {
            var category = _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // POST api/<Category>
        [HttpPost]
        public ActionResult<Category> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCategory = _categoryService.Add(category);
            return Ok(newCategory);
        }

            // PUT api/<Category>/5
            [HttpPut("{id}")]
        public ActionResult<Category> Update(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedCategory = _categoryService.Update(category);
            return Ok(updatedCategory);
        }

        // DELETE api/<Category>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            _categoryService.Delete(id);
            return Ok();
        }
    }
}
