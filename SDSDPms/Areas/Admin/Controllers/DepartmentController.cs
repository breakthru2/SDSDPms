using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SDSDPms.Models;
using Uplift.DataAccess.Data.Repository.IRepository;

namespace SDSDPms.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View(_unitOfWork.Department.GetAll());
        }

        [HttpGet]
        public IActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDepartment(Department dept)
        {
            if (!ModelState.IsValid)
            {
                return View(dept);
            }
           
            _unitOfWork.Department.Add(dept);
            _unitOfWork.Save();

            TempData["message"] = "Department Created Successfully";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
          
            var dept = _unitOfWork.Department.Get(id);
            if (dept == null)
            {
                return NotFound();
            }
            return View(dept);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Department dept)
        {
            if (ModelState.IsValid)
            {
                if (dept.Id == Guid.Empty)
                {
                    dept.Id = Guid.NewGuid();
                    _unitOfWork.Department.Add(dept);
                    ViewBag.Action = "Created";
                }
                else
                {
                    _unitOfWork.Department.Update(dept);
                    ViewBag.Action = "Updated";
                }
                _unitOfWork.Save();
                TempData["message"] = ViewBag.Action + " Successfull";
                return RedirectToAction(nameof(Index));
            }
            return View(dept);
        }

        public IActionResult Delete(Guid Id)
        {
            var deptFromDb = _unitOfWork.Department.GetFirstorDefault(m => m.Id == Id);
            _unitOfWork.Department.Remove(deptFromDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
