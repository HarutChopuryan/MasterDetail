using MasterDetail.Core.EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace MasterDetail.Core.EFCore
{
    public class ApplicationContext : DbContext
    {
        private readonly string _databasePath;

        public DbSet<Image> Friends { get; set; }

        public ApplicationContext(string databasePath)
        {
            _databasePath = databasePath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
    }
}