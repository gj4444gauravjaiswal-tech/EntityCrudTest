using MyApp.Application.Features.Country.Dtos;

namespace MyApp.Application.Features.Country.Interfaces
{
    public interface ICountryService
    {
        Task<CountryResponseDto> CreateAsync(CreateCountryDto dto);

        Task<List<CountryResponseDto>> GetAllAsync();

        Task<CountryResponseDto?> GetByIdAsync(int id);

        Task<CountryResponseDto?> UpdateAsync(int id, UpdateCountryDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
