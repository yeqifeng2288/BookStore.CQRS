using BookStore.CQRS.Bus;
using BookStore.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.CQRS.CommandHandler
{
    public abstract class CommandHandler
    {
        private readonly IMediatorHandler _bus;

        public CommandHandler(IMediatorHandler bus)
        {
            _bus = bus;
        }


        /// <summary>
        /// 收集命令验证中的错误信息。
        /// </summary>
        /// <param name="command">命令。</param>
        protected void NotifyValidationErrors(Command command)
        {
            var errors = new List<string>();
            foreach (var item in command.ValidationResult.Errors)
            {
                //将错误信息提交到事件总线，派发出去
            }
        }
    }
}
