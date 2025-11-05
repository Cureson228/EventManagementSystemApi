using EventManagementSystemApi.Models.DTOs;
using EventManagementSystemApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementSystemApi.Controllers
{

    [ApiController]
    [Authorize]
    [Route("/api/events")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }
        
        [HttpPost("create")]
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventDto dto)
        {
            await _eventService.CreateEventAsync(dto);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetPublicEvents()
        {

        }
    }
}
