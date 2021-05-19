using KhoaLuan.Data.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string Code { get; set; }
        public string Card { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public bool AccountType { get; set; }
        public string PathImage { get; set; }
        public JobStatus JobStatus { get; set; }

        public List<ProcessPlan> ProcessPlanAuthority { get; set; }
        public List<ProcessPlan> ProcessPlanCreators { get; set; }
        public List<ProcessPlan> ProcessPlanResponsibles { get; set; }
        public List<OrderPlan> OrderPlanCreators { get; set; }
        public List<OrderPlan> OrderPlanResponsible { get; set; }
        public List<OrderPlan> OrderPlanAuthority { get; set; }
        public List<Bill> Bills { get; set; }
    }
}