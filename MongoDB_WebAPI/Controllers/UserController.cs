using BusinessLayer.Services.Abstracts;
using Core.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace MongoDB_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
            => Ok(await _userService.GetAllAsync());

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] string id)
            => Ok(await _userService.GetByIdAsync(id));

        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] UserCreateDto dto)
        {
            await _userService.AddAsync(dto);
            return Ok();
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UserUpdateDto dto)
            => Ok(await _userService.UpdateOneByIdAsync(id, dto));


        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] string id)
            => Ok(await _userService.DeleteOneByIdAsync(id));

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete([FromBody] UserDeleteDto dto)
           => Ok(await _userService.DeleteOneByIdAsync(dto));

    }
}
