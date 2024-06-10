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
    public class Employee_ProjectController : Controller
    {
        private readonly ProjectContext _context;

        public Employee_ProjectController(ProjectContext context)
        {
            _context = context;
        }

        // GET: Employee_Project
        public async Task<IActionResult> Index()
        {
            var projectContext = _context.employee_Projects.Include(e => e.Employee).Include(e => e.Project);
            return View(await projectContext.ToListAsync());
        }

        // GET: Employee_Project/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee_Project = await _context.employee_Projects
                .Include(e => e.Employee)
                .Include(e => e.Project)
                .FirstOrDefaultAsync(m => m.epID == id);
            if (employee_Project == null)
            {
                return NotFound();
            }

            return View(employee_Project);
        }

        // GET: Employee_Project/Create
        public IActionResult Create()
        {
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "Name");
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectID", "Name");
            return View();
        }

        // POST: Employee_Project/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("epID,ProjectID,EmployeeID")] Employee_Project employee_Project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee_Project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "EmployeeID", employee_Project.EmployeeID);
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectID", "ProjectID", employee_Project.ProjectID);
            return View(employee_Project);
        }

        // GET: Employee_Project/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee_Project = await _context.employee_Projects.FindAsync(id);
            if (employee_Project == null)
            {
                return NotFound();
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "Name", employee_Project.EmployeeID);
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectID", "Name", employee_Project.ProjectID);
            return View(employee_Project);
        }

        // POST: Employee_Project/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("epID,ProjectID,EmployeeID")] Employee_Project employee_Project)
        {
            if (id != employee_Project.epID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee_Project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Employee_ProjectExists(employee_Project.epID))
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
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "EmployeeID", employee_Project.EmployeeID);
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectID", "ProjectID", employee_Project.ProjectID);
            return View(employee_Project);
        }

        // GET: Employee_Project/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee_Project = await _context.employee_Projects
                .Include(e => e.Employee)
                .Include(e => e.Project)
                .FirstOrDefaultAsync(m => m.epID == id);
            if (employee_Project == null)
            {
                return NotFound();
            }

            return View(employee_Project);
        }

        // POST: Employee_Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee_Project = await _context.employee_Projects.FindAsync(id);
            _context.employee_Projects.Remove(employee_Project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Employee_ProjectExists(int id)
        {
            return _context.employee_Projects.Any(e => e.epID == id);
        }
    }
}
