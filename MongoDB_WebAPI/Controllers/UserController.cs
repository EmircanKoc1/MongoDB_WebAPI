using BusinessLayer.Services.Abstracts;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MongoDB_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserMongoRepository _repository;
        private readonly IUserService _userService;
        public UserController(IUserMongoRepository repository, IUserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
            => Ok(await _userService.GetAllAsync());

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
            => Ok(await _repository.GetByIdAsync(id));


        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] User entity)
        {
            await _repository.AddAsync(entity);
            return Ok();
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] User entity)
        {
            var foundedUser = await _repository.UpdateOneAsync(x => x.UserName == entity.UserName, entity);

            return Ok(foundedUser);

        }

    }
}
