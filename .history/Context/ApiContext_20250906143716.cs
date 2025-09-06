using System;
using Microsoft.EntityFrameworkCore;
using ApiProjeKampi.WebApi.Entites;

namespace ApiProjeKampi.WebApi.Context;

public class ApiContextc: DbContext
{
 protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=localhost;initial catalog=ApiYummyDb;integrated security=true;");
    }

  public DbSet<Category> Categories { get; set; }
}
