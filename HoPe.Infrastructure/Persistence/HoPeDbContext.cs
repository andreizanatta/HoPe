﻿using HoPe.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HoPe.Infrastructure.Persistence
{
    public class HoPeDbContext(DbContextOptions<HoPeDbContext> options) : DbContext(options)
    {
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Pet> Pet { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
