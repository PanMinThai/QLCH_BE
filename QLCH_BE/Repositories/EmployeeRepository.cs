using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QLCH_BE.Entities.Objects;
using QLCH_BE.Models;

namespace QLCH_BE.Repositories
{
    public interface IEmployeeRepository
    {
        public Task<List<EmployeeModel>> GetAllEmployees();
        public Task<EmployeeModel> GetEmployeeById(Guid id);
        public Task<Guid> CreateEmployee(EmployeeModel model);
        public Task DeleteEmployee(Guid id);
        public Task UpdateEmployee(EmployeeModel model, Guid id);
    }
    public class EmployeeRepository : IEmployeeRepository
    {
        public readonly StoreManagementDbContext _context;
        public readonly IMapper _mapper;
        public EmployeeRepository(StoreManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        public async Task<Guid> CreateEmployee(EmployeeModel model)
        {
            var newEmployee =  _mapper.Map<EmployeeEntity>(model);
            _context.Employees.Add(newEmployee);
            await _context.SaveChangesAsync();
            return newEmployee.Id;
        }

        public async Task DeleteEmployee(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<EmployeeModel>> GetAllEmployees()
        {
            var list = await _context.Employees.ToListAsync();
            return _mapper.Map<List<EmployeeModel>>(list);
        }

        public async Task<EmployeeModel> GetEmployeeById(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return _mapper.Map<EmployeeModel>(employee);
        }

        public async Task UpdateEmployee(EmployeeModel model, Guid id)
        {
            var employee = await _context.Employees.SingleOrDefaultAsync(x => x.Id == id);
            if (employee != null)
            {
                _mapper.Map(model, employee);
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
            }            
        }
    }
}
