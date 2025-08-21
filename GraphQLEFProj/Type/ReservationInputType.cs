using GraphQL.Types;

namespace GraphQLEFProj.Type
{
	public class ReservationInputType : InputObjectGraphType
	{
		public ReservationInputType()
		{
			Field<IntGraphType>("id");
			Field<StringGraphType>("customerFullName");
			Field<StringGraphType>("email");
			Field<StringGraphType>("phoneNumber");
			Field<IntGraphType>("partySize");
			Field<StringGraphType>("specialRequest");
			Field<DateTimeGraphType>("reservationDate");
		}
	}
}
