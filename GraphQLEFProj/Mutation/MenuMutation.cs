using GraphQL;
using GraphQL.Types;
using GraphQLEFProj.Interfaces;
using GraphQLEFProj.Models;
using GraphQLEFProj.Type;

namespace GraphQLEFProj.Mutation
{
	public class MenuMutation : ObjectGraphType
	{
		public MenuMutation(IMenuRepository menuRepository)
		{
			Field<MenuType>("CreateMenu")
				.Arguments(new QueryArguments(new QueryArgument<MenuInputType> { Name = "menu" }))
				.Resolve(context =>
				{
					return menuRepository.AddMenuItem(context.GetArgument<Menu>("menu"));
				});

			Field<MenuType>("UpdateMenu")
				.Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "menuId" }, new QueryArgument<MenuInputType> { Name = "menu" }))
				.Resolve(context =>
				{
					var menuId = context.GetArgument<int>("menuId");
					var menu = context.GetArgument<Menu>("menu");
					return menuRepository.UpdateMenuItem(menuId, menu);
				});
			Field<MenuType>("DeleteMenu")
				.Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "menuId" }))
				.Resolve(context =>
				{
					var menuId = context.GetArgument<int>("menuId");
					var menu = menuRepository.GetMenuById(menuId); // fetch before
					menuRepository.DeleteMenuItem(menuId);
					return menu; // return the deleted menu object
				});
		}

	}
}



//Without DI 
//public interface IMenuRepository
//{
//	List<Menu> GetMenus();
//}

//public class MenuRepository : IMenuRepository
//{
//	public List<Menu> GetMenus()
//	{
//		return Menus;
//	}
//}
//public class MenusController : ControllerBase
//{

//	MenuRepository menuRepository = new MenuRepository();
//	public List<Menu> GET()
//	{
//		return menuRepository.GetMenus();
//	}
//}

//With DI
//public interface IMenuRepository
//{
//	List<Menu> GetMenus();
//}

//public class MenuRepository : IMenuRepository
//{
//	public List<Menu> GetMenus()
//	{
//		return Menus;
//	}
//}
//public class MenusController : ControllerBase
//{
//	private IMenuRepository menuRepository;
//	public MenusController(IMenuRepository menuRepository)
//	{
//		this.menuRepository = menuRepository;
//	}
//	public List<Menu> GET()
//	{
//		return menuRepository.GetMenus();
//	}
//}