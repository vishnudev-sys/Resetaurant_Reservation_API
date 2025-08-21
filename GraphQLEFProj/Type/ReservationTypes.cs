using GraphQL.Types;
using GraphQLEFProj.Models;

namespace GraphQLEFProj.Type
{
	public class ReservationTypes : ObjectGraphType<Reservation>
	{
		public ReservationTypes()
		{
			Field(m => m.Id);
			Field(m => m.CustomerFullName);
			Field(m => m.Email);
			Field(m => m.PhoneNumber);
			Field(m => m.PartySize);
			Field(m => m.SpecialRequest);
			Field(m => m.ReservationDate);
		}
	}
}
