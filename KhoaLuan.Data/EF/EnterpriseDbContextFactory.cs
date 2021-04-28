using KhoaLuan.Utilities.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace KhoaLuan.Data.EF
{
    public class EnterpriseDbContextFactory : IDesignTimeDbContextFactory<EnterpriseDbContext>
    {
        public EnterpriseDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString(SystemConstants.MainConectionString);

            var optionsBuilder = new DbContextOptionsBuilder<EnterpriseDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new EnterpriseDbContext(optionsBuilder.Options);
        }
    }
}