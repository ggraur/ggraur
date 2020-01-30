using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bakery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Logging;
using Bakery;
using Bakery.Data.Configuration;
using System.Reflection;

namespace Bakery.Data
{

    public class BakeryContext : DbContext
    {
        public static bool isMigration = true;
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (isMigration)
            {
                optionsBuilder.UseSqlServer("Data Source=ggraur;Database=Bakery;User Id=sa;Password=260707Gruita;Trusted_Connection=True;MultipleActiveResultSets=true;");
            }
            //optionsBuilder.UseSqlite(@"Data source=Bakery.db");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new ProductConfiguration());
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration()).Seed();
        }
    }

    //public class BakeryContext
    //{
    //    public static bool isMigration = true;

    //    public DbSet<Product> Products { get; set; }

    //    public void ConfigureServices(IServiceCollection services)
    //    {

    //        //optionsBuilder.UseSqlServer("Data Source=ggraur;Database=Bakery;User Id=sa;Password=260707Gruita;Trusted_Connection=True;MultipleActiveResultSets=true;");

    //        //services.AddDbContext<BakeryContext>(optionsBuilder =>
    //        //{
    //        //    optionsBuilder.UseSqlServer("Data Source=ggraur;Database=Bakery;User Id=sa;Password=260707Gruita;Trusted_Connection=True;MultipleActiveResultSets=true;");

    //        //});
    //    }


    //    protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        // TODO: This is messy, but needed for migrations.
    //        // See https://github.com/aspnet/EntityFramework/issues/639
    //        if (isMigration)
    //        {
    //            optionsBuilder.UseSqlServer("Data Source=ggraur;Database=Bakery;User Id=sa;Password=260707Gruita;Trusted_Connection=True;MultipleActiveResultSets=true;");
    //        }
    //    }
    //    protected  void OnModelCreating(ModelBuilder modelBuilder)
    //    {

    //       // modelBuilder.ApplyConfiguration(new ProductConfiguration());


    //        // modelBuilder.ApplyConfiguration(new ProductConfiguration());

    //        //   modelBuilder.Entity<Product>()
    //        //.ForRelational(builder => builder.Table("Product"))
    //        //.Property(value => value.ID)
    //        //.Property(value => value.Description).MaxLength(255)
    //        //.Property(value => value.Price).MaxLength(255)
    //        //.Property(value => value.ImageName).MaxLength(255);


    //    }


    //}
}
