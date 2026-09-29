using DomainState = MyApp.Domain.Entities.State;
using MyApp.Domain.Entities;

namespace MyApp.Application.Features.State.Interfaces
{
    public interface IStateRepository
    {
        Task<DomainState> CreateAsync(DomainState state);

        Task<List<DomainState>> GetAllAsync();

        Task<DomainState?> GetByIdAsync(int id);

        Task<DomainState?> UpdateAsync(DomainState state);

        Task<bool> DeleteAsync(int id);
    }
}