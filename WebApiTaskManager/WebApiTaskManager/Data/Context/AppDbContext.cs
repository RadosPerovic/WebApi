using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApiTaskManager.Domain.Models;

namespace WebApiTaskManager.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Task>  Tasks { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
       
            modelBuilder.Entity<Project>().HasKey(p => p.ID);

            modelBuilder.Entity<Project>().HasData(
                new Project { ID = 11, Name = "WebApi", Description = "Ovo je projekat iz EF Code first" },
                new Project { ID = 12, Name = "InformationSystem", Description = "Ovo je projekat iz EF Code first" },
                new Project { ID = 13, Name = "ERP", Description = "Ovo je projekat iz EF Code first" },
                new Project { ID = 14, Name = "CMS", Description = "Ovo je projekat iz EF Code first" }
                ) ;

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Members)
                .WithOne(m => m.Project)
                .HasForeignKey(p => p.ProjectID);
            modelBuilder.Entity<Project>()
                .HasMany(p => p.Tasks)
                .WithOne(m => m.Project)
                .HasForeignKey(p => p.ProjectID);

            modelBuilder.Entity<Member>().HasKey(p => p.ID);
            modelBuilder.Entity<Member>()
                .HasMany(p => p.Tasks)
                .WithOne(m => m.Member)
                .HasForeignKey(p => p.MemberID);

            modelBuilder.Entity<Member>().HasData(
            new Member { ID = 21, Name = "Rados", Surname = "Perovic", ProjectID = 11 },
            new Member { ID = 22, Name = "Marko", Surname = "Nikolic", ProjectID = 12 },
            new Member { ID = 23, Name = "Nikola", Surname = "Stefanovic", ProjectID = 13 },
            new Member { ID = 24, Name = "Milica", Surname = "Spasic2", ProjectID = 14 },
            new Member { ID = 25, Name = "Rados2", Surname = "Perovic2", ProjectID = 11 },
            new Member { ID = 26, Name = "Marko2", Surname = "Nikolic2", ProjectID = 12 },
            new Member { ID = 27, Name = "Nikola2", Surname = "Stefanovic2", ProjectID = 13 },
            new Member { ID = 28, Name = "Milica2", Surname = "Spasic2", ProjectID = 14 }
            );  


            modelBuilder.Entity<Task>().HasKey(p => p.ID);

        }


    }
}
