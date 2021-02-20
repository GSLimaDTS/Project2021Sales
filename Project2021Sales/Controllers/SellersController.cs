using Microsoft.AspNetCore.Mvc;
using Project2021Sales.Models;
using Project2021Sales.Models.ViewModels;
using Project2021Sales.Services;
using Project2021Sales.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project2021Sales.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }
        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = _departmentService.FindAll();
                var viewmodel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewmodel);
            }
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID not Provided" });
            }

            var obj = _sellerService.FindByID(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID not Found" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID not Provided" });
            }

            var obj = _sellerService.FindByID(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID not Found" });
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID not Provided" });
            }

            var obj = _sellerService.FindByID(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "ID not Found" });
            }
            List<Department> departments = _departmentService.FindAll();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = _departmentService.FindAll();
                var viewmodel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewmodel);
            }
            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "ID Mismatch" });
            }
            try
            {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewmodel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewmodel);
        }
    }
}
