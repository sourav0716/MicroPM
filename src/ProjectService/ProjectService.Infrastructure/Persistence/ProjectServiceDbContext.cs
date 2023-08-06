using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectService.Domain.Entity;
using ProjectService.Infrastructure.Persistence.Configurations;

namespace ProjectService.Infrastructure.Persistence
{
    public class ProjectServiceDbContext : DbContext
    {
        public ProjectServiceDbContext(DbContextOptions<ProjectServiceDbContext> options)
        : base(options)
        {
        }

        public DbSet<Project>? Projects { get; set; }
        public DbSet<Component>? Components { get; set; }
        public DbSet<ProjectUser>? ProjectUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new ComponentConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectUserConfiguration());
        }

    }



}