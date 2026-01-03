
using EmployeeManagement.Components.Models;
namespace EmployeeManagement.Components.Services.Salary;

public interface ISalaryService
{
    Task<List<Models.Salary>> GetAllSalariesAsync();
    Task<Models.Salary> GetSalaryByIdAsync(int id);
    Task CreateSalaryAsync(Models.Salary salary);
    Task UpdateSalaryAsync(Models.Salary salary);
    Task DeleteSalaryAsync(int id);
}