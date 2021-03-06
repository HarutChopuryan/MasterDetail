﻿using Grace.DependencyInjection;
using Grace.DependencyInjection.Lifestyle;
using MasterDetail.Core.DI;
using MasterDetail.Core.EFCore;
using MasterDetail.Core.Services.Implementation;
using MasterDetail.UI.Main;
using MasterDetail.UI.Main.Implementation;

namespace MasterDetail.UI
{
    public static class Startup
    {
        public static DependencyInjectionContainer RegisterUIDependencies(this DependencyInjectionContainer container)
        {
            container.Add(block => block.Export<UserViewModel>().As<IUserViewModel>().UsingLifestyle(new SingletonLifestyle()));
            container.Add(block => block.Export<UserImagesViewModel>().As<IUserImagesViewModel>().UsingLifestyle(new SingletonLifestyle()));
            container.Add(block => block.Export<SelectedItemDetailsViewModel>().As<ISelectedItemDetailsViewModel>().UsingLifestyle(new SingletonLifestyle()));
            container.Add(block => block.Export<CountryPickerViewModel>().As<ICountryPickerViewModel>().UsingLifestyle(new SingletonLifestyle()));
            return container;
        }
    }
}