using BookStore.CQRS.Bus;
using BookStore.CQRS.Commands;
using BookStore.CQRS.Notifications;
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
            foreach (var error in command.ValidationResult.Errors)
            {
                //将错误信息提交到事件总线，派发出去
                _bus.RaiseEvent(new Notification("", error.ErrorMessage));
            }

        }
    }
}
