using EmployeeManagement.Components.Models;
using EmployeeManagement.Components.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Components.Services.Employee;

public class EmployeeService:IEmployeeService
{
    private readonly AppDbContext _context;

    public EmployeeService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Models.Employee>> GetAllEmployeesAsync()
    {
        return await _context.employees
            .Include(e => e.Department)
            .Include(e => e.Position)
            .ToListAsync();
    }

    public async Task<Models.Employee> GetEmployeeByIdAsync(int id)
    {
        return await _context.employees
            .Include(e => e.Department)
            .Include(e => e.Position)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task CreateEmployeeAsync(Models.Employee employee)
    {
        _context.employees.Add(employee);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateEmployeeAsync(Models.Employee employee)
    {
        _context.employees.Update(employee);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEmployeeAsync(int id)
    {
        var employee = await _context.employees.FindAsync(id);
        if (employee != null)
        {
            _context.employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}