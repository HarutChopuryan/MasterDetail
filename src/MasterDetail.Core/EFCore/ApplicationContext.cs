using MasterDetail.Core.EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace MasterDetail.Core.EFCore
{
    public class ApplicationContext : DbContext
    {
        private readonly string _databasePath;

        public ApplicationContext(string databasePath)
        {
            _databasePath = databasePath;
        }

        public DbSet<Image> UserDropbox { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
    }
}