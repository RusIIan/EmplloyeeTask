using AutoMapper;
using HomeTask.Data.Context;
using HomeTask.Data.Entities;
using HomeTask.Dtos;
using HomeTask.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace HomeTask.Repository.Implementation
{
    public class EmployessRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

            public EmployessRepository(AppDbContext appDbContext, IMapper mapper)
            {
                _context = appDbContext;
                _mapper = mapper;
            }

            public async Task<EmployeeDto> CreateAsync(EmployeeDto employeeDto)
            {
                await _context.Employees.AddAsync(_mapper.Map<Employee>(employeeDto));
                await _context.SaveChangesAsync();
                return employeeDto;
            }

        public async Task<bool> DeleteAsync(int id)
        {
            var empDel = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (empDel == null)
                return false;
            _context.Employees.Remove(empDel);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }
        public  async Task<Employee> GetIdAsync(int id)
        {
            var empId = await _context.Employees.FirstOrDefaultAsync(x=>x.Id==id);
            return empId;
        }

        public async Task<Employee> UpdateAsync(int id,EmployeeUpdateDto employeeUpdateDto)
        {
          var empUpd = await _context.Employees.FirstOrDefaultAsync(x=>x.Id == id);
            if (empUpd == null)
                return null;

            var result = _mapper.Map<EmployeeUpdateDto, Employee>(employeeUpdateDto,empUpd);

                _context.Employees.Update(result);
          await _context.SaveChangesAsync();
          return result;
        }
    }
}
