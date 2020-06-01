using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.CQRS.Commands
{
    public abstract class Command : IRequest<bool>
    {

        /// <summary>
        /// 验证结果。
        /// </summary>
        public ValidationResult ValidationResult { get; set; }

        /// <summary>
        /// 验证数据。
        /// </summary>
        /// <returns></returns>
        public abstract bool IsValid();
    }
}
