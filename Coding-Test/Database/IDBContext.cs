using System;
using System.Collections.Generic;

namespace Coding_Test.Database
{
    public interface IDBContext
    {
        public List<Employee> GetEmployees();
        public int AddEmployee(Employee employee);
        public int UpdateEmployee(long id, Employee employee);
        public int DeleteEmployee(long id);
    }
}
