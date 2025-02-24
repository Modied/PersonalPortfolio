using Portfolio.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Interfaces
{
    public interface IService
    {

        Task<IEnumerable<ServiceVModel>> GetAllServicesAsync();
        Task<ServiceVModel> GetServiceByIdAsync(int id);
        Task AddServiceAsync(ServiceVModel service);
        Task UpdateServiceAsync(ServiceVModel service);
        Task<OprationStatusModel> DeleteServiceAsync(int id);


    }
}
