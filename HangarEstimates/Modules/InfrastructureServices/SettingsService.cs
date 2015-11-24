using System.Configuration;
using HangarEstimates.Infrastructure.Interfaces.Services;

namespace HangarEstimates.Modules.InfrastructureServices
{
    public class SettingsService : ISettingsService
    {
        public string GetDataBaseConnectionString()
        {
            var appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            return appConfig.ConnectionStrings.ConnectionStrings["DbConnectionString"].ConnectionString;
        }
    }
}
