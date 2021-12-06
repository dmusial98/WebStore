using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using WebStore.Data;

namespace CoreCodeCamp.Data
{
  public class WebStoreContextFactory : IDesignTimeDbContextFactory<WebStoreContext>
  {
    public WebStoreContext CreateDbContext(string[] args)
    {
      var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

      return new WebStoreContext(new DbContextOptionsBuilder<WebStoreContext>().Options, config);
    }
  }
}
