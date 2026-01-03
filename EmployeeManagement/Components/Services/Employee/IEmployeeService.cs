using EmployeeManagement.Components.Models;
namespace EmployeeManagement.Components.Services.Employee;

public interface IEmployeeService
{
    Task<List<Models.Employee>> GetAllEmployeesAsync();
    Task<Models.Employee> GetEmployeeByIdAsync(int id);
    Task CreateEmployeeAsync(Models.Employee employee);
    Task UpdateEmployeeAsync(Models.Employee employee);
    Task DeleteEmployeeAsync(int id);
}