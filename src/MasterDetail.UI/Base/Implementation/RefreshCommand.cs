﻿using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MasterDetail.Core.EFCore;
using MasterDetail.Core.Services.Implementation;
using MasterDetail.UI.Main;
using MasterDetail.UI.Main.Implementation;
using Xamarin.Forms;

namespace MasterDetail.UI.Base.Implementation
{
    public class RefreshCommand : AsyncCommand
    {
        private readonly IUserViewModel _viewModel;

        public RefreshCommand(IUserViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        protected override Task<bool> ExecuteCoreAsync(object parameter = null,
            CancellationToken token = default(CancellationToken))
        {
            using (var work = new DbWork(new ImageContext(_viewModel.DbName)))
            {
                _viewModel.ImgItems.Clear();
                _viewModel.ImgItems = (from user in work.Images.GetAll()
                    select new UserImagesViewModel
                    {
                        ImageSource = ImageSource.FromStream(() => new MemoryStream(user.ImageSource)),
                        ImageName = user.ImageName
                    }).ToList();
                work.Complete();
            }
            return Task.FromResult(true);
        }
    }
}