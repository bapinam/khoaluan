using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.Data.Entities
{
    public class Notification
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public bool View { get; set; }
        public DateTime Time { get; set; }
        public AppUser Receiver { get; set; }
        public Guid IdReceiver { get; set; }
    }
}