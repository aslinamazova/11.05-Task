using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PurpleBuzz.Models;
namespace PurpleBuzz.DAL;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<ServiceImage> ServiceImages { get; set; }

}

