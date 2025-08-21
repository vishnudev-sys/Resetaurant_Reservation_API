using GraphQLEFProj.Mutation;
using GraphQLEFProj.Queries;

namespace GraphQLEFProj.Schema
{
	public class RootSchema : GraphQL.Types.Schema
	{
		public RootSchema(IServiceProvider serviceProvider) : base(serviceProvider)
		{
			Query = serviceProvider.GetRequiredService<RootQuery>();
			Mutation = serviceProvider.GetService<RootMutation>();
		}
	}
}
