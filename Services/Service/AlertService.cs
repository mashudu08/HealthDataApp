using HealthDataApp.Data;
using HealthDataApp.Models;
using HealthDataApp.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace HealthDataApp.Services.Service
{
    public class AlertService : IAlertService
    {
        private readonly AppDbContext _context;

        public AlertService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Alert>> GetAlertsAsync()
        {
            return await _context.Alerts.ToListAsync();
        }

        public async Task<Alert> GetAlertByIdAsync(int id)
        {
            return await _context.Alerts.FindAsync(id);
        }

        public async Task AddAlertAsync(Alert alert)
        {
            _context.Alerts.Add(alert);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAlertAsync(Alert alert)
        {
            _context.Entry(alert).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAlertAsync(int id)
        {
            var alert = await _context.Alerts.FindAsync(id);
            _context.Alerts.Remove(alert);
            await _context.SaveChangesAsync();
        }

    }
}
