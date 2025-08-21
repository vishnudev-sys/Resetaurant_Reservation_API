using GraphQL.Types;
using GraphQLEFProj.Models;

namespace GraphQLEFProj.Type
{
	//Here MenuType is a schema blueprint for the Menu class, controlling what data is visible and accessible through GraphQL queries.
	//ObjectGraphType lets you describe the structure of your GraphQL schema, including what fields are available and how to resolve their values.
	public class MenuType : ObjectGraphType<Menu>
	{
		//Define constructor, we will be defining the fields that will be available in the GraphQL schema for the Menu type.
		public MenuType() 
		{
			//Field Takes lambda expressions
			Field(m => m.Id);
			Field(m => m.Name);
			Field(m => m.Description);
			Field(m => m.Price);
			Field(m => m.CategoryId);
			Field(m => m.ImageUrl);
		}
	}
}
