using GraphQLEFProj.Models;

namespace GraphQLEFProj.Interfaces
{
	public interface ICategoryRepository
	{
		List<Category> GetCategories();
		Category AddCategory(Category categorymenu);
		Category UpdateCategory(int id, Category categorymenu);
		void DeleteCategory(int id);

		Category GetCategoryById(int id);

	}
}
