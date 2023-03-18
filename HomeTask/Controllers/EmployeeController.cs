using HomeTask.Data.Entities;
using HomeTask.Dtos;
using HomeTask.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HomeTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeDto employeeDto)
        {
            var wastch = new Stopwatch();
            wastch.Start();
            _logger.LogInformation($"request successfully created {DateTime.Now}");
            var employee = await _employeeRepository.CreateAsync(employeeDto);
            wastch.Stop();
            return Ok(employee);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var wastch = new Stopwatch();
            wastch.Start();

            _logger.LogInformation($"You sent a request{DateTime.Now}");
            var emp = await  _employeeRepository.GetAllAsync();

            wastch.Stop();
            _logger.LogInformation($"time:{wastch.ElapsedMilliseconds}");
            return Ok(emp);

        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var wastch = new Stopwatch();
            wastch.Start();
            var empDel = await _employeeRepository.DeleteAsync(id);
            if(empDel==null)
                return NotFound("Employee not found");
            wastch.Stop();

           return Ok(empDel);
        }
        [HttpPut]
        public async Task<IActionResult> Updata(int id,EmployeeUpdateDto employeeUpdate)
        {
            var wastch = new Stopwatch();
            wastch.Start();
            _logger.LogWarning($"request passed by error given{id} not found");
            var empUpd = await _employeeRepository.UpdateAsync(id, employeeUpdate);
            _logger.LogInformation($"Request completed successfully{DateTime.Now}");
            wastch.Stop();
            return Ok(empUpd);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetId(int id)
        {
            var wastch = new Stopwatch();
            wastch.Start();
            _logger.LogWarning($"Employee not fount {id}");
            var empId = await _employeeRepository.GetIdAsync(id);
            _logger.LogInformation("Employee was Fount");
            wastch.Stop();
            return Ok(empId);
        }
    }
}
