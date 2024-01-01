using FlightApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlightApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<FlightApp.Models.Passenger>? Passenger { get; set; }
        public DbSet<FlightApp.Models.Payment>? Payment { get; set; }
        public DbSet<FlightApp.Models.Flight>? Flight { get; set; }


    }
}