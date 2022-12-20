using Microsoft.AspNetCore.Mvc;
using MyTodo.Domain.Exceptions;
using MyTodo.Domain.InputModels;
using MyTodo.Domain.Models;
using MyTodo.Domain.Services;
using System.Net;

namespace MyTodo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : Controller
    {
        private readonly ITodoListService todoListService;

        public TodoListController(ITodoListService todoListService)
        {
            this.todoListService = todoListService;
        }

        [HttpGet("search/{userId:int}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TodoListItemModel>>> SearchByUserIdAsync(int userId)
        {
            return Ok(await todoListService.SearchByAuthorIdAsync(userId));
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateTodoListInputModel inputModel)
        {
            try
            {
                await todoListService.CreateAsync(inputModel);
            }
            catch (TodoListCretionException ex) 
            {
                return BadRequest(ex.Message);
            }
            
            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<bool>> UpdateAsync(UpdateTodoListInputModel inputModel)
        {
            if (!await todoListService.UpdateAsync(inputModel)) 
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<bool>> DeleteByIdAsync([FromRoute] int id)
        {
            if(!await todoListService.DeleteAsync(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
