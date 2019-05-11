using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee{ Id=1, Name="Mary", Email="mary@test.com", Department=Dept.IT},
                new Employee{ Id=2, Name="John", Email="john@test.com", Department=Dept.HR},
                new Employee{ Id=3, Name="Sam", Email="sam@test.com", Department=Dept.IT}
            };
        }
        #region.  C  .
        public Employee AddEmployee(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }
        #endregion
        #region.  R  .
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == Id);
            return employee;
        }

        #endregion
        #region.  U  .
        public Employee UpdateEmployee(Employee employee)
        {
            Employee emp = _employeeList.FirstOrDefault(e => e.Id == employee.Id);
            if (emp != null)
            {
                emp.Name = employee.Name;
                emp.Email = employee.Email;
                emp.Department = employee.Department;
            }
            return emp;
        }
        #endregion
        #region.  D  .
        public Employee DeleteEmployee(int Id)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == Id);
            if (employee != null)
                _employeeList.Remove(employee);

            return employee;
        }

        #endregion
    }
}
