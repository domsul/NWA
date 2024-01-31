using Microsoft.EntityFrameworkCore;
using NotesAPI.Models;
using System.Configuration;

namespace NotesAPI.Data
{
    public class NotesContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["NotesDatabase"].ConnectionString;

                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>().ToTable("Notes");
            modelBuilder.Entity<Note>().HasKey(n => n.Id);
        }
    }
}
