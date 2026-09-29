using MyApp.Application.Features.State.Dtos;

namespace MyApp.Application.Features.State.Interfaces
{
    public interface IStateService
    {
        Task<StateResponseDto> CreateAsync(StateDto dto);

        Task<List<StateResponseDto>> GetAllAsync();

        Task<StateResponseDto?> GetByIdAsync(int id);

        Task<StateResponseDto?> UpdateAsync(int id, StateDto dto);

        Task<bool> DeleteAsync(int id);
    }
}