using HealthDataApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace HealthDataApp.Services.Interface
{
    public interface IAlertService
    {
        Task<IEnumerable<Alert>> GetAlertsAsync();
        Task<Alert> GetAlertByIdAsync(int id);
        Task AddAlertAsync(Alert alert);
        Task UpdateAlertAsync(Alert alert);
        Task DeleteAlertAsync(int id);

    }
}
