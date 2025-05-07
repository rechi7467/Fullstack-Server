using Fullstack.Core.Models;
using Fullstack.Core.Services;
using Fullstack.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fullstack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {

        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        // GET: api/<Recipe>
        [HttpGet]
        public ActionResult<IEnumerable<Recipe>> GetAll()
        {
            var recipes = _recipeService.GetList();
            return Ok(recipes);
        }

        // GET api/<Recipe>/5
        [HttpGet("{id}")]
        public ActionResult<Recipe> GetById(int id)
        {
            var recipe = _recipeService.GetById(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(recipe);
        }

        // POST api/<Recipe>
        [HttpPost]
        public ActionResult<Recipe> Create(Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newRecipe = _recipeService.Add(recipe);
            return Ok(newRecipe);
        }

        // PUT api/<Recipe>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedRecipe = _recipeService.Update(recipe);
            return Ok(updatedRecipe);
        }


        // DELETE api/<Recipe>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _recipeService.Delete(id);
            return Ok();
        }

    }
}
