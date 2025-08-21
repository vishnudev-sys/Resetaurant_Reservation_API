using GraphQL.Types;
using GraphQLEFProj.Interfaces;
using GraphQLEFProj.Type;

namespace GraphQLEFProj.Queries
{
	public class ReservationQuery : ObjectGraphType
	{
		//constructor
		public ReservationQuery(IReservationRepository reservationRepository)
		{
			Field<ListGraphType<ReservationTypes>>("Reservations").Resolve(context =>
			{
				return reservationRepository.GetReservations();
			});
		}
	}
}
