using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TODO.Domain.Commands;
using TODO.Domain.Entities;
using TODO.Domain.Handlers;
using TODO.Domain.Repositories;

namespace TODO.Api.Controllers
{
    [Route("api/v1/todos")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoItemRepository _ITodoItemRepository;

        public TodoController([FromServices] ITodoItemRepository todoItemRepository)
        {
            this._ITodoItemRepository = todoItemRepository;
        }


        [HttpGet("")]
        [Authorize]
        [ProducesResponseType(typeof(IEnumerable<TodoItem>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<TodoItem>> GetAll(string user)
        {
            return Ok(_ITodoItemRepository.GetAll(user));
        }

        [HttpGet("today")]
        [ProducesResponseType(typeof(IEnumerable<TodoItem>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<TodoItem>> GetToday(string user, bool done)
        {
            return Ok(_ITodoItemRepository.GetByPeriod(user, DateTime.Now, done));
        }

        [HttpGet("yesterday")]
        [ProducesResponseType(typeof(IEnumerable<TodoItem>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<TodoItem>> GetYesterday(string user, bool done)
        {
            var date = DateTime.Today.AddDays(-1);
            return Ok(_ITodoItemRepository.GetByPeriod(user, date, done));
        }

        [HttpGet("tomorow")]
        [ProducesResponseType(typeof(IEnumerable<TodoItem>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<TodoItem>> GetTomorow(string user, bool done)
        {
            var date = DateTime.Today.AddDays(1);
            return Ok(_ITodoItemRepository.GetByPeriod(user, date, done));
        }
        
        [HttpPost("")]
        [ProducesResponseType(typeof(GenericCommandResult), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<GenericCommandResult> Create(
            [FromBody] CreateTodoItemCommand createTodoItemCommand,
            [FromServices] Handler handler
        )
        {
            createTodoItemCommand.User = "nelsondossantos";
            return Created("TodoItem",(GenericCommandResult)handler.Handle(createTodoItemCommand));
        }
        [HttpPut("")]
        [ProducesResponseType(typeof(GenericCommandResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<GenericCommandResult> Update(
            [FromBody] UpdateTodoItemCommand updateTodoItemCommand,
            [FromServices] Handler handler
        )
        {
            updateTodoItemCommand.User = "nelsondossantos";
            return Created("TodoItem",(GenericCommandResult)handler.Handle(updateTodoItemCommand));
        }
    }
}
