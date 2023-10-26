using DataAccessLayer.UnitOfWorks;
using EntityLayer.Entities;
using ServiceLayer.Services.Abstrack;

namespace ServiceLayer.Services.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateCustomerAsync(Customer customer)
        {
            await _unitOfWork.GetRepository<Customer>().AddAsync(customer);
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _unitOfWork.GetRepository<Customer>().GetAllAsync();
        }
    }
}
