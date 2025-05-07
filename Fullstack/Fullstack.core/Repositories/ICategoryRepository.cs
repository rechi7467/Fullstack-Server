using Fullstack.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fullstack.Core.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetList();
        Category GetById(int id);
        Category Add(Category category);
        Category Update(Category category);
        void Delete(int id);
    }
}
