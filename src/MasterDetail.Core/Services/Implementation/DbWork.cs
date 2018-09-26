using MasterDetail.Core.EFCore;

namespace MasterDetail.Core.Services.Implementation
{
    public class DbWork : IDbWork
    {
        private readonly ImageContext _context;

        public DbWork(ImageContext context)
        {
            _context = context;
            Images = new ImageRepository(_context);
        }

        public IImageRepository Images { get; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}