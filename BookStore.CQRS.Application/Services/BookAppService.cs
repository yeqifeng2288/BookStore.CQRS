using AutoMapper;
using BookStore.CQRS.Bus;
using BookStore.CQRS.Commands;
using BookStore.CQRS.ViewModel;
using System;
using System.Collections.Generic;
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

        public BookAppService(IMediatorHandler mediatorHandler, IMapper mapper)
        {
            _bus = mediatorHandler;
            _mapper = mapper;
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
    }
}
