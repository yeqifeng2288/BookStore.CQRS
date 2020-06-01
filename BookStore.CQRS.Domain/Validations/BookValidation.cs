using BookStore.CQRS.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BookStore.CQRS.Validations
{
    /// <summary>
    /// Book类的验证抽象类。继承自FluentValidation。用于书籍方法验证器选择方法进行验证。
    /// </summary>
    /// <typeparam name="T">用于验证的命令。</typeparam>
    public abstract class BookValidation<T> : AbstractValidator<T> where T : BookCommand
    {
        /// <summary>
        /// 验证书名不能为空。
        /// </summary>
        protected void ValidateTitle()
        {
            RuleFor(o => o.Title)
                .MaximumLength(30).WithMessage("书名长度不能超过30")
                .NotEmpty().WithMessage("书名不能为空")
                .Length(1, 30).WithMessage("书名长度必须在2到30之间。");
        }

        /// <summary>
        /// 验证作者名字。
        /// </summary>
        protected void ValidateName()
        {
            RuleFor(o => o.Name)
                .Length(1, 30).WithMessage("作者名长度不能少于2，不能大于30");
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
                .Length(100, 10000).WithMessage("简述长度不能小于100，且不能大于10000");
        }

        /// <summary>
        /// 验证出版社。
        /// </summary>
        protected void ValidatePublishingHouse()
        {
            RuleFor(o => o.PublishingHouse)
                .NotEmpty().WithMessage("出版社不能为空");
        }
    }
}
