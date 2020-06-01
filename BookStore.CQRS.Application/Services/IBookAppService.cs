using BookStore.CQRS.ViewModel;

namespace BookStore.CQRS.Services
{
    public interface IBookAppService
    {
        void AddBook(AddBookViewModel addBookViewModel);
    }
}