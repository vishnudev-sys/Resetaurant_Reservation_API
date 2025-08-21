using GraphQLEFProj.Mutation;
using GraphQLEFProj.Queries;

namespace GraphQLEFProj.Schema
{
	public class MenuSchema : GraphQL.Types.Schema
	{
		public MenuSchema(MenuQuery menuQuery, MenuMutation menuMutation) 
		{ 
			Query = menuQuery;
			Mutation = menuMutation;
			// Register any mutations or subscriptions here if needed
		}
	}
}
