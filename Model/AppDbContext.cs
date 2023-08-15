using System;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeModel.API.Model
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
		//DBset for queries and save instance of EMP AND DEP
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Department> Departments { get; set; }

        //Seeding Data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
			//Seed Departments Table
			modelBuilder.Entity<Department>().HasData(
				new Department { DepartmentId = 1, DepartmentName = "IT" });
			modelBuilder.Entity<Department>().HasData(
				new Department { DepartmentId = 2, DepartmentName = "HR" });
			modelBuilder.Entity<Department>().HasData(
				new Department { DepartmentId = 3, DepartmentName = "Payroll" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 4, DepartmentName = "Admin" });

            //Seed Departments Table
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                FirstName = "Prasanna",
                LastName = "Sharma",
                Email = "skp@gmail.com",
                DateOfBirth = new DateTime(1984, 11, 26),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/john.png"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 2,
                FirstName = "Rupali",
                LastName = "Dumbre",
                Email = "rups@gmail.com",
                DateOfBirth = new DateTime(1983, 12, 2),
                Gender = Gender.Female,
                DepartmentId = 2,
                PhotoPath = "images/mary.png"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 3,
                FirstName = "Sam",
                LastName = "Galloway",
                Email = "Sam@pragimtech.com",
                DateOfBirth = new DateTime(1979, 11, 11),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/sam.jpg"
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 4,
                FirstName = "Sara",
                LastName = "Longway",
                Email = "sara@pragimtech.com",
                DateOfBirth = new DateTime(1982, 9, 23),
                Gender = Gender.Female,
                DepartmentId = 3,
                PhotoPath = "images/sara.png"
            });

        }


    }
}

