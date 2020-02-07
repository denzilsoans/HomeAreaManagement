using Microsoft.EntityFrameworkCore;
using DataAccess.DataModels;
using System;

namespace DataAccess.Domain
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
			//Seed Data
			modelBuilder.Entity<Area>().HasData(new Area
			{
				Id=1,
				Name = "Living Room",
				CreatedOn = DateTime.Now,
				CreatedById = 1,
				UpdatedOn = null,
				UpdatedById = null
			},
			new Area
			{
				Id=2,
				Name = "BedRoom",
				CreatedOn = DateTime.Now,
				CreatedById = 1,
				UpdatedOn = null,
				UpdatedById = null
			},
			new Area
			{
				Id=3,
				Name = "Kitchen Room",
				CreatedOn = DateTime.Now,
				CreatedById = 1,
				UpdatedOn = null,
				UpdatedById = null
			},
			new Area
			{
				Id=4,
				Name = "Dining Room",
				CreatedOn = DateTime.Now,
				CreatedById = 1,
				UpdatedOn = null,
				UpdatedById = null
			});
        }

        public DbSet<Area> Area { get; set; }
    }
}
