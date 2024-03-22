using HealthHome;
using HealthHome.Models;
using HealthHome.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HealthHome___C_.Controllers;

[ApiController]
[Route("/allergies")]
public class AllergyController : ControllerBase
{
    private HealthHomeDbContext _dbContext;

    public AllergyController(HealthHomeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost()]
    public IActionResult CreateAllergy(Allergy allergy)
    {
        try
        {
            _dbContext.Allergies.Add(allergy);
            _dbContext.SaveChanges();
            return Created($"/allergies/{allergy.Id}", allergy);

        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAllergy(Allergy allergy)
    {
        var dbAllergy = _dbContext.Allergies.FirstOrDefault(a => a.Id == allergy.Id);
        if (dbAllergy == null)
        {
            return BadRequest();
        }
        else
        {
            dbAllergy.Name = allergy.Name;
            dbAllergy.Severity = allergy.Severity;
            dbAllergy.Reaction = allergy.Reaction;
            _dbContext.SaveChanges();
            return Ok();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAllergy(int id) {
        var dbAllergy = _dbContext.Allergies.FirstOrDefault(a=> a.Id == id);
        if (dbAllergy == null)
        {
            return BadRequest();
        }
        else
        {
            _dbContext.Remove(dbAllergy);
            _dbContext.SaveChanges();
            return Ok();
        }
    }

    [HttpPut("patient_allergies")]
    public IActionResult getPatientAllergies(PatientAllergiesRequest request)
    {
        var allergies = _dbContext.Allergies.Where(a => a.PatientId == request.PatientId);
        return Ok(allergies.ToList());
    }
}

