using MyApp.Application.Features.Country.Dtos;
using MyApp.Application.Features.Country.Interfaces;
using DomainCountry = MyApp.Domain.Entities.Country;

namespace MyApp.Application.Features.Country.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<CountryResponseDto> CreateAsync(CreateCountryDto dto)
        {
            var country = new DomainCountry
            {
                Con_Name = dto.Con_Name
            };

            var result = await _countryRepository.CreateAsync(country);

            return new CountryResponseDto
            {
                Id = result.Id,
                Con_Name = result.Con_Name
            };
        }

        public async Task<List<CountryResponseDto>> GetAllAsync()
        {
            var countries = await _countryRepository.GetAllAsync();

            return countries.Select(x => new CountryResponseDto
            {
                Id = x.Id,
                Con_Name = x.Con_Name
            }).ToList();
        }

        public async Task<CountryResponseDto?> GetByIdAsync(int id)
        {
            var country = await _countryRepository.GetByIdAsync(id);

            if (country == null)
                return null;

            return new CountryResponseDto
            {
                Id = country.Id,
                Con_Name = country.Con_Name
            };
        }

        public async Task<CountryResponseDto?> UpdateAsync(int id, UpdateCountryDto dto)
        {
            var country = new DomainCountry
            {
                Id = id,
                Con_Name = dto.Con_Name
            };

            var result = await _countryRepository.UpdateAsync(country);

            if (result == null)
                return null;

            return new CountryResponseDto
            {
                Id = result.Id,
                Con_Name = result.Con_Name
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _countryRepository.DeleteAsync(id);
        }
    }
}