using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public SQLEmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        #region.  C  .
        public Employee AddEmployee(Employee employee)
        {
            employee.Id = _context.Employees.Max(e => e.Id) + 1;
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }
        #endregion
        #region.  R  .
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees;
        }

        public Employee GetEmployee(int Id)
        {
            Employee employee = _context.Employees.FirstOrDefault(e => e.Id == Id);
            return employee;
        }

        #endregion
        #region.  U  .
        public Employee UpdateEmployee(Employee employee)
        {
            //Employee emp = _context.Employees.FirstOrDefault(e => e.Id == employee.Id);
            //if (emp != null)
            //{
            //    emp.Name = employee.Name;
            //    emp.Email = employee.Email;
            //    emp.Department = employee.Department;
            //    _context.SaveChanges();

            //}
            var emp = _context.Employees.Attach(employee);
            emp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return employee;
        }
        #endregion
        #region.  D  .
        public Employee DeleteEmployee(int Id)
        {
            Employee employee = _context.Employees.FirstOrDefault(e => e.Id == Id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            return employee;
        }

        #endregion
    }
}
