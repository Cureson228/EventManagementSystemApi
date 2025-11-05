using EventManagementSystemApi.Models;
using EventManagementSystemApi.Models.DTOs;
using System.Security.Claims;

namespace EventManagementSystemApi.Services
{
    public class EventService : IEventService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        public EventService(AppDbContext dbContext, IHttpContextAccessor contextAccessor)
        {
            _context = dbContext;
            _contextAccessor = contextAccessor;
        }

        public async Task CreateEventAsync(CreateEventDto dto)
        {
            var userId = _contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            if (userId == null)
            {
                throw new Exception("Error happened while accessing the user");
            }


            var newEvent = new Event
            {
                Title = dto.Title,
                Description = dto.Description,
                DateTime = dto.DateTime,
                Location = dto.Location,
                Capacity = dto.Capacity,
                Visibility = Boolean.Parse(dto.Visibility),
                CreatedByUserId = userId

            };

            _context.Events.Add(newEvent);

            var participant = new Participant
            {
                Event = newEvent,
                UserId = userId,
                JoinedAt = DateTime.UtcNow,
            };

            _context.Participants.Add(participant);

            await _context.SaveChangesAsync(); 
            
        }
    }
}
