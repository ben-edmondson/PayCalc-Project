﻿using Microsoft.AspNetCore.Mvc;
using PayCalc_Project.Models;
using PayCalc_Project.Repository;
using Web.Models;

namespace Web.Controllers
{
    public class TemporaryEmployeeController : Controller
    {
        private readonly IEmployeeRepository<TemporaryEmployee> _temporaryRepo;

        public TemporaryEmployeeController(IEmployeeRepository<TemporaryEmployee> tempRepo)
        {
            _temporaryRepo = tempRepo;
        }

        public IActionResult EmployeeList()
        {
            TemporaryEmployeeViewModel tempView = new TemporaryEmployeeViewModel(_temporaryRepo.ReadAll());
            return View(tempView);
        }
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(TemporaryEmployee inputEmployee)
        {
            _temporaryRepo.Create(inputEmployee.FirstName, inputEmployee.LastName, null, null, inputEmployee.DayRate, inputEmployee.WeeksWorked);
            return RedirectToAction("EmployeeList");
        }

        public IActionResult DeleteEmployee(int id)
        {
            _temporaryRepo.Delete(id);
            return RedirectToAction("EmployeeList");
        }

        public IActionResult UpdateEmployee(int id)
        {
            return View(_temporaryRepo.Read(id));
        }

        [HttpPost]
        public IActionResult UpdateEmployee(TemporaryEmployee updateEmployee)
        {
            _temporaryRepo.Update(updateEmployee.ID, updateEmployee.FirstName, updateEmployee.LastName, null,null,updateEmployee.DayRate,updateEmployee.WeeksWorked);
            return RedirectToAction("EmployeeList");
        }
    }
}
