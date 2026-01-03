using EmployeeManagement.Components.Models;
using EmployeeManagement.Components.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Components.Services.Department;

public class DepartmentService:IDepartmentService
{
    private readonly AppDbContext _context;

    public DepartmentService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Models.Department>> GetAllDepartmentsAsync()
    {
        return await _context.departments.ToListAsync();
    }

    async Task<Models.Department> IDepartmentService.GetDepartmentByIdAsync(int id)
    {
        return await _context.departments.FindAsync(id);
    }

    public async Task CreateDepartmentAsync(Models.Department department)
    {
        _context.departments.Add(department);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateDepartmentAsync(Models.Department department)
    {
        _context.departments.Update(department);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteDepartmentAsync(int id)
    {
        var department = await _context.departments.FindAsync(id);
        if (department != null)
        {
            _context.departments.Remove(department);
            await _context.SaveChangesAsync();
        }
    }
    
}