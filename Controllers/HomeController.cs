using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using HealthHome.Models;
using Microsoft.AspNetCore.Mvc;
using HealthHome___C_.Models.ViewModels;


namespace HealthHome.Controllers;
[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private HealthHomeDbContext _dbContext;
    public HomeController(HealthHomeDbContext context)
    {
        _dbContext = context;
    }

    [HttpPost("/checkuser")]
    public IActionResult CheckUser(CheckUserRequest checkUserRequest)
    {
        User user = _dbContext.Users.FirstOrDefault(u => u.Uid == checkUserRequest.uid);
        if (user == null)
        {
            return NotFound(new { valid = false });
        }
        return Ok(user);
    }


    [HttpPost("/first_login_check")]
    public IActionResult FirstLoginCheck(FirstLoginCheckRequest firstLoginCheckRequest)
    {
        User user = _dbContext.Users.FirstOrDefault(u =>
            u.FirstName == firstLoginCheckRequest.firstName &&
            u.LastName == firstLoginCheckRequest.lastName &&
            u.Birthdate == firstLoginCheckRequest.birthdate &&
            u.Ssn.EndsWith(firstLoginCheckRequest.ssn)
            );
        if (user == null)
        {
            return NotFound(new { valid = false });
        }
        user.Uid = firstLoginCheckRequest.uid;
        _dbContext.SaveChanges();
        return Ok(user);
    }

}

