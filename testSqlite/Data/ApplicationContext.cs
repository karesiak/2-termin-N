using Microsoft.EntityFrameworkCore;
using testSqlite.Models;

namespace testSqlite.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<FormData> Data { get; set; }

        // Usuń przesłonięcie OnConfiguring jeśli korzystasz z konstruktora z DbContextOptions
        // protected override void OnConfiguring(DbContextOptionsBuilder options)
        //     => options.UseSqlite("Data Source=app.db");
    }
}

