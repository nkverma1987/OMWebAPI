using OrderManagement.Database;
using System.Collections.Generic;

namespace OrderManagement.Models
{
    public class SQLOrderRepository : IOrderRepository
    {
        private readonly DatabaseContext _dbContext;
        public SQLOrderRepository(DatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public OrderLink AddOrder(OrderLink orderLink)
        {
           _dbContext.OrderLink.Add(orderLink);
            _dbContext.SaveChanges();
            return orderLink;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _dbContext.Orders;
        }
    }
}
