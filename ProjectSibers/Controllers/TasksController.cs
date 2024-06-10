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
    public class TasksController : Controller
    {
        private readonly ProjectContext _context;

        public TasksController(ProjectContext context)
        {
            _context = context;
        }

         //метод длы вывода всего списка а также для сортировки по полям Приоритет и Наименование, а так же Поиск-фильтр по Наименованию и Комментарию
        public IActionResult Index(string sortOrder, string SearchString)
        {

            
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "name_as";
            ViewData["Priority"] = sortOrder == "Priority" ? "Priority_desc" : "Priority";
            var projects = from s in _context.Task.Include(t => t.Employee).Include(t => t.Status)
                           select s;
            switch (sortOrder)
            {
                case "name_desc":
                    projects = projects.OrderByDescending(s => s.Name);
                    break;
                case "Name":
                    projects = projects.OrderBy(s => s.Name);
                    break;
                case "Priority_desc":
                    projects = projects.OrderByDescending(s => s.Priority);
                    break;
                case "Priority":
                    projects = projects.OrderBy(s => s.Priority);
                    break;             
                default:
                    projects = _context.Task.Include(t => t.Employee).Include(t => t.Status);
                    break;
            }

          

            if (!String.IsNullOrEmpty(SearchString))
            {
                projects = _context.Task.Where(m => m.Name.Contains(SearchString)
                || m.Comments.Contains(SearchString)).Include(t => t.Employee).Include(t => t.Status);
            }
            //else
            //{
            //    projects= _context.Task.Include(t => t.Employee).Include(t => t.Status);
            //}

            //return View(await projects.AsNoTracking().ToListAsync());
            return View(projects);
        }
       
        

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Task
                .Include(t => t.Employee)
                .Include(t => t.Status)
                .FirstOrDefaultAsync(m => m.TaskID == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "Name");
            ViewData["StatusID"] = new SelectList(_context.StatusofTask, "StatusID", "Name");
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskID,Name,EmployeeID,StatusID,Comments,Priority")] Models.Task task)
        {
            if (ModelState.IsValid)
            {
                _context.Add(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "EmployeeID", task.EmployeeID);
            ViewData["StatusID"] = new SelectList(_context.StatusofTask, "StatusID", "StatusID", task.StatusID);
            return View(task);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Task.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "Name", task.EmployeeID);
            ViewData["StatusID"] = new SelectList(_context.StatusofTask, "StatusID", "Name", task.StatusID);
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskID,Name,EmployeeID,StatusID,Comments,Priority")] Models.Task task)
        {
            if (id != task.TaskID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(task);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskExists(task.TaskID))
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
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "EmployeeID", task.EmployeeID);
            ViewData["StatusID"] = new SelectList(_context.StatusofTask, "StatusID", "StatusID", task.StatusID);
            return View(task);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Task
                .Include(t => t.Employee)
                .Include(t => t.Status)
                .FirstOrDefaultAsync(m => m.TaskID == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await _context.Task.FindAsync(id);
            _context.Task.Remove(task);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskExists(int id)
        {
            return _context.Task.Any(e => e.TaskID == id);
        }
    }
}
