using HangarEstimates.Infrastructure.Interfaces.Services;

namespace HangarEstimates.Test.Mocks
{
    public class MockSettingsService : ISettingsService
    {
        public MockSettingsService()
        {
            
        }

        public string GetDataBaseConnectionString()
        {
            return @"Data Source = HangarsDbTest.sdf";
        }
    }
}
