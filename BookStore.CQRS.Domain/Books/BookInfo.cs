using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.CQRS.Books
{
    public class BookInfo
    {
        public BookInfo()
        {

        }

        public BookInfo(DateTime publishTIme, string description, string publishingHouse, decimal price)
        {
            PublishTIme = publishTIme;
            Description = description;
            PublishingHouse = publishingHouse;
            Price = price;
        }

        public DateTime PublishTIme { get; private set; }

        /// <summary>
        /// 简述。
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// 出版社。
        /// </summary>
        public string PublishingHouse { get; set; }

        /// <summary>
        /// 价格。
        /// </summary>
        public decimal Price { get; private set; }
    }
}
