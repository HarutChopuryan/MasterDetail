using MasterDetail.Core.EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace MasterDetail.Core.EFCore
{
    public sealed class ImageContext : DbContext
    {
        private readonly string _databasePath;

        public ImageContext(string databasePath)
        {
            _databasePath = databasePath;
            Database.EnsureCreated();
        }

        public DbSet<Image> UserDropbox { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
    }
}