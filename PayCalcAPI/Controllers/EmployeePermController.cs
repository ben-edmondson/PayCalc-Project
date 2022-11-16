﻿using Microsoft.AspNetCore.Mvc;
using PayCalc_Project.Models;
using PayCalc_Project.Repository;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
//Postman
namespace PayCalcAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeePermController : ControllerBase
    {
         private readonly IEmployeeRepository<PermanentEmployee> _employeePermanentRepository;

        public EmployeePermController(IEmployeeRepository<PermanentEmployee> employeePermanentRepository)
        {
            _employeePermanentRepository = employeePermanentRepository;
        }
        // GET: api/<EmployeeController>
        [Route("~/api/PermanentEmployee/GetAllEmployees")]
        [HttpGet]
        public IActionResult GetAll() 
        {
            List<PermanentEmployee> employees = _employeePermanentRepository.ReadAll();
            var x = JsonSerializer.Serialize(employees);
            if (employees.Count() == 0)
            {
                return NotFound();
            }
            return Ok(x);
        }
        // GET api/<EmployeeController>/5
        [Route("~/api/PermanentEmployee/GetEmployee")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {   
            PermanentEmployee? emp = _employeePermanentRepository.Read(id);
            var ReadSingle = JsonSerializer.Serialize(emp);
            if (emp == null)
            {
                return NotFound();
            }
            return Ok(ReadSingle);
        }
        // POST api/<EmployeeController>
        [Route("~/api/PermanentEmployee/AddEmployee")]
        [HttpPost]
        public IActionResult Post(string FirstName, string Surname, decimal? Salary, decimal? Bonus)
        {
            _employeePermanentRepository.Create(FirstName, Surname, Salary, Bonus, null, null);
            return NoContent();
        }
        // PUT api/<EmployeeController>/5
        [Route("~/api/PermanentEmployee/UpdateEmployee")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, string? FirstName, string? Surname, decimal? Salary, decimal? Bonus)
        {
            if (_employeePermanentRepository.Update(id, FirstName, Surname, Salary, Bonus, null, null) == true)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        // DELETE api/<EmployeeController>/5
        [Route("~/api/PermanentEmployee/DeleteEmployee")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_employeePermanentRepository.Delete(id) == true)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }

        [Route("~/api/PermanentEmployee/DeleteAllEmployees")]
        [HttpDelete]
        public IActionResult DeleteAll()
        {
            
            if (_employeePermanentRepository.RemoveAll() == true)
            {
                return NoContent();
            }
            else
            {
                return NotFound() ;
            }
        }
    }
}
