using GraphQL;
using GraphQL.Types;
using GraphQLEFProj.Interfaces;
using GraphQLEFProj.Type;

namespace GraphQLEFProj.Queries
{
	public class MenuQuery : ObjectGraphType
	{
		//constructor
		public MenuQuery(IMenuRepository menuRepository)
		{
			// When we want C# to return list we use IEnumarable or list, in graph QL we use ListGraphType
			Field<ListGraphType<MenuType>>("Menus").Resolve(context =>
			{
				return menuRepository.GetAllMenu();
			});

			Field<MenuType>("Menu")
				.Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "menuID" }))
				.Resolve(context =>
				{
					return menuRepository.GetMenuById(context.GetArgument<int>("menuID"));
				});
		}
	}
}
