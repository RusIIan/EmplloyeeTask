using HomeTask.Data.Entities;
using HomeTask.Dtos;

namespace HomeTask.Repository.Interface
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();
        Task<EmployeeDto> CreateAsync(EmployeeDto employeeDto);
        Task<bool> DeleteAsync(int id);
        Task<Employee> UpdateAsync(int id, EmployeeUpdateDto employeeUpdateDto);
        Task<Employee> GetIdAsync(int id);
    }
}
