﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlightApp.Data;
using FlightApp.Models;

namespace FlightApp.Controllers
{
    public class PassengerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PassengerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Passenger
        public async Task<IActionResult> Index()
        {
              return _context.Passenger != null ? 
                          View(await _context.Passenger.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Passenger'  is null.");
        }

        // GET: Passenger/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Passenger == null)
            {
                return NotFound();
            }

            var passenger = await _context.Passenger
                .FirstOrDefaultAsync(m => m.PassengerId == id);
            if (passenger == null)
            {
                return NotFound();
            }

            return View(passenger);
        }

        // GET: Passenger/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Passenger/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PassengerId,PassengerName,PassengerSurname,Birthday,passengerGender,TCNumber,UserMail,UserPhone")] Passenger passenger, int flightId)
        {
            if (ModelState.IsValid)
            {
              
                _context.Add(passenger);
                await _context.SaveChangesAsync();
                TempData["PassengerInfo"] = passenger;

                return RedirectToAction("Create", "Payment");
                //return RedirectToAction(nameof(Index));
            }
            return View(passenger);
        }

        // GET: Passenger/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Passenger == null)
            {
                return NotFound();
            }

            var passenger = await _context.Passenger.FindAsync(id);
            if (passenger == null)
            {
                return NotFound();
            }
            return View(passenger);
        }

        // POST: Passenger/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PassengerId,PassengerName,PassengerSurname,Birthday,passengerGender,TCNumber,UserMail,UserPhone")] Passenger passenger)
        {
            if (id != passenger.PassengerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passenger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassengerExists(passenger.PassengerId))
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
            return View(passenger);
        }

        // GET: Passenger/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Passenger == null)
            {
                return NotFound();
            }

            var passenger = await _context.Passenger
                .FirstOrDefaultAsync(m => m.PassengerId == id);
            if (passenger == null)
            {
                return NotFound();
            }

            return View(passenger);
        }

        // POST: Passenger/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Passenger == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Passenger'  is null.");
            }
            var passenger = await _context.Passenger.FindAsync(id);
            if (passenger != null)
            {
                _context.Passenger.Remove(passenger);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassengerExists(int id)
        {
          return (_context.Passenger?.Any(e => e.PassengerId == id)).GetValueOrDefault();
        }
    }
}
