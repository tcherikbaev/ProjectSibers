using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectSibers.Models;

namespace ProjectSibers.Controllers
{
    public class Task_EmployeeController : Controller
    {
        private readonly ProjectContext _context;

        public Task_EmployeeController(ProjectContext context)
        {
            _context = context;
        }

        // GET: Task_Employee
        public async Task<IActionResult> Index()
        {
            var projectContext = _context.Task_Employee.Include(t => t.Employee).Include(t => t.Task);
            return View(await projectContext.ToListAsync());
        }

        // GET: Task_Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task_Employee = await _context.Task_Employee
                .Include(t => t.Employee)
                .Include(t => t.Task)
                .FirstOrDefaultAsync(m => m.Te_ID == id);
            if (task_Employee == null)
            {
                return NotFound();
            }

            return View(task_Employee);
        }

        // GET: Task_Employee/Create
        public IActionResult Create()
        {
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "Name");
            ViewData["TaskID"] = new SelectList(_context.Task, "TaskID", "Name");
            return View();
        }

        // POST: Task_Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Te_ID,TaskID,EmployeeID")] Task_Employee task_Employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(task_Employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "EmployeeID", task_Employee.EmployeeID);
            ViewData["TaskID"] = new SelectList(_context.Task, "TaskID", "TaskID", task_Employee.TaskID);
            return View(task_Employee);
        }

        // GET: Task_Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task_Employee = await _context.Task_Employee.FindAsync(id);
            if (task_Employee == null)
            {
                return NotFound();
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "Name", task_Employee.EmployeeID);
            ViewData["TaskID"] = new SelectList(_context.Task, "TaskID", "Name", task_Employee.TaskID);
            return View(task_Employee);
        }

        // POST: Task_Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Te_ID,TaskID,EmployeeID")] Task_Employee task_Employee)
        {
            if (id != task_Employee.Te_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(task_Employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Task_EmployeeExists(task_Employee.Te_ID))
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
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "EmployeeID", task_Employee.EmployeeID);
            ViewData["TaskID"] = new SelectList(_context.Task, "TaskID", "TaskID", task_Employee.TaskID);
            return View(task_Employee);
        }

        // GET: Task_Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task_Employee = await _context.Task_Employee
                .Include(t => t.Employee)
                .Include(t => t.Task)
                .FirstOrDefaultAsync(m => m.Te_ID == id);
            if (task_Employee == null)
            {
                return NotFound();
            }

            return View(task_Employee);
        }

        // POST: Task_Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task_Employee = await _context.Task_Employee.FindAsync(id);
            _context.Task_Employee.Remove(task_Employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Task_EmployeeExists(int id)
        {
            return _context.Task_Employee.Any(e => e.Te_ID == id);
        }
    }
}
