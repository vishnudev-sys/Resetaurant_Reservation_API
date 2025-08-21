using GraphQLEFProj.Models;

namespace GraphQLEFProj.Interfaces
{
	public interface IMenuRepository
	{
		List<Menu> GetAllMenu();
		Menu GetMenuById(int id);
		Menu AddMenuItem(Menu menu);
		Menu UpdateMenuItem(int id, Menu menu);
		void DeleteMenuItem(int id);
	}
}
