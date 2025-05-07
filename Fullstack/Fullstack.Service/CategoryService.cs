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
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> GetList()
        {
            return _categoryRepository.GetList();
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public Category Add(Category category)
        {
            return _categoryRepository.Add(category);
        }

        public Category Update(Category category)
        {
            return _categoryRepository.Update(category);
        }

        public void Delete(int id)
        {
            _categoryRepository.Delete(id);
        }
    }
}
