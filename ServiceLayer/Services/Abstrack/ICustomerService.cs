using EntityLayer.Entities;

namespace ServiceLayer.Services.Abstrack
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomersAsync();
        Task CreateCustomerAsync(Customer customer);
    }
}
