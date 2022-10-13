﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PayCalc_Project.Models;

namespace PayCalc_Project.Repository
{
    public class EmployeeTempRepo : IEmployeeRepository<EmployeeTemp>
    {
        public List<EmployeeTemp> employees = new List<EmployeeTemp>();
        public bool Delete(int id)
        {
            if (employees.Exists(x => x.ID == id) == true)
            {
                employees.Remove(employees.Find(x => x.ID == id));
                return true;
            }
            return false;
        }

        public bool RemoveAll()
        {
            employees.Clear();
            return true;
        }

        public EmployeeTemp AddEmployee(string FirstName, string Surname, decimal? Salary, decimal? Bonus, decimal? DayRate, int? WeeksWorked)
        {
            EmployeeTemp addNew = TempEmployeeFactory.CreateEmployee(FirstName, Surname, DayRate, WeeksWorked);
            return addNew;
        }

        public List<EmployeeTemp> ReadAll()
        {
            List<EmployeeTemp> ReadAll = employees;
            return ReadAll;
        }

        public EmployeeTemp? ReadSingle(int id)
        {
            EmployeeTemp? ReadSingle = employees.Find(x => x.ID == id);
            return ReadSingle;
        }

        public bool Update(int id, string? FirstName, string? LastName, decimal? Salary, decimal? Bonus, decimal? DayRate, int? WeeksWorked)
        {
            foreach (EmployeeTemp employee in employees)
            {
                if (employee.ID == id)
                {
                    if (String.IsNullOrEmpty(FirstName) == false)
                    {
                        employee.FirstName = FirstName;
                    }
                    if (String.IsNullOrEmpty(LastName) == false)
                    {
                        employee.LastName = LastName;
                    }
                    if (DayRate != null)
                    {
                        employee.DayRate = DayRate;
                    }
                    if (WeeksWorked != null)
                    {
                        employee.WeeksWorked = WeeksWorked;
                    }
                    return true;
                }
            }
            return false;
        }

        public EmployeeTemp Create(string FirstName, string Surname, decimal? Salary, decimal? Bonus, decimal? DayRate, int? WeeksWorked)
        {
            Random idGen = new Random();
            int id = idGen.Next(1111, 10000);
            EmployeeTemp employee = new EmployeeTemp() { ID = id, FirstName = FirstName, LastName = LastName, DayRate = DayRate, WeeksWorked = WeeksWorked };
            return employee;
        }

        public void AddEmployee(EmployeeTemp employee)
        {
            employees.Add(employee);
        }
    }
}
