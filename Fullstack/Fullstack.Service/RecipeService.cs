using Fullstack.Core.Models;
using Fullstack.Core.Repositories;
using Fullstack.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fullstack.Service
{
    public class RecipeService:IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public IEnumerable<Recipe> GetList()
        {
            return _recipeRepository.GetList();
        }

        public Recipe GetById(int id)
        {
            return _recipeRepository.GetById(id);
        }

        public Recipe Add(Recipe recipe)
        {
            return _recipeRepository.Add(recipe);
        }

        public Recipe Update(Recipe recipe)
        {
            return _recipeRepository.Update(recipe);
        }

        public void Delete(int id)
        {
            _recipeRepository.Delete(id);
        }
    }
}
