using System;
using System.Collections.Generic;
using System.Text;

namespace MasterDetail.Core.Services
{
    public interface IDbWork : IDisposable
    {
        IImageRepository Images { get; }

        int Complete();
    }
}