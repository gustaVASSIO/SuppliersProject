using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using SuppliersProject.Data;
using SuppliersProject.Models;
using SuppliersProject.Models.Exceptions;
using SuppliersProject.Models.Services;

namespace SuppliersProject.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly SupplierService _supplierService;

        public SuppliersController(SupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public async Task<IActionResult> Index() {
            return View(await _supplierService.ListAllAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
               return RedirectToAction("Error", new {message = "Id is invalid"});

            }
            if (!await _supplierService.VerifySupplierExist(id.Value))
            {
                return RedirectToAction("Error", new { message = "Supplier not exist in database" });
            }
            Supplier supplier = await _supplierService.FindById(id.Value);
            return View(supplier);
        }

        // get
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                await _supplierService.CreateAsync(supplier);
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        //GET: Suppliers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", new { message = "Id is invalid" });
            }
            if (!await _supplierService.VerifySupplierExist(id.Value))
            {
                return RedirectToAction("Error", new { message = "Supplier not exist in database" });
            }
            Supplier supplier = await _supplierService.FindById(id.Value);
            return View(supplier);
        }

        //// POST: Suppliers/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Supplier supplier)
        {
            if (id != supplier.Id)
            {
                return RedirectToAction("Error", new { message = "Id mismatch" });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _supplierService.EditAsync(supplier);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return RedirectToAction("Error", new { message = "Dabase Error" });
                }
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", new { message = "Id is invalid" });
            }

            if (!await _supplierService.VerifySupplierExist(id.Value))
            {
                return RedirectToAction("Error", new { message = "Supplier not exist in database" });
            }
            Supplier supplier = await _supplierService.FindById(id.Value);
            return View(supplier);
        }

        //// POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Supplier supplier = await _supplierService.FindById(id);
            if (supplier != null)
            {
                await _supplierService.DeleteAsync(supplier);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error(string message) {
            ErrorViewModel viewModel = new ErrorViewModel {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View("Error", viewModel);
        }
     
    }

}


