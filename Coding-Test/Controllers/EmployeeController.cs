using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Coding_Test.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Coding_Test.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        
        private readonly ILogger<EmployeeController> _logger;
        private readonly IDBContext _dbContext;

        public EmployeeController(ILogger<EmployeeController> logger, IDBContext dBContext)
        {
            _logger = logger;
            _dbContext = dBContext;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _dbContext.GetEmployees();
        }

        // GET: /Employee/5
        [HttpGet("{id}", Name = "Get")]
        public Employee Get(int id)
        {
            return _dbContext.GetEmployees().Find(e => e.Id == id);
        }

        // POST: /Employee
        [HttpPost]
        [Produces("application/json")]
        public int Post([FromBody] Employee employee)
        {
            if (employee is null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            return _dbContext.AddEmployee(employee);
        }

        // PUT: /Employee/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Employee employee)
        {
            if (employee is null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            _dbContext.UpdateEmployee(id, employee);
        }

        // DELETE: /Employee/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _dbContext.DeleteEmployee(id);
        }
    }
}
