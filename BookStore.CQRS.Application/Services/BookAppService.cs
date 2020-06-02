using AutoMapper;
using BookStore.CQRS.Books;
using BookStore.CQRS.Bus;
using BookStore.CQRS.Commands;
using BookStore.CQRS.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.CQRS.Services
{
    public class BookAppService : IBookAppService
    {
        /// <summary>
        /// 总线。
        /// </summary>
        private readonly IMediatorHandler _bus;
        private readonly IMapper _mapper;
        private readonly DbContext _dbContext;

        public BookAppService(IMediatorHandler mediatorHandler, IMapper mapper, DbContext dbContext)
        {
            _bus = mediatorHandler;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        /// <summary>
        /// 添加书籍。
        /// </summary>
        /// <param name="addBookViewModel"></param>
        public void AddBook(AddBookViewModel addBookViewModel)
        {
            var addBookCommand = _mapper.Map<AddBookCommand>(addBookViewModel);
            _bus.SendCommand(addBookCommand);
        }

        public IEnumerable<IndexBookViewModel> GetList()
        {
            return _mapper.Map<IEnumerable<IndexBookViewModel>>(_dbContext.Set<Book>().ToList());
        }
    }
}
