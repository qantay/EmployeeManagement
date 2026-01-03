using EmployeeManagement.Components.Models;
using EmployeeManagement.Components.Data;
using Microsoft.EntityFrameworkCore;


namespace EmployeeManagement.Components.Services.Position;

public class PositionService:IPositionService
{
    
    private readonly AppDbContext _context;
    public PositionService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<EmployeeManagement.Models.Position>> GetAllPositionsAsync()
    {
        return await _context.positions.ToListAsync();
    }

    public async Task<EmployeeManagement.Models.Position> GetPositionByIdAsync(int id)
    {
        return await _context.positions.FindAsync(id);
    }

    public async Task CreatePositionAsync(EmployeeManagement.Models.Position position)
    {
        _context.positions.Add(position);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePositionAsync(EmployeeManagement.Models.Position position)
    {
        _context.positions.Update(position);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePositionAsync(int id)
    {
        var position = await _context.positions.FindAsync(id);
        if (position != null)
        {
            _context.positions.Remove(position);
            await _context.SaveChangesAsync();
        }
    }
}