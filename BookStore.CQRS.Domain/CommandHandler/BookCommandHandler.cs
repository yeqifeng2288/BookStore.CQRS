using BookStore.CQRS.Bus;
using BookStore.CQRS.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.CQRS.Books;
using Microsoft.EntityFrameworkCore;
using BookStore.CQRS.Events;

namespace BookStore.CQRS.CommandHandler
{
    public class BookCommandHandler : CommandHandler, IRequestHandler<AddBookCommand, bool>
    {
        private readonly IMediatorHandler _bus;
        private readonly IMapper _mapper;
        private readonly DbContext _dbContext;

        public BookCommandHandler(IMediatorHandler bus, IMapper mapper, DbContext dbContext) : base(bus)
        {
            _bus = bus;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        /// <summary>
        /// 具体业务逻辑写在这里。
        /// </summary>
        /// <param name="request">请求。</param>
        /// <param name="cancellationToken">取消Token。</param>
        /// <returns></returns>
        public Task<bool> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            // 验证是否通过。
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }

            var book = _mapper.Map<Book>(request);
            _dbContext.Add(book);

            _dbContext.SaveChanges();

            _bus.RaiseEvent(new AddBookEvent(book.Id, book.Title));

            return Task.FromResult(true);
        }
    }
}
