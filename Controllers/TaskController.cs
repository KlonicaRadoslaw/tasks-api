using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Tasks.Dto;
using Tasks.Interfaces;
using Tasks.Models;
using Tasks.Repository;

namespace Tasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        public TaskController(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Models.Task>))]
        public IActionResult GetTasks()
        {
            var tasks = _mapper.Map<List<TaskDto>>(_taskRepository.GetTasks());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(tasks);
        }
    }
}
