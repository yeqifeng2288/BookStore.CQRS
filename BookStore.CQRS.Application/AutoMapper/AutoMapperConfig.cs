using AutoMapper;
using BookStore.CQRS.Commands;
using BookStore.CQRS.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace BookStore.CQRS.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            // 由ViewModel到添加书籍命令。
            CreateMap<AddBookViewModel, AddBookCommand>();
        }
    }
}
