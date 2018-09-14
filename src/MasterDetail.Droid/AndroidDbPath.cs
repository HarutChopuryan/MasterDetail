using MasterDetail.Core.Services;
using MasterDetail.Droid;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidDbPath))]

namespace MasterDetail.Droid
{
    internal class AndroidDbPath : IPath
    {
        public string GetDatabasePath(string filename)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), filename);
        }
    }
}