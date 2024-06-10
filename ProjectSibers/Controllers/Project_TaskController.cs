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
    public class Project_TaskController : Controller
    {
        private readonly ProjectContext _context;

        public Project_TaskController(ProjectContext context)
        {
            _context = context;
        }

        // GET: Project_Task
        public async Task<IActionResult> Index()
        {
            var projectContext = _context.Project_Task.Include(p => p.Project).Include(p => p.Task);
            return View(await projectContext.ToListAsync());
        }

        // GET: Project_Task/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project_Task = await _context.Project_Task
                .Include(p => p.Project)
                .Include(p => p.Task)
                .FirstOrDefaultAsync(m => m.Pt_ID == id);
            if (project_Task == null)
            {
                return NotFound();
            }

            return View(project_Task);
        }

        // GET: Project_Task/Create
        public IActionResult Create()
        {
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectID", "Name");
            ViewData["TaskID"] = new SelectList(_context.Task, "TaskID", "Name");
            return View();
        }

        // POST: Project_Task/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Pt_ID,ProjectID,TaskID")] Project_Task project_Task)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project_Task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectID", "ProjectID", project_Task.ProjectID);
            ViewData["TaskID"] = new SelectList(_context.Task, "TaskID", "TaskID", project_Task.TaskID);
            return View(project_Task);
        }

        // GET: Project_Task/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project_Task = await _context.Project_Task.FindAsync(id);
            if (project_Task == null)
            {
                return NotFound();
            }
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectID", "Name", project_Task.ProjectID);
            ViewData["TaskID"] = new SelectList(_context.Task, "TaskID", "Name", project_Task.TaskID);
            return View(project_Task);
        }

        // POST: Project_Task/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Pt_ID,ProjectID,TaskID")] Project_Task project_Task)
        {
            if (id != project_Task.Pt_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project_Task);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Project_TaskExists(project_Task.Pt_ID))
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
            ViewData["ProjectID"] = new SelectList(_context.Projects, "ProjectID", "ProjectID", project_Task.ProjectID);
            ViewData["TaskID"] = new SelectList(_context.Task, "TaskID", "TaskID", project_Task.TaskID);
            return View(project_Task);
        }

        // GET: Project_Task/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project_Task = await _context.Project_Task
                .Include(p => p.Project)
                .Include(p => p.Task)
                .FirstOrDefaultAsync(m => m.Pt_ID == id);
            if (project_Task == null)
            {
                return NotFound();
            }

            return View(project_Task);
        }

        // POST: Project_Task/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project_Task = await _context.Project_Task.FindAsync(id);
            _context.Project_Task.Remove(project_Task);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Project_TaskExists(int id)
        {
            return _context.Project_Task.Any(e => e.Pt_ID == id);
        }
    }
}
