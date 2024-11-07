using HealthDataApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthDataApp.Services.Interface
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetPatientsAsync();
        Task<Patient> GetPatiendByIdAsync(string id);
        Task AddPatientAsync(Patient patient);
        Task UpdatePatientAsync(Patient patient);
        Task DeletePatientAsync(string id);

    }
}
