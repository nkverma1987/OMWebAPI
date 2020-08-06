using System.Collections.Generic;

namespace OrderManagement.Models
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
        OrderLink AddOrder(OrderLink orderLink);
    }
}
