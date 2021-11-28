using Microsoft.AspNetCore.Mvc;
using second_crud.Models;
using System.Linq;
using System.Threading.Tasks;

namespace second_crud.Controllers
{
    public class EmpAdd : Controller
    {
        private readonly ApplicationDbContext _db;
        public EmpAdd(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var displaydata = _db.EmployeeTable.ToList();
            return View(displaydata);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(NewEmpClass nec)
        {
            if(ModelState.IsValid)
            {
                _db.Add(nec);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return View(nec);
        }

        public async Task <IActionResult>Edit(int?id)
        {
            if(id==null)
            {
                return RedirectToAction("Index");
            }
            var getempdetails = await _db.EmployeeTable.FindAsync(id);
            return View(getempdetails);
        }

        [HttpPost]


        public async Task<IActionResult>Edit(NewEmpClass nc)
        {
            if(ModelState.IsValid)
            {
                _db.Update(nc);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nc);
        }

        public async Task<IActionResult>Details(int ? id)
        {
            if (id == null)

            {
                return RedirectToAction("Index");
            }
            var getempdetails = await _db.EmployeeTable.FindAsync(id);
            return View(getempdetails);
        }

        public async Task<IActionResult>Delete(int?id)
        {
            if(id==null)
            {
                return RedirectToAction("Index");
            }
            var getempdelete = await _db.EmployeeTable.FindAsync(id);
            return View(getempdelete);
        }
        [HttpPost]

        public async Task<IActionResult>Delete(int id)
        {
            var getempdelete = await _db.EmployeeTable.FindAsync(id);
            _db.EmployeeTable.Remove(getempdelete);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
