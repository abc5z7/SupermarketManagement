using CoreBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class CategoryInMemoryRepository : ICategoryRepository
    {
        private List<Category> categories;

        public CategoryInMemoryRepository()
        {
            categories = new List<Category>()
            { 
                new Category() {CategoryId = 1, Name = "面包", Description = "面包描述"},
                new Category() {CategoryId = 2, Name = "豆奶", Description = "豆制品"},
                new Category() {CategoryId = 3, Name = "火腿", Description = "肉类"},
            };
        }

		public void AddCategory(Category category)
		{
            if (categories.Any(m => m.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase)))
                return;
            var maxId = 0;
			if (categories.Any()) 
                maxId = categories.Max(m => m.CategoryId);
            category.CategoryId = maxId + 1;
            categories.Add(category);
		}

        public void UpdateCategory(Category category)
        {
            var cateToUpdate = GetCategoryById(category.CategoryId);

			if (cateToUpdate != null)
            {
				cateToUpdate.Name = category.Name;
				cateToUpdate.Description = category.Description;
			}
        }

		public IEnumerable<Category> GetCategories()
        {
            //
            return categories;
        }

        public Category GetCategoryById(int id)
        {
            return categories?.FirstOrDefault(m => m.CategoryId == id);

		}

        public void DeleteCategory(int Id)
        {
            categories?.Remove(GetCategoryById(Id));
        }
	}
}
