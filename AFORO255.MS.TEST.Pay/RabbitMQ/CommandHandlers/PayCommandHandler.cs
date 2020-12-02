﻿using AFORO255.MS.TEST.Pay.RabbitMQ.Commands;
using AFORO255.MS.TEST.Pay.RabbitMQ.Events;
using MediatR;
using MS.AFORO255.Cross.RabbitMQ.Src.Bus;
using System.Threading;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Pay.RabbitMQ.CommandHandlers
{
    public class PayCommandHandler : IRequestHandler<PayCommand, bool>
    {
        private readonly IEventBus _bus;

        public PayCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(PayCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new PayCreatedEvent(
                request.Id_Operation,
                request.Id_Invoice,
                request.Amount,
                request.Date
            ));

            return Task.FromResult(true);
        }
    }
}
