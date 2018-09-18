using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Image = MasterDetail.Core.EFCore.Models.Image;

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