using BookStore.CQRS.Commands;
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
    }
}
