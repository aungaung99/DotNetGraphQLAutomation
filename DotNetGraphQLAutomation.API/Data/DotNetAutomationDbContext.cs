using System;
using System.Collections.Generic;
using DotNetCrudAutomation.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNetCrudAutomation.Data;

public partial class DotNetAutomationDbContext : DbContext
{
    public DotNetAutomationDbContext(DbContextOptions<DotNetAutomationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
