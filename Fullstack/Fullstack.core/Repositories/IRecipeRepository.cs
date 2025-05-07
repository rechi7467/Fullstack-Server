using Fullstack.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fullstack.Core.Repositories
{
    public interface IRecipeRepository
    {
        IEnumerable<Recipe> GetList();
        Recipe GetById(int id);
        Recipe Add(Recipe recipe);
        Recipe Update(Recipe recipe);
        void Delete(int id);
    }
}
