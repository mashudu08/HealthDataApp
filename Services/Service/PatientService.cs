using HealthDataApp.Data;
using HealthDataApp.Models;
using HealthDataApp.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace HealthDataApp.Services.Service
{
    public class PatientService : IPatientService
    {
        private readonly AppDbContext _context;

        public PatientService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetPatientsAsync()
        {
            return await _context.Patients.ToListAsync();
        }
        public async Task<Patient> GetPatiendByIdAsync(int id)
        {
            return await _context.Patients.FindAsync(id);
        }
        public async Task AddPatientAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePatientAsync(Patient patient)
        {
            _context.Entry(patient).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePatientAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

        }
    }
}
