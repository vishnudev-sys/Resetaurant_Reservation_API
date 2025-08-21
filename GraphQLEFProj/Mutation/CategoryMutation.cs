using GraphQL;
using GraphQL.Types;
using GraphQLEFProj.Interfaces;
using GraphQLEFProj.Models;
using GraphQLEFProj.Services;
using GraphQLEFProj.Type;

namespace GraphQLEFProj.Mutation
{
	public class CategoryMutation : ObjectGraphType
	{
		public CategoryMutation(ICategoryRepository categoryRepository)
		{
			Field<CategoryType>("CreateCategory")
				.Arguments(new QueryArguments(new QueryArgument<CategoryInputType> { Name = "category" }))
				.Resolve(context =>
				{
					return categoryRepository.AddCategory(context.GetArgument<Category>("category"));
				});

			Field<CategoryType>("UpdateCategory")
				.Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "categoryId" }, new QueryArgument<CategoryInputType> { Name = "category" }))
				.Resolve(context =>
				{
					var categoryId = context.GetArgument<int>("categoryId");
					var category = context.GetArgument<Category>("category");
					return categoryRepository.UpdateCategory(categoryId, category);
				});

			Field<CategoryType>("DeleteCategory")
				.Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "categoryId" }))
				.Resolve(context =>
				{
					var categoryId = context.GetArgument<int>("categoryId");
					var category = categoryRepository.GetCategoryById(categoryId); // fetch before
					categoryRepository.DeleteCategory(categoryId);
					return category;
				});
		}
	}
}
