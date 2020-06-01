using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.CQRS.Books
{
    public class Author
    {
        public Author()
        {
        }

        public Author(Guid id,string name)
        {
            this.Id = id;
            this.Name = name;
        }

        /// <summary>
        /// Id。
        /// </summary>
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
