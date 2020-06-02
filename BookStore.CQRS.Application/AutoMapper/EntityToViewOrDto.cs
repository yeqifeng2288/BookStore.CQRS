using AutoMapper;
using BookStore.CQRS.Books;
using BookStore.CQRS.ViewModel;

namespace BookStore.CQRS.AutoMapper
{
    public class EntityToViewOrDto : Profile
    {
        public EntityToViewOrDto()
        {
            CreateMap<Book, IndexBookViewModel>()
                                .ForMember(d => d.Title, o => o.MapFrom(s => s.Title))
                .ForMember(d => d.Price, o => o.MapFrom(s => s.BookInfo.Price))
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id));
        }
    }
}
