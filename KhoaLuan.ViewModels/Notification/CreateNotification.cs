using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.ViewModels.Notification
{
    public class CreateNotification
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public DateTime Time { get; set; }
        public string NameReceiver { get; set; }
    }
}