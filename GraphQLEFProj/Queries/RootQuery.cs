using GraphQL.Types;

namespace GraphQLEFProj.Queries
{
	public class RootQuery : ObjectGraphType
	{
		public RootQuery()
		{
			Field<MenuQuery>("menuQuery").Resolve(contect => new { });
			Field<CategoryQuery>("categoryQuery").Resolve(contect => new { });
			Field<ReservationQuery>("reservationQuery").Resolve(contect => new { });
		}
	}
}
