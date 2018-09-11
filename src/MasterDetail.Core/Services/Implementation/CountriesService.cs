using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MasterDetail.Core.Models;

namespace MasterDetail.Core.Services.Implementation
{
    public class CountriesService : ICountriesService
    {
        private readonly IDataClient _dataClient;

        public CountriesService(IDataClient dataClient)
        {
            _dataClient = dataClient;
        }

        public Task<List<Country>> GetCountriesAsync(CancellationToken token = default(CancellationToken))
        {
            return _dataClient.GetAsync<List<Country>>("all", token);
        }
    }
}