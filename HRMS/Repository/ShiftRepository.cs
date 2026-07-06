using HRMS.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Repository
{
    public class ShiftRepository : IShiftRepository
    {
        private readonly HrmsDbContext _context;

        public ShiftRepository(HrmsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Shift>> GetAllAsync()
        {
            return await _context.Shifts.ToListAsync();
        }

        public async Task<Shift?> GetByIdAsync(int id)
        {
            return await _context.Shifts.FindAsync(id);
        }

        public async Task AddAsync(Shift shift)
        {
            await _context.Shifts.AddAsync(shift);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Shift shift)
        {
            _context.Shifts.Update(shift);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var shift = await _context.Shifts.FindAsync(id);

            if (shift != null)
            {
                _context.Shifts.Remove(shift);
                await _context.SaveChangesAsync();
            }
        }
    }
}