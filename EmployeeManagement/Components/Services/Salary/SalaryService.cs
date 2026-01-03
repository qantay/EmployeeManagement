using EmployeeManagement.Components.Models;
using EmployeeManagement.Components.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Components.Services.Salary;

public class SalaryService:ISalaryService
{
    private readonly AppDbContext _context;
    public SalaryService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Models.Salary>> GetAllSalariesAsync()
    {
        return await _context.salaries
            .Include(s => s.Employee)
            .ToListAsync();
    }

    public async Task<Models.Salary> GetSalaryByIdAsync(int id)
    {
        return await _context.salaries
            .Include(s => s.Employee)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task CreateSalaryAsync(Models.Salary salary)
    {
        _context.salaries.Add(salary);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateSalaryAsync(Models.Salary salary)
    {
        _context.salaries.Update(salary);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteSalaryAsync(int id)
    {
        var salary = await _context.salaries.FindAsync(id);
        if (salary != null)
        {
            _context.salaries.Remove(salary);
            await _context.SaveChangesAsync();
        }
    }
}