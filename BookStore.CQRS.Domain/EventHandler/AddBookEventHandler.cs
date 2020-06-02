using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.CQRS.Events
{
    /// <summary>
    /// 添加书本后的领域事件。
    /// </summary>
    public class AddBookEventHandler : INotificationHandler<AddBookEvent>
    {
        public Task Handle(AddBookEvent notification, CancellationToken cancellationToken)
        {
            // 发送邮件，短信等在此处执行。
            return Task.CompletedTask;
        }
    }
}
