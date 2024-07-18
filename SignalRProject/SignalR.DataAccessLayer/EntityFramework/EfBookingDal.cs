using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(SignalRContext context) : base(context)
        {
        }

        public int BookingCount()
        {
            using var context = new SignalRContext();
            return context.Bookings.Count();

        }

        public void BookingStatusApproved(int id)
        {
            using var context = new SignalRContext();
          var values = context.Bookings.Find(id);
            values.Description = "Reservation Confirmed";
            context.SaveChanges();

        }

        public void BookingStatusCancelled(int id)
        {
            using var context = new SignalRContext();
            var values = context.Bookings.Find(id);
            values.Description = "Reservation Canceled";
            context.SaveChanges();
        }
    }
}
