using GraphQL.Types;
using GraphQLEFProj.Interfaces;
using GraphQLEFProj.Models;
using GraphQLEFProj.Services;

namespace GraphQLEFProj.Type
{
	public class CategoryType : ObjectGraphType<Category>
	{
		public CategoryType(IMenuRepository menuRepository)
		{
			Field("id", x => x.CategoryId);
			Field("name", x => x.Name);
			Field("imageUrl", x => x.ImageUrl);

			Field<ListGraphType<MenuType>>("Menus").Resolve(context =>
			{
				return menuRepository.GetAllMenu();
			});

			//Field("menus", x => x.Menus);

			//Field(m => m.CategoryId);
			//Field(m => m.Name);
			//Field(m => m.ImageUrl);
			//Field(m => m.Menus);
		}
	}
}
