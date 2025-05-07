using Fullstack.Core.Models;
using Fullstack.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fullstack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {

        private readonly IIngredientService _ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        // GET: api/<IngredientController>
        [HttpGet]
        public ActionResult<IEnumerable<Ingredient>> GetAllIngredients()
        {
            var ingredients = _ingredientService.GetList();
            return Ok(ingredients);
        }

        // GET api/<IngredientController>/5
        [HttpGet("{id}")]
        public ActionResult<Ingredient> GetIngredient(int id)
        {
            var ingredient = _ingredientService.GetById(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return Ok(ingredient);
        }

        // POST api/<IngredientController>
        [HttpPost]
        public ActionResult<Ingredient> Create([FromBody] Ingredient ingredient)
        {
            var newIngredient = _ingredientService.Add(ingredient);
            return Ok(newIngredient);
        }

            // PUT api/<IngredientController>/5
            [HttpPut("{id}")]
        public ActionResult<Ingredient> UpdateIngredient(int id, Ingredient ingredient)
        {
            if (id != ingredient.Id)
            {
                return BadRequest();
            }
            var updatedIngredient = _ingredientService.Update(ingredient);
            return Ok(updatedIngredient);
        }

        // DELETE api/<IngredientController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteIngredient(int id)
        {
            _ingredientService.Delete(id);
            return Ok();
        }
    }
}
