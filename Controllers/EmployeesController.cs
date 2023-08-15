using System;
using EmployeeManagement.Models;
using EmployeeModel.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeModel.API.Controllers
{
	//step2 route to be available at this path
	[Route("api/[controller]")]
	[ApiController] //step1 attribute 
	public class EmployeesController : ControllerBase
	{
		private readonly IEmployeeRepository _employeeRespository;

		//Controller Injection
		public EmployeesController(IEmployeeRepository employeeRespository)
		{
			this._employeeRespository = employeeRespository;
		}


		//fetch the employees details
		[HttpGet]
		public async Task<ActionResult> getEmployees()
		{
			try
			{
				return Ok(await _employeeRespository.GetEmployees());
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,
					"Error retreving from the dtabase");
			}

		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<Employee>> GetEmployee(int id)
		{
			try
			{
				var result = await _employeeRespository.GetEmployee(id);
				if (result == null)
				{
					return NotFound();
				}
				return result;
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		[HttpPost]
		public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
		{
			try
			{
                if (employee == null)
                {
                    return BadRequest();
                }
                var createdEmployee = await _employeeRespository.AddEmployee(employee);
                //return 201, header location, created resource
                //nameof to check if the method name is changes instead of hardcoded
                return CreatedAtAction(nameof(getEmployees), new { id = createdEmployee.EmployeeId },
                    createdEmployee);
            }
			catch (Exception ex)
			{
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
		}

		[HttpGet("{search}")]
		public async Task<ActionResult<IEnumerable<Employee>>> Search(string name, Gender gender)
		{
			try
			{
                var result =  await _employeeRespository.Search(name, gender);
				if (result.Any())
				{
					return Ok(result);
				}
				return NotFound();
            }
			catch (Exception ex)
			{
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
			
		}

	}
}

