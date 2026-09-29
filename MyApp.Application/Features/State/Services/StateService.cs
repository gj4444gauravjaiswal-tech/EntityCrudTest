using MyApp.Application.Features.State.Dtos;
using MyApp.Application.Features.State.Interfaces;
using DomainState = MyApp.Domain.Entities.State;

namespace MyApp.Application.Features.State.Services
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _repository;

        public StateService(IStateRepository repository)
        {
            _repository = repository;
        }

        public async Task<StateResponseDto> CreateAsync(StateDto dto)
        {
            var state = new DomainState
            {
                St_Name = dto.St_Name,
                Con_Id = dto.Con_Id
            };

            var result = await _repository.CreateAsync(state);

            return new StateResponseDto
            {
                Id = result.Id,
                St_Name = result.St_Name,
                Con_Id = result.Con_Id
            };
        }

        public async Task<List<StateResponseDto>> GetAllAsync()
        {
            var states = await _repository.GetAllAsync();

            return states.Select(x => new StateResponseDto
            {
                Id = x.Id,
                St_Name = x.St_Name,
                Con_Id = x.Con_Id
            }).ToList();
        }

        public async Task<StateResponseDto?> GetByIdAsync(int id)
        {
            var state = await _repository.GetByIdAsync(id);

            if (state == null)
                return null;

            return new StateResponseDto
            {
                Id = state.Id,
                St_Name = state.St_Name,
                Con_Id = state.Con_Id
            };
        }

        public async Task<StateResponseDto?> UpdateAsync(
            int id,
            StateDto dto)
        {
            var state = new DomainState
            {
                Id = id,
                St_Name = dto.St_Name,
                Con_Id = dto.Con_Id
            };

            var result = await _repository.UpdateAsync(state);

            if (result == null)
                return null;

            return new StateResponseDto
            {
                Id = result.Id,
                St_Name = result.St_Name,
                Con_Id = result.Con_Id
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}