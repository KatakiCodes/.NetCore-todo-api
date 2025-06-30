using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TODO.Api.DTOs.TodoItemDtos;
using TODO.Domain.Commands;
using TODO.Domain.Commands.Contracts;
using TODO.Domain.Entities;
using TODO.Domain.Handlers;
using TODO.Domain.Repositories;

namespace TODO.Api.Controllers
{
    [Route("api/v1/todos")]
    [ApiController]
    [Authorize]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class TodoController : ControllerBase
    {
        private readonly ITodoItemRepository _ITodoItemRepository;

        public TodoController([FromServices] ITodoItemRepository todoItemRepository)
        {
            this._ITodoItemRepository = todoItemRepository;
        }


        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<TodoItem>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<TodoItem>> GetAll()
        {
            string? userClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userClaim is null)
                return Unauthorized();
            Guid userId = new(userClaim);
            return Ok(_ITodoItemRepository.GetAll(userId));
        }

        [HttpGet("today")]
        [ProducesResponseType(typeof(IEnumerable<TodoItem>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<TodoItem>> GetToday(bool done)
        {
            string? userClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userClaim is null)
                return Unauthorized();
            Guid userId = new(userClaim);

            return Ok(_ITodoItemRepository.GetByPeriod(userId, DateTime.Now, done));
        }

        [HttpGet("yesterday")]
        [ProducesResponseType(typeof(IEnumerable<TodoItem>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<TodoItem>> GetYesterday(bool done)
        {
            string? userClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userClaim is null)
                return Unauthorized();
            Guid userId = new(userClaim);

            var date = DateTime.Today.AddDays(-1);
            return Ok(_ITodoItemRepository.GetByPeriod(userId, date, done));
        }

        [HttpGet("tomorow")]
        [ProducesResponseType(typeof(IEnumerable<TodoItem>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<TodoItem>> GetTomorow(bool done)
        {
            string? userClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userClaim is null)
                return Unauthorized();
            Guid userId = new(userClaim);

            var date = DateTime.Today.AddDays(1);
            return Ok(_ITodoItemRepository.GetByPeriod(userId, date, done));
        }

        [HttpPost("")]
        [ProducesResponseType(typeof(GenericCommandResult), StatusCodes.Status201Created)]
        public ActionResult<GenericCommandResult> Create(
            [FromBody] CreateTodoItemDto createTodoItemDto,
            [FromServices] Handler handler
        )
        {
            string? userClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userClaim is null)
                return Unauthorized();
            Guid userId = new(userClaim);

            CreateTodoItemCommand command = new(createTodoItemDto.Title, userId, createTodoItemDto.Date);
            return Created("TodoItem", (GenericCommandResult)handler.Handle(command));
        }
        [HttpPut("")]
        [ProducesResponseType(typeof(GenericCommandResult), StatusCodes.Status200OK)]
        public ActionResult<GenericCommandResult> Update(
            [FromBody] UpdateTodoItemDto todoItemDto,
            [FromServices] Handler handler
        )
        {
            string? userClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userClaim is null)
                return Unauthorized();
            Guid userId = new(userClaim);

            UpdateTodoItemCommand command = new(todoItemDto.Id, userId, todoItemDto.Title, todoItemDto.Date);
            return Created("TodoItem", (GenericCommandResult)handler.Handle(command));
        }

        [HttpPut("mark-as-done/{id:Guid}")]
        [ProducesResponseType(typeof(GenericCommandResult), StatusCodes.Status200OK)]
        public ActionResult<GenericCommandResult> MarkAsDone(
            Guid id,
            [FromServices] Handler handler
        )
        {
            string? userClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userClaim is null)
                return Unauthorized();
            Guid userId = new(userClaim);

            MarkTodoItemAsDoneCommand command = new(id, userId);
            return Created("TodoItem", (GenericCommandResult)handler.Handle(command));
        }
        
        [HttpPut("mark-as-undone/{id:Guid}")]
        [ProducesResponseType(typeof(GenericCommandResult), StatusCodes.Status200OK)]
        public ActionResult<GenericCommandResult> MarkAsUndone(
            Guid id,
            [FromServices] Handler handler
        )
        {
            string? userClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userClaim is null)
                return Unauthorized();
            Guid userId = new(userClaim);

            MarkTodoItemAsUndoneCommand command = new(id,userId);
            return Created("TodoItem", (GenericCommandResult)handler.Handle(command));
        }

    }
}
