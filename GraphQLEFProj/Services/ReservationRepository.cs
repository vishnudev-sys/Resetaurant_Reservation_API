using GraphQLEFProj.Data;
using GraphQLEFProj.Interfaces;
using GraphQLEFProj.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLEFProj.Services
{
	public class ReservationRepository : IReservationRepository
	{
		private GraphQLDbContext dbContext;

		public ReservationRepository(GraphQLDbContext dbContext)
		{
			this.dbContext = dbContext;
			
		}
		public Reservation AddReservation(Reservation reservation)
		{
			dbContext.Reservations.Add(reservation);
			dbContext.SaveChanges();
			return reservation;
		}

		public List<Reservation> GetReservations()
		{
			return dbContext.Reservations.ToList();
		}
	}
}
