using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;

namespace Ordering.API.EventBusConsumer
{
    public class BasketCheckOutConsumer : IConsumer<BasketCheckoutEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<BasketCheckOutConsumer> _logger;

        public BasketCheckOutConsumer(IMediator mediator, IMapper mapper, ILogger<BasketCheckOutConsumer> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            CheckoutOrderCommand command = _mapper.Map<CheckoutOrderCommand>(context.Message);
            var result2 = await _mediator.Send(command);

            _logger.LogInformation("BasketCheckoutEvent consumed successfully. Created Order Id : {newOrderId}", result2);

        }
    }
}
