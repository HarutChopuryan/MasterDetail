using MasterDetail.Core.EFCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasterDetail.Core.Services
{
    public interface IImageRepository : IRepository<Image>
    {
        void DeleteById(int id);

        void Clear();

        bool HasItems();
    }
}