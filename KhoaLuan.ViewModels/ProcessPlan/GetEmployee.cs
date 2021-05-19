using System;

namespace KhoaLuan.ViewModels.ProcessPlan
{
    public class GetEmployee
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Card { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}