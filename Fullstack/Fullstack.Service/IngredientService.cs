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
    public class IngredientService:IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public IEnumerable<Ingredient> GetList()
        {
            return _ingredientRepository.GetList();
        }

        public Ingredient GetById(int id)
        {
            return _ingredientRepository.GetById(id);
        }

        public Ingredient Add(Ingredient ingredient)
        {
            return _ingredientRepository.Add(ingredient);
        }

        public Ingredient Update(Ingredient ingredient)
        {
            return _ingredientRepository.Update(ingredient);
        }

        public void Delete(int id)
        {
            _ingredientRepository.Delete(id);
        }
    }
}
