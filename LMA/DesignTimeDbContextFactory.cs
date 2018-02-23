using LMA.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LMA
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<LMADbContext>
    {
        public LMADbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<LMADbContext>();
            var connectionString = configuration.GetConnectionString("DbConnection");
            builder.UseSqlServer(connectionString);
            return new LMADbContext(builder.Options);
        }
    }
}
