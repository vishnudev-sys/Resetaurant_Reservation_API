using GraphQLEFProj.Models;

namespace GraphQLEFProj.Interfaces
{
	public interface IReservationRepository
	{
		List<Reservation> GetReservations();
		Reservation AddReservation(Reservation reservation);
	}
}
