using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Uplift.DataAccess.Data.Repository.IRepository;

namespace SDSDPms.Areas.Admin.Controllers
{
    public class ResourceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResourceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddResource()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult AddResource()
        //{
        //    return View();
        //}
    }
}
