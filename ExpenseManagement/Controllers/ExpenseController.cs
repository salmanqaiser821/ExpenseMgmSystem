using Microsoft.AspNetCore.Mvc;
using ExpenseManagement.DataLayer;
using ExpenseManagement.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExpenseManagement.Controllers
{
    public class ExpenseController : Controller
    {
        public readonly DBContextExpMgt _context;

        public ExpenseController(DBContextExpMgt context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<ExpenseEntity> expenseList = _context.Expenses.ToList();

            foreach (var obj in expenseList)
            {
                obj.ExpenseCategory = _context.ExpenseCategory.FirstOrDefault
                    (u => u.ExpenseCategoryId == obj.ExpenseCategoryId);
            }

            return View(expenseList);
        }

        public IActionResult Create(ExpenseEntity expenseDetails)
        {
            IEnumerable<SelectListItem> getExpenseCategoryList =
                _context.ExpenseCategory.Select(i => new SelectListItem
                {

                    Text = i.ExpenseCategoryName,
                    Value = i.ExpenseCategoryId.ToString()

                });

            ViewBag.PopulateExpCategory = getExpenseCategoryList;


            if (ModelState.IsValid)
            {
                _context.Expenses.Add(expenseDetails);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }




        public IActionResult GetExpenseDetailsForUpdate(int? Id)
        {
            IEnumerable<SelectListItem> getExpenseCategoryList =
                _context.ExpenseCategory.Select(i => new SelectListItem
                {

                    Text = i.ExpenseCategoryName,
                    Value = i.ExpenseCategoryId.ToString()

                });

            ViewBag.PopulateExpCategory = getExpenseCategoryList;


            var _ExpenseDetails = _context.Expenses.Find(Id);
            if (_ExpenseDetails == null)
            {
                return NotFound();
            }

            return View(_ExpenseDetails);

        }
        [HttpPost]
        public IActionResult Update(ExpenseEntity expenseDetails)
        {
            


            if (ModelState.IsValid)
            {
                _context.Expenses.Update(expenseDetails);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult GetExpenseDetailsForDelete(int? Id)
        {
            IEnumerable<SelectListItem> getExpenseCategoryList =
                _context.ExpenseCategory.Select(i => new SelectListItem
                {

                    Text = i.ExpenseCategoryName,
                    Value = i.ExpenseCategoryId.ToString()

                });

            ViewBag.PopulateExpCategory = getExpenseCategoryList;
            var _ExpenseDetails = _context.Expenses.Find(Id);
            if (_ExpenseDetails == null)
            {
                return NotFound();
            }

            return View(_ExpenseDetails);

        }



        public IActionResult Delete(int? ExpenseId)
        {
            var _ExpenseDetails = _context.Expenses.Find(ExpenseId);
            if (_ExpenseDetails == null)
            {
                return NotFound();
            }

            _context.Expenses.Remove(_ExpenseDetails);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}