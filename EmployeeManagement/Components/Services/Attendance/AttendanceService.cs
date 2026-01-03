using EmployeeManagement.Components.Data;
using EmployeeManagement.Components.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Components.Services.Attendance;

public class AttendanceService:IAttendanceService
{
    private readonly AppDbContext _context;
    public AttendanceService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Models.Attendance>> GetAllAttendancesAsync()
    {
        return await _context.attendance
            .Include(a => a.Employee)
            .ToListAsync();
    }
    public async Task<Models.Attendance> GetAttendanceByIdAsync(int id)
    {
        return await _context.attendance
            .Include(a => a.Employee)
            .FirstOrDefaultAsync(a => a.Id == id);
    }
    public async Task CreateAttendanceAsync(Models.Attendance attendance)
    {
        _context.attendance.Add(attendance);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAttendanceAsync(Models.Attendance attendance)
    {
        _context.attendance.Update(attendance);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAttendanceAsync(int id)
    {
        var attendance = await _context.attendance.FindAsync(id);
        if (attendance != null)
        {
            _context.attendance.Remove(attendance);
            await _context.SaveChangesAsync();
        }
    }
}