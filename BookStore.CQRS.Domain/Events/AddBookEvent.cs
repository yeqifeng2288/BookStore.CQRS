using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.CQRS.Events
{
    public class AddBookEvent : Event
    {
        /// <summary>
        /// 添加书本事件。
        /// </summary>
        /// <param name="id">Id。</param>
        /// <param name="title">标题。</param>
        public AddBookEvent(Guid id, string title)
        {
            Id = id;
            Title = title;
        }

        public Guid Id { get; set; }

        public string Title { get; private set; }
    }
}
