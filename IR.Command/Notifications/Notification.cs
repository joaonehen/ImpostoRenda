using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IR.Command.Notifications
{
    public class Notification: INotification
    {
        public Notification(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; private set; }
        public string Value { get; private set; }
        
    }
}
