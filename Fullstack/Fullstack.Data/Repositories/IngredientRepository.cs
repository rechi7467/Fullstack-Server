using Fullstack.Core.Models;
using Fullstack.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fullstack.Data.Repositories
{
    public class IngredientRepository:IIngredientRepository
    {
        private readonly DataContext _context;

        public IngredientRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Ingredient> GetList()
        {
            return _context.Ingredients.ToList();
        }

        public Ingredient GetById(int id)
        {
            return _context.Ingredients.Find(id);
        }

        public Ingredient Add(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            _context.SaveChanges();
            return ingredient;
        }

        public Ingredient Update(Ingredient ingredient)
        {
            _context.Ingredients.Update(ingredient);
            _context.SaveChanges();
            return ingredient;
        }

        public void Delete(int id)
        {
            var ingredient = GetById(id);
            if (ingredient != null)
            {
                _context.Ingredients.Remove(ingredient);
                _context.SaveChanges();
            }
        }
    }
}
