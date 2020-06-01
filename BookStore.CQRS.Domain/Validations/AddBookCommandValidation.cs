using BookStore.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.CQRS.Validations
{
    /// <summary>
    /// 添加书籍的验证器。
    /// </summary>
    public class AddBookCommandValidation : BookValidation<AddBookCommand>
    {
        public AddBookCommandValidation()
        {
            ValidateTitle();
            ValidateName();
            ValidateDescription();
            ValidatePublishingHouse();
            ValidatePublicTime();
        }
    }
}
