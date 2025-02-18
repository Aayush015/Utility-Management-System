using Microsoft.AspNetCore.Mvc;
using UtilityServiceAPI.Data;
using UtilityServiceAPI.Models;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class EnergyConsumptionController : ControllerBase
{
    private readonly AppDbContext _context;

    public EnergyConsumptionController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EnergyConsumption>>> GetEnergyConsumptions()
    {
        return await _context.EnergyConsumptions.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EnergyConsumption>> GetEnergyConsumption(int id)
    {
        var consumption = await _context.EnergyConsumptions.FindAsync(id);
        if (consumption == null)
            return NotFound();

        return consumption;
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<EnergyConsumption>>> GetEnergyConsumptionByUser(int userId)
    {
        var consumptions = await _context.EnergyConsumptions
            .Where(ec => ec.UserId == userId)
            .ToListAsync();

        if (consumptions == null || consumptions.Count == 0)
            return NotFound();

        return consumptions;
    }

    [HttpPost]
    public async Task<ActionResult<EnergyConsumption>> CreateEnergyConsumption(EnergyConsumption consumption)
    {
        _context.EnergyConsumptions.Add(consumption);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetEnergyConsumption), new { id = consumption.Id }, consumption);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEnergyConsumption(int id, EnergyConsumption consumption)
    {
        if (id != consumption.Id)
            return BadRequest();

        _context.Entry(consumption).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEnergyConsumption(int id)
    {
        var consumption = await _context.EnergyConsumptions.FindAsync(id);
        if (consumption == null)
            return NotFound();

        _context.EnergyConsumptions.Remove(consumption);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}