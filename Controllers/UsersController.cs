using Microsoft.AspNetCore.Mvc;
using PocketBook.Models;
using PocketBook.Services;

namespace PocketBook.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(
    ILogger<UsersController> logger,
    InsertUserServices insertUserService,
    GetUserService getUserService,
    DeleteUserService deleteUserService
) : ControllerBase
{
    private readonly ILogger<UsersController> _logger = logger;
    private readonly InsertUserServices _insertUserService = insertUserService;
    private readonly GetUserService _getUserService = getUserService;
    private readonly DeleteUserService _deleteUserService = deleteUserService;

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _insertUserService.Execute(user);


        return CreatedAtAction("GetUser", new { user.Id }, user);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        var user = await _getUserService.Execute(id);

        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        if (await _getUserService.Execute(id) is null)
            return NotFound();


        await _deleteUserService.Execute(id);


        return NoContent();
    }
}