using EmployeeManagement.Components.Models;

namespace EmployeeManagement.Components.Services.Attendance;

public interface IAttendanceService
{
    Task<List<Models.Attendance>> GetAllAttendancesAsync();
    Task<Models.Attendance> GetAttendanceByIdAsync(int id);
    Task CreateAttendanceAsync(Models.Attendance attendance);
    Task UpdateAttendanceAsync(Models.Attendance attendance);
    Task DeleteAttendanceAsync(int id);
}