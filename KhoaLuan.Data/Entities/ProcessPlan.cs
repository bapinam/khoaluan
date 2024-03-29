﻿using KhoaLuan.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.Data.Entities
{
    public class ProcessPlan
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpectedDate { get; set; }
        public string Note { get; set; }
        public StatusProcessPlan Status { set; get; }
        public bool Censorship { set; get; }
        public List<ProcessingDetail> ProcessingDetails { get; set; }
        public List<ProcessingVoucher> ProcessingVouchers { get; set; }

        public AppUser Creator { get; set; }
        public Guid IdCreator { get; set; }
        public AppUser Responsible { get; set; }
        public Guid IdResponsible { get; set; }
        public AppUser Authority { get; set; }
        public Guid? IdAuthority { get; set; }
    }
}