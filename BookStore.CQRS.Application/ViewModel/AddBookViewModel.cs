using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BookStore.CQRS.ViewModel
{
    public class AddBookViewModel
    {
        [DisplayName("书名")]
        public string Title { get; protected set; }

        [DisplayName("作者名字")]
        public string Name { get; protected set; }

        [DisplayName("发布时间")]
        public DateTime PublishTime { get; protected set; }

        [DisplayName("简述")]
        public string Description { get; protected set; }

        [DisplayName("出版社")]
        public string PublishingHouse { get; protected set; }

        [DisplayName("零售价")]
        public decimal Price { get; protected set; }
    }
}
