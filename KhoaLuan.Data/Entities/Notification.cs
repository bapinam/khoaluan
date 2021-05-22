using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        // cai nay la shadow properties, minh them vao trong entity de dung luon, cai nay ko anh huong den db, nho de attribute la NotMapped
        // lam nhu e thi co the tim hieu them AutoMapper
        //[NotMapped]
        //public int DurationDays => (DateTime.Now - Time).Days;
    }
}