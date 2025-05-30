﻿using CoreBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly MarketContext db;

		public CategoryRepository(MarketContext db)
        {
			this.db = db;
		}
        public void AddCategory(Category category)
		{
			db.Categories.Add(category);
			db.SaveChanges();
		}

		public void DeleteCategory(int Id)
		{
			var category = db.Categories.Find(Id);
			if (category == null) return;

			db.Categories.Remove(category);
			db.SaveChanges();
		}

		public IEnumerable<Category> GetCategories()
		{
			return db.Categories.ToList();
		}

		public Category GetCategoryById(int id)
		{
			return db.Categories.Find(id);
		}

		public void UpdateCategory(Category category)
		{
			var cat = db.Categories.Find(category.CategoryId);
			cat.Name = category.Name;
			cat.Description = category.Description;
			db.SaveChanges();
		}
	}
}
