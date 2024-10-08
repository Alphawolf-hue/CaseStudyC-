using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

using Microsoft.Extensions.Configuration;
namespace DigitalAssetManagement.util
{
    internal static class DBConnectionUtil
    {
        private static IConfiguration _iconfiguration;

        static DBConnectionUtil()
        {
            GetAppSettingsFile();
        }

        private static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())// sets the base path where configuration file is located
                         .AddJsonFile("appsettings.json");// configuration should include  the configuration file named as appsettings,json 
            _iconfiguration = builder.Build();//build creates an Iconfiguration object which has data from Appsettings file



        }

        public static string GetConnString()
        {
            return _iconfiguration.GetConnectionString("DefaultConnection");
        }
    }
}
