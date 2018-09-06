using Grace.DependencyInjection;
using Grace.DependencyInjection.Lifestyle;
using MasterDetail.UI.Main;
using MasterDetail.UI.Main.Implementation;

namespace MasterDetail.UI
{
    public static class Startup
    {
        public static DependencyInjectionContainer RegisterUIDependencies(this DependencyInjectionContainer container)
        {
            container.Add(block => block.Export<UserViewModel>().As<IUserViewModel>().UsingLifestyle(new SingletonLifestyle()));
            return container;
        }
    }
}