using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using HealthHome.Models;
using Microsoft.AspNetCore.Mvc;
using HealthHome___C_.Models.ViewModels;

namespace HealthHome.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private HealthHomeDbContext _dbContext;

    public UserController(HealthHomeDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    public IActionResult Get() 
    { 
        return Ok(_dbContext.Users.ToList());
    }

    // FIND SINGLE USER W/ DETAILS
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        User user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound(new {valid = false});
        }

        return Ok(user);
    }

    // FIND USER
    

    // CREATING A USER
    //[HttpPost]
    //public IActionResult CreateUser(User user)
    //{
    //    User checkUser = db.Users.FirstOrDefault(u => u.Uid == newUser.Uid);
    //    if (checkUser != null)
    //    {
    //        try
    //        {
    //            db.Users.Add(newUser);
    //            db.SaveChanges();
    //            return Results.Created($"/users/{newUser.Id}", newUser);
    //        }
    //        catch (DbUpdateException)
    //        {
    //            return Results.BadRequest("Invalid data submitted");
    //        }
    //    }
    //    else
    //    { 
    //        return Results.Conflict("User already exists");
    //    }
    //});

    //// EDITING A USER
    //app.MapPut("/user/{id}/edit", (HealthHomeDbContext db, int id, User updateUserInfo) =>
    //{
    //    User userToUpdate = db.Users.SingleOrDefault(u => u.Id == id);
    //    if (userToUpdate == null)
    //    {
    //        return Results.NotFound();
    //    }
    //    userToUpdate.FirstName = updateUserInfo.FirstName;
    //    userToUpdate.LastName = updateUserInfo.LastName;
    //    userToUpdate.Email = updateUserInfo.Email;
    //    userToUpdate.Address = updateUserInfo.Address;

    //    db.SaveChanges();
    //    return Results.NoContent();
    //});
}

