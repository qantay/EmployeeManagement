using EmployeeManagement.Components.Models;

namespace EmployeeManagement.Components.Services.Department;

public interface IDepartmentService
{
    Task<List<Models.Department>> GetAllDepartmentsAsync();
    Task<Models.Department> GetDepartmentByIdAsync(int id);
    Task CreateDepartmentAsync(Models.Department department);
    Task UpdateDepartmentAsync(Models.Department department);
    Task DeleteDepartmentAsync(int id);
}