using GraphQLEFProj.Data;
using GraphQLEFProj.Interfaces;
using GraphQLEFProj.Models;

namespace GraphQLEFProj.Services
{
	public class MenuRepository : IMenuRepository
	{
		//private static List<Menu> _menus = new List<Menu>
		//{
		//	new Menu { ID = 1, Name = "Pizza", Description = "Cheese Pizza", Price = (double)9.99M },
		//	new Menu { ID = 2, Name = "Burger", Description = "Beef Burger", Price = (double)8.99M },
		//	new Menu { ID = 3, Name = "Pasta", Description = "Spaghetti Carbonara", Price = (double) 10.99M },
		//	new Menu { ID = 4, Name = "Salad", Description = "Caesar Salad", Price = (double) 7.99M },
		//	new Menu { ID = 5, Name = "Sushi", Description = "California Roll", Price = (double) 12.99M },
		//	new Menu { ID = 6, Name = "Tacos", Description = "Chicken Tacos", Price = (double) 6.99M },
		//	new Menu { ID = 7, Name = "Steak", Description = "Grilled Steak", Price = (double) 15.99M },
		//	new Menu { ID = 8, Name = "Ice Cream", Description = "Vanilla Ice Cream", Price = (double) 4.99M },
		//	new Menu { ID = 9, Name = "Coffee", Description = "Espresso Coffee", Price = (double) 2.99M },
		//	new Menu { ID = 10, Name = "Tea", Description = "Green Tea", Price = (double) 1.99M }
		//};

		//commented above to implement DB changes now

		private GraphQLDbContext dbContext;

		public MenuRepository(GraphQLDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public List<Menu> GetAllMenu()
		{
			return dbContext.Menus.ToList();
		}

		public Menu AddMenuItem(Menu menu)
		{
			// Ensure ID uniqueness before adding
			//if (dbContext.Menus.Any(m => m.ID == menu.ID))
			//	throw new ArgumentException($"Menu with ID {menu.ID} already exists.");
			//dbContext.Add(menu);
			dbContext.Menus.Add(menu);
			dbContext.SaveChanges();
			return menu;
		}

		public void DeleteMenuItem(int id)
		{
			var menuResult = dbContext.Menus.Find(id);

			if (menuResult == null)
				throw new KeyNotFoundException($"Menu with ID {id} not found to delete.");
			
			dbContext.Remove(menuResult);
			dbContext.SaveChanges();
		}

		public Menu GetMenuById(int id)
		{
			var menu = dbContext.Menus.Find(id);
			if (menu == null)
				throw new KeyNotFoundException($"Menu with ID {id} not found.");
			return menu;
		}

		public Menu UpdateMenuItem(int id, Menu menu)
		{
			var menuResult = dbContext.Menus.Find(id);

			if (menuResult == null)
				throw new KeyNotFoundException($"Menu with ID {id} not found.");

			menuResult.Name = menu.Name;
			menuResult.Description = menu.Description;
			menuResult.Price = menu.Price;

			dbContext.SaveChanges();
			
			return menuResult;
		}
	}
}
