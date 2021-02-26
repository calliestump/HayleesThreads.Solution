using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace HayleesThreads.Models
{
  public class HayleesThreadsContextFactory : IDesignTimeDbContextFactory<HayleesThreadsContext>
  {
    HayleesThreadsContext IDesignTimeDbContextFactory<HayleesThreadsContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();
      
      var builder = new DbContextOptionsBuilder<HayleesThreadsContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new HayleesThreadsContext(builder.Options);
    }
  }
}