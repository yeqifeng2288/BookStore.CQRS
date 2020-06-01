using BookStore.CQRS.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.CQRS.Commands
{
    /// <summary>
    /// 添加书籍命令。
    /// </summary>
    public class AddBookCommand : BookCommand
    {
        protected AddBookCommand(Guid id, string title, Guid authorId, string name, DateTime publishTIme, string description, string publishingHouse, decimal price)
        {
            Id = id;
            Title = title;
            AuthorId = authorId;
            Name = name;
            PublishTime = publishTIme;
            Description = description;
            PublishingHouse = publishingHouse;
            Price = price;
        }

        /// <summary>
        /// 验证是否通过。
        /// </summary>
        /// <returns>返回验证是否通过。</returns>
        public override bool IsValid()
        {
            return new AddBookCommandValidation().Validate(this).IsValid;
        }
    }
}
