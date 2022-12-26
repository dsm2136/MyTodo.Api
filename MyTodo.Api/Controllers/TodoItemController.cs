using Microsoft.AspNetCore.Mvc;
using MyTodo.Domain.InputModels;
using MyTodo.Domain.Models;
using MyTodo.Domain.Services;
using System.Net;

namespace MyTodo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly ITodoItemService todoItemService;

        public TodoItemController(ITodoItemService todoListItemService)
        {
            this.todoItemService = todoListItemService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<TodoItemModel>> GetByIdAsync([FromRoute] int id)
        {
            var task = await todoItemService.GetByIdAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpGet("search/{userId:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IEnumerable<TodoItemModel>>> SearchByListIdAsync(int listId)
        {
            var tasks = await todoItemService.SearchByTodoListIdAsync(listId);

            if (tasks == null)
            {
                return NotFound();
            }

            return Ok(tasks);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateTodoItemInputModel inputModel)
        {
            await todoItemService.CreateAsync(inputModel);
            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult<bool>> UpdateAsync(UpdateListItemInputModel inputModel)
        {
            if (!await todoItemService.UpdateAsync(inputModel))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult<bool>> DeleteByIdAsync([FromRoute] int id)
        {
            if (!await todoItemService.DeleteByIdAsync(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
