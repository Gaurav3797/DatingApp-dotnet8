﻿using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API;

[ApiController]
[Route("api/[Controller]")]  // /api/users
public class UsersController(DataContext context) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users =await context.Users.ToListAsync();
        
        return users;
    } 

      [HttpGet("{id:int}")]  // api/useres/1
    public async Task<ActionResult<AppUser>> GetUsers(int id)
    {
        var user = await context.Users.FindAsync(id);
        
        if (user == null)
        return NotFound();

        return user;
    } 

}