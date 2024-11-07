using HealthDataApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace HealthDataApp.Services.Interface
{
    public interface IHealthDataService
    {
        Task<IEnumerable<HealthData>> GetHealthDataAsync();
        Task<HealthData> GetHealthDataByIdAsync(int id);
        Task AddHealthDataAsync(HealthData healthData);
        Task UpdateHealthDataAsync(HealthData healthData);
        Task DeleteHealthDataAsync(int id);

    }
}
