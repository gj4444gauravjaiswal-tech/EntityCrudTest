using Microsoft.EntityFrameworkCore;
using MyApp.Application.Features.State.Interfaces;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Persistence;

namespace MyApp.Infrastructure.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly AppDbContext _context;

        public StateRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<State> CreateAsync(State state)
        {
            await _context.States.AddAsync(state);
            await _context.SaveChangesAsync();

            return state;
        }

        public async Task<List<State>> GetAllAsync()
        {
            return await _context.States
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<State?> GetByIdAsync(int id)
        {
            return await _context.States
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<State?> UpdateAsync(State state)
        {
            var existingState = await _context.States
                .FirstOrDefaultAsync(x => x.Id == state.Id);

            if (existingState == null)
                return null;

            existingState.St_Name = state.St_Name;
            existingState.Con_Id = state.Con_Id;

            await _context.SaveChangesAsync();

            return existingState;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var state = await _context.States
                .FirstOrDefaultAsync(x => x.Id == id);

            if (state == null)
                return false;

            _context.States.Remove(state);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}