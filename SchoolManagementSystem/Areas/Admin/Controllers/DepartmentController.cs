using Microsoft.AspNetCore.Mvc;
using School.DataAccess.Repository.IRepository;
using School.Models;

namespace SchoolManagementSystem.Areas.Admin.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    
        public IActionResult Index()
        {
            IEnumerable<Departament> objDepList = _unitOfWork.Department.GetAll();
            return View(objDepList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Departament obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Department.Add(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var depfromDb = _unitOfWork.Department.GetFirstOrDefault(u => u.Id == id);
            if(depfromDb == null)
            {
                return NotFound();
            }
            return View(depfromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Departament obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Department.Update(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index");

            }
            return View(obj);
        }
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var depfromDb = _unitOfWork.Department.GetFirstOrDefault(u => u.Id == id);
            if (depfromDb == null)
            {
                return NotFound();
            }
            return View(depfromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Department.GetFirstOrDefault(U => U.Id == id);
            if(obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Department.Remove(obj);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
