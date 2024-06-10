using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectSibers.Models;
using ProjectSibers.Models.CallingStoredProcedures;

namespace ProjectSibers.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ProjectContext _context;
        ProjectsbyDate projectsby = null;
        public ProjectsController(ProjectContext context,ProjectsbyDate date)
        {

            _context = context;
            projectsby=date;

        }

        // GET: Projects
        //public async Task<IActionResult> Index()
        //{

        //    var projectContext = _context.Projects.Include(p => p.Employee);
        //    return View(await projectContext.ToListAsync());
        //}
        //в методе GET Index() вызываю метод в котором вызывается хранимая процедура для вывода всей таблицы Project и
        // также добавляю сортировку для проектов по приоритету (по убыванию и по возрастанию)

        public IActionResult Index(string sortOrder)
        {

            IEnumerable<Project> projectss = projectsby.GetAllData();
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "name_as";
            ViewData["NamesParameter"] = sortOrder == "Name" ? "Name_desc" : "Name";
            ViewData["Customer"] = sortOrder == "Customer" ? "Customer_desc" : "Customer";

            var projects = from s in projectsby.GetAllData()
                           select s;
            switch (sortOrder)
            {
                case "name_desc":
                    projects = projects.OrderByDescending(s => s.Priority);
                    break;
                case "Name":
                    projects = projects.OrderBy(s => s.Name);
                    break;
                case "Name_desc":
                    projects = projects.OrderByDescending(s => s.Name);
                    break;
                case "Customer":
                    projects = projects.OrderBy(s => s.Customer);
                    break;
                case "Customer_desc":
                    projects = projects.OrderByDescending(s => s.Customer);
                    break;
                case "name_as":
                    projects = projects.OrderBy(s => s.Priority);
                    break;
                default:
                    projects = projectsby.GetAllData();
                    break;
            }

            //return View(await projects.AsNoTracking().ToListAsync());
            return View(projects);
        }
        
        //public IActionResult Index()
        //{
        //    IEnumerable<Project> projects = projectsby.GetAllData();


        //    return View(projects);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        //в методе Post Index() вызываю метод который будет принимать параметры периода даты и будет вызывать метод в котором вызывется хранимка для вывода данных по периоду
        public IActionResult Index(DateTime Date_start, DateTime Date_finish)
        {

                ViewBag.Date_start = Date_start;
                ViewBag.Date_finish = Date_finish;
                List<Project> project = projectsby.Get_Project(Date_start, Date_finish);
                return View(project);
          

            
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.Employee)
                .FirstOrDefaultAsync(m => m.ProjectID == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "Name");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectID,Name,Customer,Executor,EmployeeID,beginDate,finishDate,Priority")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "EmployeeID", project.EmployeeID);
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "Name", project.EmployeeID);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectID,Name,Customer,Executor,EmployeeID,beginDate,finishDate,Priority")] Project project)
        {
            if (id != project.ProjectID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ProjectID))
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
            ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "EmployeeID", project.EmployeeID);
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.Employee)
                .FirstOrDefaultAsync(m => m.ProjectID == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //функция для фильтра по диапазону даты
        [HttpPost]
        public void OnPost(DateTime startdate,DateTime enddate)
        {
            var results = (from x in _context.Projects where (x.beginDate <= startdate) && (x.finishDate >= enddate) select x).ToList();
        }
        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.ProjectID == id);
        }
    }
}
