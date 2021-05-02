using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.Utilities.Constants
{
    public class SystemConstants
    {
        public const string MainConectionString = "EnterpriseDb";

        public const string Bearer = "Bearer";

        public const string Collate_AI = "SQL_Latin1_General_CP1_CI_AI";

        public const string Collate_AS = "SQL_Latin1_General_CP1_CS_AS";

        public const string Environment = "ASPNETCORE_ENVIRONMENT";

        public const string ImageFolder = "product-content";

        public class AppSettings
        {
            public const string DefaultLanguageId = "DefaultLanguageId";
            public const string Token = "Token";
            public const string BaseAddress = "BaseAddress";
        }

        public class CustomClaimTypes
        {
            public const string Permission = "Application.Permission";
        }

        public class ListRole
        {
            public const string Admin = "Admin";

            public const string RecordsManagement = "RecordsManagement";
        }

        public class RecordsRoleClaims
        {
            public const string View = "recorads.view";
            public const string Add = "recorads.add";
            public const string Edit = "recorads.edit";
            public const string Reminder = "recorads.reminder";
        }

        public class EmployeeRoleClaims
        {
            public const string View = "employees.view";
            public const string Add = "employees.add";
            public const string Edit = "employees.edit";
        }

        public class AdminRoleClaims
        {
            public const string Admin = "admin.admin";
        }

        public class PolicyRecorads
        {
            public const string ViewRecorads = "policy.recorads.view";
            public const string AddRecorads = "policy.recorads.add";
            public const string EditRecorads = "policy.recorads.edit";
            public const string ReminderRecorads = "policy.recorads.reminder";

            public const string Recorads = "Recorads";
            public const string Admin = "Admin";
        }

        public class PolicyEmployee
        {
            public const string ViewEmployee = "policy.employees.view";
            public const string AddEmployee = "policy.employees.add";
            public const string EditEmployee = "policy.employees.edit";
        }
    }
}