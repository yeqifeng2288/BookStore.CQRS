using BookStore.CQRS.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.CQRS.Commands
{
    public abstract class BookCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Title { get; protected set; }

        // 作者信息
        public Guid AuthorId { get; protected set; }

        public string Name { get; protected set; }


        // 书籍信息。
        public DateTime PublishTime { get; protected set; }

        /// <summary>
        /// 简述。
        /// </summary>
        public string Description { get; protected set; }

        /// <summary>
        /// 出版社。
        /// </summary>
        public string PublishingHouse { get; protected set; }

        /// <summary>
        /// 价格。
        /// </summary>
        public decimal Price { get; protected set; }
    }
}
