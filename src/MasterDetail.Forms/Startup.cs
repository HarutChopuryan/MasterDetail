using Grace.DependencyInjection;
using Grace.DependencyInjection.Lifestyle;
using MasterDetail.Forms.Pages;

namespace MasterDetail.Forms
{
    public static class Startup
    {
        public static DependencyInjectionContainer RegisterFormsDependencies(
            this DependencyInjectionContainer container)
        {
            container.Add(block => block.Export<DropBoxFilesPage>().UsingLifestyle(new SingletonLifestyle()));
            container.Add(block => block.Export<SelectedItemDetailsPage>().UsingLifestyle(new SingletonLifestyle()));
            container.Add(block => block.Export<MapPage>().UsingLifestyle(new SingletonLifestyle()));
            return container;
        }
    }
}