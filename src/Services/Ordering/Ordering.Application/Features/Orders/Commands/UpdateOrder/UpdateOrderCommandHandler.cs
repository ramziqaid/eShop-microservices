using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Infrastructure;
using Ordering.Application.Contracts.Persistence.Repository;
using Ordering.Application.Exceptions;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CheckoutOrderCommandHandler> _logger;
        private readonly IEmailService _emailService;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<CheckoutOrderCommandHandler> logger, IEmailService emailService)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order =await _orderRepository.GetByIdAsync(request.Id);
            if (order == null)
            {
                _logger.LogError($"Order {request.Id} not exixst in database");
                throw new NotFoundException(nameof(Order), request.Id);

            }
            _mapper.Map(request, order, typeof(UpdateOrderCommand), typeof(Order));
            await _orderRepository.UpdateAsync(order);
            _logger.LogInformation($"Order {request.Id} is updated");
            return Unit.Value;

        }
    }
}
