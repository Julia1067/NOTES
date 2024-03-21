using Microsoft.EntityFrameworkCore;

namespace NOTES.Data.Domain
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<NoteModel> Notes { get; set; }
    }
}
