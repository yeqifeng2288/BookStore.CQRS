using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.CQRS.Notifications
{
    /// <summary>
    /// 通知助手。
    /// </summary>
    public class NotificationHandler : NotificationHandler<Notification>
    {
        private readonly List<Notification> _notifications;

        public NotificationHandler()
        {
            _notifications = new List<Notification>();
        }

        protected override void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        // 获取当前生命周期内的全部通知信息
        public virtual List<Notification> GetNotifications()
        {
            return _notifications;
        }

        /// <summary>
        ///  判断在当前总线对象周期中，是否存在通知信息。
        /// </summary>
        /// <returns></returns>
        public virtual bool HasNotifications()
        {
            return GetNotifications().Any();
        }

        /// <summary>
        /// 清空通知。
        /// </summary>
        public void Clear()
        {
            _notifications.Clear();
        }
    }
}
