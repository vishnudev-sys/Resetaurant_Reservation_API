using GraphQL.Types;

namespace GraphQLEFProj.Type
{
	//InoutObjectGraphType takes input from the user
	public class MenuInputType : InputObjectGraphType
	{
		public MenuInputType()
		{
			Field<IntGraphType>("id");
			Field<StringGraphType>("name");
			Field<StringGraphType>("description");
			Field<FloatGraphType>("price");
			Field<StringGraphType>("imageUrl");
			Field<IntGraphType>("categoryId");
		}
	}
}
