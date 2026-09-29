using MyApp.Application.Features.Country.Interfaces;
using Microsoft.EntityFrameworkCore;
using MyApp.Infrastructure.Persistence;
using DomainCountry = MyApp.Domain.Entities.Country;

namespace MyApp.Infrastructure.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext _context;

        public CountryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DomainCountry> CreateAsync(DomainCountry country)
        {
            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();

            return country;
        }

        public async Task<List<DomainCountry>> GetAllAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<DomainCountry?> GetByIdAsync(int id)
        {
            return await _context.Countries.FindAsync(id);
        }

        public async Task<DomainCountry?> UpdateAsync(DomainCountry country)
        {
            var existingCountry = await _context.Countries.FindAsync(country.Id);

            if (existingCountry == null)
                return null;

            existingCountry.Con_Name = country.Con_Name;

            await _context.SaveChangesAsync();

            return existingCountry;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var country = await _context.Countries.FindAsync(id);

            if (country == null)
                return false;

            _context.Countries.Remove(country);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}