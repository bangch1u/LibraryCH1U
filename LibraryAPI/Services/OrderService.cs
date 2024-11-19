using LibraryAPI.Repositories;
using LibraryData.Data;
using LibraryData.ViewModel;

namespace LibraryAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Order> _orderRepos;
        private readonly IGenericRepository<Book> _bookRepos;
        private readonly IGenericRepository<OrderDetails> _orderDetailRepos;
        public OrderService(IGenericRepository<Order> orderRepos, IGenericRepository<Book> bookRepos, IGenericRepository<OrderDetails> orderDetailRepos)
        {
            _orderRepos = orderRepos;
            _bookRepos = bookRepos; 
            _orderDetailRepos = orderDetailRepos;
        }

       

        public bool CreateOrder(List<BookOrderVM> Books)
        {
            var order = new Order()
            {
                Id = Guid.NewGuid(),
                TotalQuantity = 0,
                TotalPrice = 0,
                Purchasetime = DateTime.Now,
                OrderDetails = new List<OrderDetails>(),
                Status = 0
            };
            _orderRepos.Insert(order);
            _orderRepos.Save();
            foreach (var item in Books)
            {
                var book = _bookRepos.GetById(item.BookId);
                if(book != null && book.stock > item.Quantity && book.stock != 0)
                {
                    var orderDetail = new OrderDetails()
                    {
                        OrderId = order.Id,
                        BookId = book.BookId,
                        Quantity = item.Quantity,
                        Book = book,
                        Order = order
                    };
                    _orderDetailRepos.Insert(orderDetail);
                    _orderDetailRepos.Save();

                    order.TotalQuantity += item.Quantity;
                    order.OrderDetails.Add(orderDetail);
                    _orderRepos.Update(order);
                    _orderRepos.Save();

                    book.stock -= item.Quantity;
                    _bookRepos.Update(book);
                    _bookRepos.Save();
                    return true;

                }
                else
                {
                    _orderRepos.Delete(order);
                    _orderRepos.Save();
                    return false;
                }
            }
            return true;

        }
    }
}
