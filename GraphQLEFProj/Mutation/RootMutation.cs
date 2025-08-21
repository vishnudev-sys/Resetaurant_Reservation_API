using GraphQL.Types;

namespace GraphQLEFProj.Mutation
{
	public class RootMutation : ObjectGraphType
	{
		public RootMutation()
		{
			Field<MenuMutation>("menuMutation").Resolve(contect => new { });
			Field<CategoryMutation>("categoryMutation").Resolve(contect => new { });
			Field<ReservationMutation>("reservationMutation").Resolve(contect => new { });
		}
	}
}
