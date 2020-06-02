using BookStore.CQRS.Commands;
using BookStore.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.CQRS.Bus
{
    /// <summary>
    /// 中介者助手。
    /// </summary>
    public interface IMediatorHandler
    {
        /// <summary>
        /// 使用Mediator的请求响应模式。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        Task SendCommand<T>(T command) where T : Command;

        /// <summary>
        /// 引发事件。
        /// </summary>
        /// <typeparam name="T">事件。</typeparam>
        /// <param name="event">具体事件</param>
        /// <returns></returns>
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
