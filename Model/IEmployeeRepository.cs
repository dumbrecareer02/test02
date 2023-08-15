using System;
using EmployeeManagement.Models;

namespace EmployeeModel.API.Model
{
    //The repository interface contains what it can do, but not, how it does, what it can do

    public interface IEmployeeRepository
	{
        //defined the CRUD methods,parameters and return type
        //we need async methods so Task
        Task<IEnumerable<Employee>> Search(string name, Gender gender);
        Task<IEnumerable<Employee>> GetEmployees();
		Task<Employee> GetEmployee(int employeeId);
        Task<Employee> AddEmployee(Employee employee);
		Task<Employee> UpdateEmployee(Employee employee);
        void DeleteEmployee(int employeeId);


    }
}

