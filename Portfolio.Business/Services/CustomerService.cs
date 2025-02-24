using Microsoft.AspNetCore.Hosting;
using Portfolio.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Services
{
    public class CustomerService : ICustomer
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddCustomerAsync(CustomerVModel customerVModel)
        {
            await _unitOfWork.CustomerRepository.AddAsync(_mapper.Map<Customer>(customerVModel));

        }

        public async Task<OprationStatusModel> DeleteCustomerAsync(int Id)
        {
            var oprationStatus = new OprationStatusModel();
            var customer = await _unitOfWork.CustomerRepository.GetByIDAsync(Id);
            if (customer is not null)
            {
                await _unitOfWork.CustomerRepository.DeleteAsync(customer);
                oprationStatus.Status = true;
                return oprationStatus;
            }
            oprationStatus.Message = "Customer not found";
            return oprationStatus;
        }

        public async Task<IEnumerable<CustomerVModel>> GetAllCustomersAsync()
        {
            var customers = await _unitOfWork.CustomerRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<CustomerVModel>>(customers);
            return result;
        }

        public async Task<CustomerVModel> GetCustomerAsync(int Id)
        {
            var customer = await _unitOfWork.CustomerRepository.GetByIDAsync(Id);
            var result = _mapper.Map<CustomerVModel>(customer);
            return result;
        }

        public async Task UpdateCustomerAsync(CustomerVModel customerVModel)
        {
            var customer = _mapper.Map<Customer>(customerVModel);
            await _unitOfWork.CustomerRepository.UpdateAsync(customer, c => c.Id == customerVModel.Id);

        }
    }
}
