using System;
using Grace.DependencyInjection;
using Grace.DependencyInjection.Lifestyle;
using MasterDetail.Core.EFCore;
using MasterDetail.Core.EFCore.Models;
using MasterDetail.Core.Services;
using MasterDetail.Core.Services.Implementation;

namespace MasterDetail.Core
{
    public static class Startup
    {
        public static DependencyInjectionContainer RegisterCoreDependencies(this DependencyInjectionContainer container)
        {
            container.Add(block => block.Export<WebDataClient>().As<IDataClient>().UsingLifestyle(new SingletonLifestyle()));
            container.Add(block => block.Export<CountriesService>().As<ICountriesService>());
            container.Add(block => block.Export<ImageRepository>().As<IRepository<Image>>().UsingLifestyle(new SingletonLifestyle()));

            return container;
        }
    }
}