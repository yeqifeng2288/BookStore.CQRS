using BookStore.CQRS.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.CQRS.Bus
{
    internal class InMemoryBus : IMediatorHandler
    {
        private readonly Mediator _mediator;

        public InMemoryBus(Mediator mediator)
        {
            _mediator = mediator;
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            _mediator.Send(command);
            return Task.CompletedTask;
        }
    }
}
