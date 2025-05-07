using Fullstack.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fullstack.Core.Services
{
    public interface IRecipeService
    {
        IEnumerable<Recipe> GetList();
        Recipe GetById(int id);
        Recipe Add(Recipe recipe);
        Recipe Update(Recipe recipe);
        void Delete(int id);
    }
}
