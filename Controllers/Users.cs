using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using HealthHome.Models;
using Microsoft.AspNetCore.Mvc;
using HealthHome___C_.Models.ViewModels;
using HealthHome.Models.ViewModels;
using Newtonsoft.Json;



namespace HealthHome.Controllers;

[ApiController]
[Route("/users")]
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

    [HttpPut("get_user_name")]
    public IActionResult getUserName(MessageUserIdRequest request)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.Id == request.UserId);
        if (user == null)
        {
            return NotFound(new {valid = false});
        }
        else
        {
            var userObj = new { userName = $"{user.FirstName} {user.LastName}" };
            return Ok(JsonConvert.SerializeObject(userObj));
        }
    }

    [HttpPut("get_providers_and_admins")]
    public IActionResult getProvidersAndAdmins()
    {
        var providersAndAdmins = _dbContext.Users.Where(u=> u.Admin == true || u.Provider == true).ToList();
        if (providersAndAdmins == null)
        {
            return NotFound();
        }
        return Ok(providersAndAdmins);
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

