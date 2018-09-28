using System.Linq;
using MasterDetail.Core.EFCore;
using MasterDetail.Core.EFCore.Models;

namespace MasterDetail.Core.Services.Implementation
{
    public class ImageRepository : Repository<Image>, IImageRepository
    {
        public ImageRepository(ImageContext context) : base(context)
        {
        }

        public ImageContext ImageContext => Context as ImageContext;

        public void DeleteById(int id)
        {
            var img = ImageContext.UserDropbox.Find(id);
            ImageContext.UserDropbox.Remove(img);
            ImageContext.SaveChanges();
        }

        public void Clear()
        {
            ImageContext.UserDropbox.Local.Clear();
        }

        public bool HasItems()
        {
            return ImageContext.UserDropbox.Any();
        }
    }
}