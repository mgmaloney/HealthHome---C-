using HealthHome.Models;
using HealthHome.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthHome.Controllers;

[ApiController]
[Route("/patientmeds")]
public class PatientMedController : ControllerBase
{
    private HealthHomeDbContext _dbContext;

    public PatientMedController(HealthHomeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPut("get_all_patient_meds")]
    public IActionResult getAllPatientMeds(PatientMedRequest request)
    {
        var patientMeds = _dbContext.PatientMeds.Where(m => m.PatientId == request.PatientId).ToList();
        if (patientMeds == null)
        {
            return BadRequest();
        }
        return Ok(patientMeds);
    }

    [HttpPost]
    public IActionResult CreatePatientmed(PatientMed patientMed)
    {
        var newPatientMed = _dbContext.PatientMeds.Add(patientMed);
        _dbContext.SaveChanges();
        return Ok(newPatientMed);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePatientMed(PatientMed patientMed)
    {
        var dbMed = _dbContext.PatientMeds.FirstOrDefault(m => m.Id == patientMed.Id);
        if (dbMed == null)
        {
            return NotFound();
        }

        dbMed.Name = patientMed.Name;
        dbMed.Route = patientMed.Route;
        dbMed.Dose = patientMed.Dose;

        _dbContext.SaveChanges();
        return Ok();

    }

    [HttpDelete("{id}")]
    public IActionResult DeletePatientMed(int id)
    {
        var medToDelete = _dbContext.PatientMeds.FirstOrDefault(p => p.Id == id);
        _dbContext.PatientMeds.Remove(medToDelete);
        _dbContext.SaveChanges();
        return Ok();
    }

}


