using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using HealthHome.Models;
using Microsoft.AspNetCore.Mvc;
using HealthHome___C_.Models.ViewModels;
using HealthHome;

[ApiController]
[Route("/patients")]

public class PatientController : ControllerBase
{
    private HealthHomeDbContext _dbContext;

    public PatientController(HealthHomeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public IActionResult CreatePatient(User user)
    {
        try
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return Created($"/users/{user.Id}", user);
        }
        catch (DbUpdateException)
        {
            return BadRequest("Invalid data submitted");
        }
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_dbContext.Users.Where(u => u.Provider == false && u.Admin == false).ToList());
    }

    [HttpPut("get_single_patient")]
    public IActionResult GetSingle(PatientIdRequest patientIdRequest)
    {
        //if (patientIdRequest.PatientId == null)
        //{
        //    return BadRequest();
        //}
        User user = _dbContext.Users.FirstOrDefault(user => user.Id == patientIdRequest.PatientId);
        if (user == null)
        {
            return BadRequest();
        }
        return Ok(user);
    }

    [HttpPut]
    public IActionResult UpdatePatient(User user)
    {
        try
        {
            User patient = _dbContext.Users.FirstOrDefault(u => u.Id == user.Id);
            patient.FirstName = user.FirstName;
            patient.LastName = user.LastName;
            patient.PhoneNumber = user.PhoneNumber;
            patient.Sex = user.Sex;
            patient.Gender = user.Gender;
            patient.Email = user.Email;
            patient.Address = user.Address;
            patient.Birthdate = user.Birthdate;
            patient.Ssn = user.Ssn;
            _dbContext.SaveChanges();
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}