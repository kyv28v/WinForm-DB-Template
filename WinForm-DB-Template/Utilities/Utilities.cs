using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WinForm_DB_Template.DB.Models;

namespace WinForm_DB_Template.Utilities
{
    internal static class Utilities
    {
        private static IConfigurationRoot? _appSettings = null;

        public static IConfigurationRoot GetAppSettings()
        {
            if (_appSettings == null)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(path: "appsettings.json");
                _appSettings = builder.Build();
            }

            return _appSettings;
        }

        public static TestContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TestContext>();
            optionsBuilder.UseNpgsql(GetAppSettings()["Database:ConnectionStrings"]);

            return new TestContext(optionsBuilder.Options); ;
        }
    }
}
