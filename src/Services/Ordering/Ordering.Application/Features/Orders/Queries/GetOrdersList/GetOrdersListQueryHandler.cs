using AutoMapper;
using MediatR;
using Ordering.Application.Contracts.Persistence.Repository;
using Ordering.Application.ViewModel;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, List<OrdersVM>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper ;

        public GetOrdersListQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<OrdersVM>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            var vm= await _orderRepository.GetOrdersByUserName(request.UserName);
            return _mapper.Map<List<OrdersVM>>(vm);
        }
    }
}
