using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.CQRS.Books
{
    public class Book
    {
        public Book()
        {
        }

        public Book(Guid id, string title, Author author, BookInfo bookInfo)
        {
            this.Id = id;
            this.Title = title;
            this.BookInfo = bookInfo;
            this.Author = author;
        }

        public Guid Id { get; private set; }

        /// <summary>
        /// 书名。
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// 作者。
        /// </summary>
        public Author Author { get; set; }

        /// <summary>
        /// 书信息。
        /// </summary>
        public BookInfo BookInfo { get; private set; }
    }
}
