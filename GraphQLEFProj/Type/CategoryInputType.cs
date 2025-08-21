using GraphQL.Types;

namespace GraphQLEFProj.Type
{
	public class CategoryInputType : InputObjectGraphType
	{
		public CategoryInputType()
		{
			Field<IntGraphType>("categoryId");
			Field<StringGraphType>("name");
			Field<StringGraphType>("imageUrl");
			//Field<IntGraphType>("Menus");
		}
	}
}
