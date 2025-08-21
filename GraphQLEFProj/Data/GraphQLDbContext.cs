using GraphQLEFProj.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLEFProj.Data
{
	public class GraphQLDbContext : DbContext
	{
		//This constructor gets all the necessary configuration information, including connection string.
		public GraphQLDbContext(DbContextOptions<GraphQLDbContext> options) : base(options)
		{

		}
		public DbSet<Menu> Menus { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Reservation> Reservations { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Category>().HasData(
				new Category { CategoryId = 1, Name = "Appetizers", ImageUrl = "https://www.thechoppingblock.com/hs-fs/hubfs/Blog/appetizer%20spread.png?width=600&name=appetizer%20spread.png" },
				new Category { CategoryId = 2, Name = "Main Courses", ImageUrl = "https://media.istockphoto.com/id/1194814094/photo/georgian-cuisine-a-large-laid-table-of-different-dishes-for-the-whole-family-on-a-day-off.jpg?s=612x612&w=0&k=20&c=ou5dKMu01patcNhcYE4SaaMAUUUZ6BSzq-XXekGKat0=" },
				new Category { CategoryId = 3, Name = "Desserts", ImageUrl = "https://i.pinimg.com/736x/61/57/91/615791358328f5dd8eed8508c9f770b7.jpg" },
				new Category { CategoryId = 4, Name = "Beverages", ImageUrl = "https://www.indiabusinesstrade.in/wp-content/uploads/2024/03/beverage-2.jpg" }
			);
			modelBuilder.Entity<Menu>().HasData(
				new Menu { Id = 1, Name = "Pizza", Description = "Cheese Pizza", Price = 9.99, ImageUrl = "https://example.com/images/pizza.jpg", CategoryId = 2 },
				new Menu { Id = 2, Name = "Burger", Description = "Burger", Price = 8.99, ImageUrl = "https://example.com/images/burger.jpg", CategoryId = 2 },
				new Menu { Id = 3, Name = "Pasta", Description = "Spaghetti Carbonara", Price = 10.99, ImageUrl = "https://www.indianhealthyrecipes.com/wp-content/uploads/2024/04/white-sauce-pasta.jpg", CategoryId = 2 },
				new Menu { Id = 4, Name = "Salad", Description = "Caesar Salad", Price = 7.99, ImageUrl = "https://example.com/images/salad.jpg", CategoryId = 1 },
				new Menu { Id = 5, Name = "Sushi", Description = "California Roll", Price = 12.99, ImageUrl = "https://example.com/images/sushi.jpg", CategoryId = 2 },
				new Menu { Id = 6, Name = "Tacos", Description = "Chicken Tacos", Price = 6.99, ImageUrl = "https://example.com/images/tacos.jpg", CategoryId = 2 },
				new Menu { Id = 7, Name = "Steak", Description = "Grilled Steak", Price = 15.99, ImageUrl = "https://example.com/images/steak.jpg", CategoryId = 2 },
				new Menu { Id = 8, Name = "Ice Cream", Description = "Vanilla Ice Cream", Price = 4.99, ImageUrl = "https://example.com/images/ice_cream.jpg", CategoryId = 3 },
				new Menu { Id = 9, Name = "Coffee", Description = "Espresso Coffee", Price = 2.99, ImageUrl = "https://example.com/images/coffee.jpg", CategoryId = 4 },
				new Menu { Id = 10, Name = "Tea", Description = "Green Tea", Price = 1.99, ImageUrl = "https://example.com/images/tea.jpg", CategoryId = 4 }
			);

			modelBuilder.Entity<Reservation>().HasData(
				new Reservation { Id = 1, CustomerFullName = "John Doe", Email = "johndoe@example.com", PhoneNumber = "555-123-4567", PartySize = 2, SpecialRequest = "No nuts in the dishes, please.", ReservationDate = new DateTime(2025, 8, 19, 18, 0, 0, DateTimeKind.Utc) },
				new Reservation { Id = 2, CustomerFullName = "Jane Smith", Email = "janesmith@example.com", PhoneNumber = "555-987-6543", PartySize = 4, SpecialRequest = "Gluten-free options required.", ReservationDate = new DateTime(2025, 8, 22, 18, 0, 0, DateTimeKind.Utc) },
				new Reservation { Id = 3, CustomerFullName = "Michael Johnson", Email = "michaeljohnson@example.com", PhoneNumber = "555-789-0123", PartySize = 6, SpecialRequest = "Celebrating a birthday.", ReservationDate = new DateTime(2025, 8, 26, 18, 0, 0, DateTimeKind.Utc) }
			);
		}


		// old
		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//	base.OnModelCreating(modelBuilder);
		//	modelBuilder.Entity<Menu>()
		//		.HasData(
		//		new Menu { ID = 1, Name = "Pizza", Description = "Cheese Pizza", Price = (double)9.99 },
		//		new Menu { ID = 2, Name = "Burger", Description = "Beef Burger", Price = (double)8.99 },
		//		new Menu { ID = 3, Name = "Pasta", Description = "Spaghetti Carbonara", Price = (double)10.99 },
		//		new Menu { ID = 4, Name = "Salad", Description = "Caesar Salad", Price = (double)7.99 },
		//		new Menu { ID = 5, Name = "Sushi", Description = "California Roll", Price = (double)12.99 },
		//		new Menu { ID = 6, Name = "Tacos", Description = "Chicken Tacos", Price = (double)6.99 },
		//		new Menu { ID = 7, Name = "Steak", Description = "Grilled Steak", Price = (double)15.99 },
		//		new Menu { ID = 8, Name = "Ice Cream", Description = "Vanilla Ice Cream", Price = (double)4.99 },
		//		new Menu { ID = 9, Name = "Coffee", Description = "Espresso Coffee", Price = (double)2.99 },
		//		new Menu { ID = 10, Name = "Tea", Description = "Green Tea", Price = (double)1.99 }
		//		); // Ensure ID is the primary key
		//}

		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//	base.OnModelCreating(modelBuilder);
		//	modelBuilder.Entity<Category>().HasData(
		//		new Category { CategoryId = 1, Name = "Appetizers", ImageUrl = "https://example.com/images/appetizers.jpg" },
		//		new Category { CategoryId = 2, Name = "Main Courses", ImageUrl = "https://example.com/images/main_courses.jpg" },
		//		new Category { CategoryId = 3, Name = "Desserts", ImageUrl = "https://example.com/images/desserts.jpg" },
		//		new Category { CategoryId = 4, Name = "Beverages", ImageUrl = "https://example.com/images/beverages.jpg" }
		//	);
		//	modelBuilder.Entity<Menu>().HasData(
		//		new Menu { ID = 1, Name = "Pizza", Description = "Cheese Pizza", Price = 9.99, ImageUrl = "https://example.com/images/pizza.jpg", CategoryId = 2 },
		//		new Menu { ID = 2, Name = "Burger", Description = "Beef Burger", Price = 8.99, ImageUrl = "https://example.com/images/burger.jpg", CategoryId = 2 },
		//		new Menu { ID = 3, Name = "Pasta", Description = "Spaghetti Carbonara", Price = 10.99, ImageUrl = "https://example.com/images/pasta.jpg", CategoryId = 2 },
		//		new Menu { ID = 4, Name = "Salad", Description = "Caesar Salad", Price = 7.99, ImageUrl = "https://example.com/images/salad.jpg", CategoryId = 1 },
		//		new Menu { ID = 5, Name = "Sushi", Description = "California Roll", Price = 12.99, ImageUrl = "https://example.com/images/sushi.jpg", CategoryId = 2 },
		//		new Menu { ID = 6, Name = "Tacos", Description = "Chicken Tacos", Price = 6.99, ImageUrl = "https://example.com/images/tacos.jpg", CategoryId = 2 },
		//		new Menu { ID = 7, Name = "Steak", Description = "Grilled Steak", Price = 15.99, ImageUrl = "https://example.com/images/steak.jpg", CategoryId = 2 },
		//		new Menu { ID = 8, Name = "Ice Cream", Description = "Vanilla Ice Cream", Price = 4.99, ImageUrl = "https://example.com/images/ice_cream.jpg", CategoryId = 3 },
		//		new Menu { ID = 9, Name = "Coffee", Description = "Espresso Coffee", Price = 2.99, ImageUrl = "https://example.com/images/coffee.jpg", CategoryId = 4 },
		//		new Menu { ID = 10, Name = "Tea", Description = "Green Tea", Price = 1.99, ImageUrl = "https://example.com/images/tea.jpg", CategoryId = 4 }
		//	);

		//	modelBuilder.Entity<Reservation>().HasData(
		//	  new Reservation { Id = 1, CustomerFullName = "John Doe", Email = "johndoe@example.com", PhoneNumber = "555-123-4567", PartySize = 2, SpecialRequest = "No nuts in the dishes, please.", ReservationDate = DateTime.Now.AddDays(7) },
		//	  new Reservation { Id = 2, CustomerFullName = "Jane Smith", Email = "janesmith@example.com", PhoneNumber = "555-987-6543", PartySize = 4, SpecialRequest = "Gluten-free options required.", ReservationDate = DateTime.Now.AddDays(10) },
		//	  new Reservation { Id = 3, CustomerFullName = "Michael Johnson", Email = "michaeljohnson@example.com", PhoneNumber = "555-789-0123", PartySize = 6, SpecialRequest = "Celebrating a birthday.", ReservationDate = DateTime.Now.AddDays(14) }
		//  );
		//}
	}
}