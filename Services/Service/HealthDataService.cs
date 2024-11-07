using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HealthDataApp.Data;
using HealthDataApp.Models;
using HealthDataApp.Services.Interface;

namespace HealthDataApp.Services.Service
{
    public class HealthDataService : IHealthDataService
    {
      
            private readonly AppDbContext _context;

            public HealthDataService(AppDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<HealthData>> GetHealthDataAsync()
            {
                return await _context.HealthData.ToListAsync();
            }

            public async Task<HealthData> GetHealthDataByIdAsync(int id)
            {
                return await _context.HealthData.FindAsync(id);
            }

            public async Task AddHealthDataAsync(HealthData healthData)
            {
                _context.HealthData.Add(healthData);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateHealthDataAsync(HealthData healthData)
            {
                _context.Entry(healthData).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            public async Task DeleteHealthDataAsync(int id)
            {
                var healthData = await _context.HealthData.FindAsync(id);
                _context.HealthData.Remove(healthData);
                await _context.SaveChangesAsync();
            }

        }
    }
