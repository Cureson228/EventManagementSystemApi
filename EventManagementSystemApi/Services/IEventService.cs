using EventManagementSystemApi.Models.DTOs;

namespace EventManagementSystemApi.Services
{
    public interface IEventService
    {
        
        Task CreateEventAsync(CreateEventDto dto);
    }
}
