using System;
using Microsoft.EntityFrameworkCore;
using ApiProjeKampi.WebApi.Entites;

namespace ApiProjeKampi.WebApi.Context;

public class ApiContextc : DbContext
{
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
        var cs = "Server=localhost,1433;Database=ApiProjeKampiDb;User Id=sa;Password=reallyStrongPwd123;Encrypt=True;TrustServerCertificate=True;";
        optionsBuilder.UseSqlServer(cs);
    }
}


    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Chef> Chefs { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Message> Messages { get; set; }

    public DbSet<Feature> Features { get; set; }
  public DbSet<Service> Services { get; set; }

}
