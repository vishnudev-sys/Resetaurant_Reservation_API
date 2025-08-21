using GraphQL;
using GraphQL.Types;
using GraphQLEFProj.Interfaces;
using GraphQLEFProj.Type;

namespace GraphQLEFProj.Queries
{
	public class CategoryQuery : ObjectGraphType
	{
		//constructor
		public CategoryQuery(ICategoryRepository categoryRepository)
		{
			Field<ListGraphType<CategoryType>>("Categories").Resolve(context =>
			{
				return categoryRepository.GetCategories();
			});

			Field<ListGraphType<CategoryType>>("Categorie")
			.Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "categoryId" }))
			.Resolve(context =>
			{
				return categoryRepository.GetCategoryById(context.GetArgument<int>("categoryId"));
			});
		}
	}
}
