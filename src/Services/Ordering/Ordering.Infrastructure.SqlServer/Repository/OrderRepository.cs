using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contracts.Persistence.Repository;
using Ordering.Domain.Entities;
using Ordering.Infrastructure.SqlServer.Persistence;
using Ordering.Infrastructure.SqlServer.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.SqlServer.Repository
{
    public class OrderRepository : RepositoryBase<Order>,IOrderRepository
    {
        public OrderRepository(OrderContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            var orderList = await _dbContext.Orders
                                .Where(o => o.UserName == userName)
                                .ToListAsync();
            return orderList;
        }
    }
}
