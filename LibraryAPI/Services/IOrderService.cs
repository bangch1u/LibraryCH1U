using LibraryAPI.Repositories;
using LibraryData.Data;
using LibraryData.ViewModel;

namespace LibraryAPI.Services
{
    public interface IOrderService
    {
        bool CreateOrder(List<BookOrderVM> Books);
    }
}
