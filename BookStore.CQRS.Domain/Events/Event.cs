using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.CQRS.Events
{
    public abstract class Event : INotification
    {
    }
}
