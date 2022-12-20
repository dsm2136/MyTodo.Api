using Microsoft.AspNetCore.Mvc;
using MyTodo.Domain.InputModels;
using MyTodo.Domain.Models;
using MyTodo.Domain.Services;
using System.Net;

namespace MyTodo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListItemController : ControllerBase
    {
        private readonly ITodoListItemService todoListItemService;

        public TodoListItemController(ITodoListItemService todoListItemService)
        {
            this.todoListItemService = todoListItemService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<TodoListItemModel>> GetByIdAsync([FromRoute] int id)
        {
            var task = await todoListItemService.GetByIdAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpGet("search/{userId:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TodoListItemModel>>> SearchByListIdAsync(int listId)
        {
            return Ok(await todoListItemService.SearchByTodoListIdAsync(listId));
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateListItemInputModel inputModel)
        {
            await todoListItemService.CreateAsync(inputModel);
            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult<bool>> UpdateAsync(UpdateListItemInputModel inputModel)
        {
            if (!await todoListItemService.UpdateAsync(inputModel))
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
            if (!await todoListItemService.DeleteByIdAsync(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
