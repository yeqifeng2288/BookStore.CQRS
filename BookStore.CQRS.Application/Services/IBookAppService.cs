using BookStore.CQRS.ViewModel;
using System.Collections.Generic;

namespace BookStore.CQRS.Services
{
    public interface IBookAppService
    {
        void AddBook(AddBookViewModel addBookViewModel);

        IEnumerable<IndexBookViewModel> GetList();
    }
}