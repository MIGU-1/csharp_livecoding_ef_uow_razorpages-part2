﻿using System;
using CoffeeSlotMachine.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoffeeSlotMachine.Persistence
{
  public class ApplicationDbContext : DbContext
  {

    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Coin> Coins { get; set; }

    public ApplicationDbContext() { }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions) : base(contextOptions)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        var configuration = builder.Build();
        string connectionString = configuration["ConnectionStrings:DefaultConnection"];
        optionsBuilder.UseSqlServer(connectionString);
      }
    }

  }
}
