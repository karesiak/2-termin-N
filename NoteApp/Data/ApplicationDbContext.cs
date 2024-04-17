using Microsoft.EntityFrameworkCore;
using NoteApp.Models; // Dodaj tę linię na górze pliku ApplicationDbContext.cs


namespace NoteApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
    }
}
