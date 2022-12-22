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
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<UserModel>> GetByIdAsync([FromRoute] int id)
        {
            var user = await userService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUserInputModel inputModel)
        {
            try
            {
                await userService.InsertAsync(inputModel);
            }
            catch (UserCreationException ex)
            {
                return BadRequest(ex.Message);
            }
            
            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult<bool>> UpdateAsync(UpdateUserInputModel inputModel)
        {
            bool result;
            
            try
            {
                result = await userService.UpdateAsync(inputModel);
            }
            catch (UserCreationException ex)
            {
                return BadRequest(ex.Message);
            }
            
            if (!result)
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
            if (!await userService.DeleteByIdAsync(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
