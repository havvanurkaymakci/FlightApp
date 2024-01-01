﻿using FlightApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlightApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}