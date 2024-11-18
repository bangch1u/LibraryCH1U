using LibraryData.Data;
using LibraryData.ViewModel;

namespace LibraryAPI.Services
{
    public interface ICustomerService
    {
        List<Customer> getAll();
        Customer getById(Guid id);
        void createCus(CustomerVM customer);
        void updateCus(Guid id, CustomerVM customer);
        void deleteCus(Guid id);

    }
}
