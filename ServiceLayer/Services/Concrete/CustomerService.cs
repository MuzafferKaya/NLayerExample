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
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _unitOfWork.GetRepository<Customer>().GetAllAsync();
        }

        public async Task UpdateCustomerAsync(Customer customer, int id)
        {
            var customers = await _unitOfWork.GetRepository<Customer>().GetByIdAsync(id);

            customers.FirstName = customer.FirstName;
            customers.LastName = customer.LastName;
            
            await _unitOfWork.GetRepository<Customer>().Update(customers);
            await _unitOfWork.SaveAsync();
        }
    }
}
