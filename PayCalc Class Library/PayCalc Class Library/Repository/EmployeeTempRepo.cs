﻿using PayCalc_Project.Models;

namespace PayCalc_Project.Repository
{
    public class EmployeeTempRepo : IEmployeeRepository<EmployeeTemp>
    {

        public List<EmployeeTemp> employees = new List<EmployeeTemp>() {
           new EmployeeTemp() { ID = Guid.NewGuid(), FirstName = "Clare", LastName = "Jones", DayRate = 350, WeeksWorked = 40 }
        };
        public bool Delete(int id)
        {
            int EmployeeCount = employees.Count();
            employees.RemoveAt(id);
            if (employees.Count() >= EmployeeCount)
            {
                return false;
            }
            return true;
        }

        public bool RemoveAll()
        {
            employees.Clear();
            if (employees.Count() > 0)
            {
                return false;
            }
            return true;
        }

        public EmployeeTemp AddEmployee(string FirstName, string Surname, decimal? Salary, decimal? Bonus, decimal? DayRate, int? WeeksWorked)
        {
            EmployeeTemp addNew = new EmployeeTemp() { ID = Guid.NewGuid(), FirstName = FirstName, LastName = Surname, DayRate = DayRate, WeeksWorked = WeeksWorked};
            return addNew;
        }

        public List<EmployeeTemp> ReadAll()
        {
            List<EmployeeTemp> ReadAll = new List<EmployeeTemp>();
            for (int i = 0; i < employees.Count; i++)
            {
                ReadAll.Add(employees[i]);
            }
            return ReadAll;
        }

        public EmployeeTemp ReadSingle(int id)
        {
            if (employees.Count() > id)
            {

                EmployeeTemp ReadSingle = new EmployeeTemp() { ID = employees[id].ID, FirstName = employees[id].FirstName, LastName = employees[id].LastName, DayRate = employees[id].DayRate, WeeksWorked = employees[id].WeeksWorked };
                return ReadSingle;
            }
            return null;
        }

        public EmployeeTemp Update(int id, string FirstName, string LastName, decimal? Salary, decimal? Bonus, decimal? DayRate, int? WeeksWorked)
        {
            EmployeeTemp employeePerm = new EmployeeTemp() { ID = employees[id].ID, FirstName = FirstName, LastName = LastName, DayRate = DayRate, WeeksWorked = WeeksWorked};
            return employeePerm;
        }
    }
}
