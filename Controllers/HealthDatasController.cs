using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HealthDataApp.Data;
using HealthDataApp.Models;

namespace HealthDataApp.Controllers
{
    public class HealthDatasController : Controller
    {
        private readonly AppDbContext _context;

        public HealthDatasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: HealthDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.HealthData.ToListAsync());
        }

        // GET: HealthDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthData = await _context.HealthData
                .FirstOrDefaultAsync(m => m.HealthDataId == id);
            if (healthData == null)
            {
                return NotFound();
            }

            return View(healthData);
        }

        // GET: HealthDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HealthDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HealthDataId,Timestamp,HeartRate,BloodPressure")] HealthData healthData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(healthData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(healthData);
        }

        // GET: HealthDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthData = await _context.HealthData.FindAsync(id);
            if (healthData == null)
            {
                return NotFound();
            }
            return View(healthData);
        }

        // POST: HealthDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HealthDataId,Timestamp,HeartRate,BloodPressure")] HealthData healthData)
        {
            if (id != healthData.HealthDataId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(healthData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HealthDataExists(healthData.HealthDataId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(healthData);
        }

        // GET: HealthDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var healthData = await _context.HealthData
                .FirstOrDefaultAsync(m => m.HealthDataId == id);
            if (healthData == null)
            {
                return NotFound();
            }

            return View(healthData);
        }

        // POST: HealthDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var healthData = await _context.HealthData.FindAsync(id);
            if (healthData != null)
            {
                _context.HealthData.Remove(healthData);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HealthDataExists(int id)
        {
            return _context.HealthData.Any(e => e.HealthDataId == id);
        }
    }
}
