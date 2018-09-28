using System.ComponentModel.DataAnnotations;
using System.IO;

namespace MasterDetail.Core.EFCore.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        public byte[] ImageSource { get; set; }

        public string ImageName { get; set; }
    }
}