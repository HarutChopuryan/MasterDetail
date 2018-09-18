using System;
using System.Collections.Generic;
using System.Text;

namespace MasterDetail.Core.Services
{
    public interface IPath
    {
        string GetDatabasePath(string filename);
    }
}