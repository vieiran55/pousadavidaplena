﻿using Microsoft.EntityFrameworkCore;
using PousadaVidaPlena.Models;
using PousadaVidaPlena.Models.Entities;

namespace PousadaVidaPlena.Data
{
    public class PousadaContext : DbContext
    {
        public PousadaContext(DbContextOptions<PousadaContext> options) : base(options) { }

        public DbSet<Room> Room { get; set; } = default!;
        public DbSet<Client> Client { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Reservation> Reservation { get; set; }

    }
}
