using System;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeModel.API.Model
{
	public class EmployeeRepository : IEmployeeRepository
	{
        private readonly AppDbContext appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
		{
            this.appDbContext = appDbContext;
        }


        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await appDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            //add async new employee to appDBContext
            var result = await appDbContext.Employees.AddAsync(employee);
            //save changes
            await appDbContext.SaveChangesAsync();
            //return added employee object
            return result.Entity;
        }

        public async void DeleteEmployee(int employeeId)
        {
            //find the employeeid in db
            var empIdResult = await appDbContext.
                Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            if (empIdResult != null)
            {
                //delete the empid from DB
                appDbContext.Employees.Remove(empIdResult);
                //save the changes
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            return await appDbContext.Employees
                 .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

        }

            public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var empResult = await appDbContext.Employees
                 .FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);
            if (empResult != null)
            {
                empResult.FirstName = employee.FirstName;
                empResult.LastName = employee.LastName;
                empResult.DateOfBirth = employee.DateOfBirth;
                empResult.Email = employee.Email;
                empResult.Gender = employee.Gender;
                empResult.DepartmentId = employee.DepartmentId;
                empResult.PhotoPath = employee.PhotoPath;

                await appDbContext.SaveChangesAsync();
                return empResult;
            }

            return null;

        }

        public async Task<IEnumerable<Employee>> Search(string name, Gender gender)
        {
            //return complete list of employee
           
            IQueryable<Employee> query = appDbContext.Employees;
          //  return query;
            if (!string.IsNullOrEmpty(name)) {

                query = query.Where(e => e.FirstName.Contains(name) ||
                e.LastName.Contains(name));
            }
            if (gender != null)
            {

                query = query.Where(e => e.Gender == gender);
            }

            //execute the query
           return await query.ToListAsync();

        }
    }
}

