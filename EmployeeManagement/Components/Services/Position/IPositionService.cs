using EmployeeManagement.Components.Models;

namespace EmployeeManagement.Components.Services.Position;

public interface IPositionService
{
    Task<List<EmployeeManagement.Models.Position>> GetAllPositionsAsync();
    Task<EmployeeManagement.Models.Position> GetPositionByIdAsync(int id);
    Task CreatePositionAsync(EmployeeManagement.Models.Position position);
    Task UpdatePositionAsync(EmployeeManagement.Models.Position position);
    Task DeletePositionAsync(int id);
}