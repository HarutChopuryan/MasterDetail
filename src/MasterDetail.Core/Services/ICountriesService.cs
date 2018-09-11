using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MasterDetail.Core.Models;

namespace MasterDetail.Core.Services
{
    public interface ICountriesService
    {
        Task<List<Country>> GetCountriesAsync(CancellationToken token = default(CancellationToken));
    }
}