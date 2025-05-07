using Fullstack.Core.Models;
using Fullstack.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fullstack.Data.Repositories
{
    public class RecipeRepository:IRecipeRepository
    {
        private readonly DataContext _context;

        public RecipeRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Recipe> GetList()
        {
            return _context.Recipes.ToList();
        }

        public Recipe GetById(int id)
        {
            return _context.Recipes.Find(id);
        }

        public Recipe Add(Recipe recipe)
        {
            try
            {
                _context.Recipes.Add(recipe);
                _context.SaveChanges();
                return recipe;
            }
            catch (DbUpdateException ex)
            {
                // לוג את השגיאה
                throw new Exception("Error saving recipe to database", ex);
            }
        }

        public Recipe Update(Recipe recipe)
        {
            _context.Recipes.Update(recipe);
            _context.SaveChanges();
            return recipe;
        }

        public void Delete(int id)
        {
            var recipe = GetById(id);
            if (recipe != null)
            {
                _context.Recipes.Remove(recipe);
                _context.SaveChanges();
            }
        }
    }
}


