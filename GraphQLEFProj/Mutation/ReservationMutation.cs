using GraphQL;
using GraphQL.Types;
using GraphQLEFProj.Interfaces;
using GraphQLEFProj.Models;
using GraphQLEFProj.Type;

namespace GraphQLEFProj.Mutation
{
	public class ReservationMutation : ObjectGraphType
	{
		public ReservationMutation(IReservationRepository reservationRepository)
		{
			Field<ReservationTypes>("CreateReservation")
				.Arguments(new QueryArguments(new QueryArgument<ReservationInputType> { Name = "reservation" }))
				.Resolve(context =>
				{
					return reservationRepository.AddReservation(context.GetArgument<Reservation>("reservation"));
				});
		}
	}
}
