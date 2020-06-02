using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.CQRS.ViewModel.FluentValidationConfig
{
    /// <summary>
    /// 特性写到手软，FluentValidation吧。
    /// </summary>
    public class AddBookViewModelValidation : AbstractValidator<AddBookViewModel>
    {
        public AddBookViewModelValidation()
        {
            ValidatePublicTime();
            ValidateDescription();
            ValidatePublishingHouse();
            ValidatePrice();
        }

        /// <summary>
        /// 验证发布日期。
        /// </summary>
        protected void ValidatePublicTime()
        {
            RuleFor(o => o.PublishTime)
                .Must(date => date < DateTime.Now).WithMessage("发布时间不能大于当前时间!");
        }

        /// <summary>
        /// 验证简述。
        /// </summary>
        protected void ValidateDescription()
        {
            RuleFor(o => o.Description)
                .Length(10, 10000).WithMessage("简述长度不能小于10，且不能大于10000");
        }

        /// <summary>
        /// 验证出版社。
        /// </summary>
        protected void ValidatePublishingHouse()
        {
            RuleFor(o => o.PublishingHouse)
                .NotEmpty().WithMessage("出版社不能为空");
        }

        /// <summary>
        /// 验证价格。
        /// </summary>
        protected void ValidatePrice()
        {
            RuleFor(o => o.Price)
                .Must(o => o > 0)
                .WithMessage("价格必须大于0!");
        }
    }
}
