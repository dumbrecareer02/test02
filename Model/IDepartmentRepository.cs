using System;
using EmployeeManagement.Models;

namespace EmployeeModel.API.Model
{
	public interface IDepartmentRepository
	{
		IEnumerable<Department> GetDepartments();
		Department GetDepartment(int departmentId);
	}
}

