using Fullstack.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fullstack.Core.Repositories
{
    public interface IIngredientRepository
    {
        IEnumerable<Ingredient> GetList();
        Ingredient GetById(int id);
        Ingredient Add(Ingredient ingredient);
        Ingredient Update(Ingredient ingredient);
        void Delete(int id);
    }
}
