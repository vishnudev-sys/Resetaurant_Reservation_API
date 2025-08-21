using GraphQLEFProj.Data;
using GraphQLEFProj.Interfaces;
using GraphQLEFProj.Models;

namespace GraphQLEFProj.Services
{
	public class CategoryRepository : ICategoryRepository
	{
		private GraphQLDbContext dbContext;

		// Constructor to initialize the dbContext
		public CategoryRepository(GraphQLDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public Category AddCategory(Category categorymenu)
		{
			var newCategory = new Category
			{
				Name = categorymenu.Name,
				ImageUrl = categorymenu.ImageUrl
			};
			dbContext.Categories.Add(newCategory);
			dbContext.SaveChanges();
			return categorymenu;
		}

		public void DeleteCategory(int id)
		{
			var categoryResult = dbContext.Categories.Find(id);
			if(categoryResult == null)
				throw new KeyNotFoundException($"Category with ID {id} not found to delete.");
			dbContext.Categories.Remove(categoryResult);
			dbContext.SaveChanges();

		}

		public List<Category> GetCategories()
		{
			return dbContext.Categories.ToList();
		}

		public Category UpdateCategory(int id, Category categorymenu)
		{
			var categoryResult = dbContext.Categories.Find(categorymenu);

			if (categoryResult == null)
				throw new KeyNotFoundException($"Menu with ID {categorymenu} not found.");

			categoryResult.Name = categorymenu.Name;
			categoryResult.ImageUrl = categorymenu.ImageUrl;
			
			dbContext.SaveChanges();

			return categoryResult;
		}

		public Category GetCategoryById(int CategoryId)
		{
			var category = dbContext.Categories.Find(CategoryId);
			if (category == null)
				throw new KeyNotFoundException($"Category with ID {CategoryId} not found.");
			return category;
		}
	}
}
