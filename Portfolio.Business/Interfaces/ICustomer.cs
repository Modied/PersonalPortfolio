using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Interfaces
{
    public interface ICustomer
    {
        Task<CustomerVModel> GetCustomerAsync(int Id);
        Task<IEnumerable<CustomerVModel>> GetAllCustomersAsync();
        Task AddCustomerAsync(CustomerVModel customerVModel);
        Task UpdateCustomerAsync(CustomerVModel customerVModel);
        Task<OprationStatusModel> DeleteCustomerAsync(int Id);
    }
}
