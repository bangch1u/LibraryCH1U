using LibraryAPI.Repositories;
using LibraryData.Data;
using LibraryData.ViewModel;

namespace LibraryAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IGenericRepository<Customer> _cusRepos;
        public CustomerService(IGenericRepository<Customer> cusRepos)
        {
                _cusRepos = cusRepos;
        }
        public void createCus(CustomerVM customer)
        {
            var cusNew = new Customer
            {
                CustomerName = customer.CustomerName,
                Address = customer.Address,
                CustomerId = Guid.NewGuid(),
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email,
                Status = customer.Status,
            };
            _cusRepos.Insert(cusNew);
            _cusRepos.Save();
        }

        public void deleteCus(Guid id)
        {
            _cusRepos.Delete(getById(id));
            _cusRepos.Save();
        }

        public List<Customer> getAll()
        {
            return _cusRepos.GetAll();
        }

        public Customer getById(Guid id)
        {
            return _cusRepos.GetById(id);
        }

        public void updateCus(Guid id, CustomerVM customer)
        {
            var cusNow = _cusRepos.GetById(id);
            if (cusNow != null)
            {
                cusNow.CustomerName = customer.CustomerName;
                cusNow.PhoneNumber = customer.PhoneNumber;
                cusNow.Address = customer.Address;
                cusNow.Email = customer.Email;
                customer.Status = customer.Status;
            }
            _cusRepos.Update(cusNow);
            _cusRepos.Save();
        }
    }
}
