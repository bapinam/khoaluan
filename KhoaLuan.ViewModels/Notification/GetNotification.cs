using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.Notification
{
    public class GetNotification
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public bool View { get; set; }
        public int Time { get; set; }
        public int Count { get; set; }
        public Guid IdReceiver { get; set; }
        public string NameReceiver { get; set; }
    }
}