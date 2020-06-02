using BookStore.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.CQRS.Notifications
{
    /// <summary>
    /// 通知本身也是一个事件。
    /// </summary>
    public class Notification : Event
    {
        public Notification(string key, string value)
        {
            DomainNotificationId = Guid.NewGuid();
            Key = key;
            Value = value;
        }

        // 标识
        public Guid DomainNotificationId { get; private set; }

        // 键（可以根据这个key，获取当前key下的全部通知信息）
        public string Key { get; private set; }

        // 值（与key对应）
        public string Value { get; private set; }
    }
}
