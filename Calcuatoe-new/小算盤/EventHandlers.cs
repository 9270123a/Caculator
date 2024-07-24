using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 小算盤
{
    internal class EventHandlers
    {
        public static event EventHandler<double> ResultEvent;

        public static void NotifyEvent(double number)
        {
            ResultEvent.Invoke(null, number);
        }

    }
}
