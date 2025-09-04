using AutoMapper;
using LoginUsers.Data;
using LoginUsers.Data.Dtos.UserDtos;
using LoginUsers.Models;
using LoginUsers.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LoginUsers.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private readonly RegisterService _registerService;

    public UserController(RegisterService registerService)
    {
        _registerService = registerService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateUserDto create)
    {
        try
        {
             await _registerService.RegisterAsync(create);
            return Ok($"{create.Username} cadastrado com sucesso");
        }
        catch (Exception)
        {
            return StatusCode(500, "Ocorreu um erro no servidor");
        }
    }
}
