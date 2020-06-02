using AutoMapper;
using BookStore.CQRS.Books;
using BookStore.CQRS.Commands;
using BookStore.CQRS.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.CQRS.AutoMapper
{
    public class ViewOrDtoToEntity : Profile
    {
        public ViewOrDtoToEntity()
        {
            // 由ViewModel到添加书籍命令。
            CreateMap<AddBookViewModel, AddBookCommand>()
                .ConstructUsing(c => new AddBookCommand(new Guid(), c.Title, new Guid(), c.Name, c.PublishTime, c.Description, c.PublishingHouse, c.Price));

            CreateMap<AddBookCommand, Book>()
                .ConvertUsing(o => new Book(new Guid(), o.Title, new Author(new Guid(), o.Name), new BookInfo(o.PublishTime, o.Description, o.PublishingHouse, o.Price)));
        }
    }
}
