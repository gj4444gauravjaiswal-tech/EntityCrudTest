using DomainCountry = MyApp.Domain.Entities.Country;

namespace MyApp.Application.Features.Country.Interfaces
{
    public interface ICountryRepository
    {
        Task<DomainCountry> CreateAsync(DomainCountry country);

        Task<List<DomainCountry>> GetAllAsync();

        Task<DomainCountry?> GetByIdAsync(int id);

        Task<DomainCountry?> UpdateAsync(DomainCountry country);

        Task<bool> DeleteAsync(int id);
    }
}