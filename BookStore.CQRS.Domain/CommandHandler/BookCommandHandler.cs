using BookStore.CQRS.Bus;
using BookStore.CQRS.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.CQRS.CommandHandler
{
    public class BookCommandHandler : CommandHandler,IRequestHandler<AddBookCommand,bool>
    {
        public BookCommandHandler(IMediatorHandler bus) : base(bus)
        {
        }

        /// <summary>
        /// 具体业务逻辑写在这里。
        /// </summary>
        /// <param name="request">请求。</param>
        /// <param name="cancellationToken">取消Token。</param>
        /// <returns></returns>
        public Task<bool> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {

            return Task.FromResult(true);
        }
    }
}
