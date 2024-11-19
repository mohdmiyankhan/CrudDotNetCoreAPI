using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudDotNetCoreApi.Models
{
    public class EmployeeRepository
    {
        private readonly AppDbContext _dbContext;

        public EmployeeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            //return await _dbContext.Employees.ToListAsync();
            List<Employee> empList = new List<Employee>();
            empList = await (from emp in _dbContext.Employees
                             join role in _dbContext.Roles on emp.EmpRoleId equals role.RoleId
                             join designation in _dbContext.Designations on emp.EmpDesignationId equals designation.DesignationId
                             select new Employee
                             {
                                 EmpId = emp.EmpId,
                                 EmpName = emp.EmpName,
                                 EmpCode = emp.EmpCode,
                                 EmpEmailId = emp.EmpEmailId,
                                 EmpDesignation = designation.DesignationName,
                                 EmpDesignationId = designation.DesignationId,
                                 EmpRole = role.RoleName,
                                 EmpRoleId = role.RoleId
                             }).ToListAsync();

            return empList;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            //return await _dbContext.Employees.FindAsync(id);
            var employeeDetails = await _dbContext.Employees.FindAsync(id);
            if (employeeDetails == null)
            {
                throw new Exception("Record not found.");
            }
            return employeeDetails;
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            await _dbContext.Set<Employee>().AddAsync(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(int id, Employee model)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new Exception("Record not found.");
            }

            employee.EmpId = model.EmpId;
            employee.EmpName = model.EmpName;
            employee.EmpCode = model.EmpCode;
            employee.EmpEmailId = model.EmpEmailId;
            employee.EmpDesignationId = model.EmpDesignationId;
            employee.EmpRoleId = model.EmpRoleId;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new Exception("Record not found.");
            }
            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
        }
    }
}
