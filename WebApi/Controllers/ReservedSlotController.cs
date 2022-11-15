using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ReservedSlotController : ControllerBase
{
    private readonly DataContext _context;

    public ReservedSlotController(DataContext context)
    {
        _context = context;
    }

    [HttpGet("")]
    public ReservedSlot[] Get()
    {
        return _context.Slots
            .OrderBy(p => p.Id)
            .ToArray();
    }

    [HttpGet("{date}")]
    public IActionResult GetSlotByDate(DateTimeOffset date)
    {
        var post = _context.Slots.Where(s => s.Date.UtcDateTime == date.UtcDateTime).ToArray();

        if (post == null)
        {
            return NotFound();
        }

        return Ok(post);
    }

    [HttpGet("search/{index}&{date}")]
    public IActionResult GetSlotByIndex(int index, DateTimeOffset date)
    {
        var post = _context.Slots.Where(s => s.Index == index).Where(s => s.Date.UtcDateTime == date.UtcDateTime).ToArray();

        if (post == null)
        {
            return NotFound();
        }

        return Ok(post);
    }

    [HttpDelete("search/{index}&{date}")]
    public async Task<IActionResult> DeleteSlotByIndexAndDate(int index, DateTimeOffset date)
    {
        var post = _context.Slots.Where(s => s.Index == index).Where(s => s.Date.UtcDateTime == date.UtcDateTime).ToArray();
        if (post == null)
        {
            return NotFound();
        }

        _context.Slots.Remove(post[0]);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost("")]
    public async Task<IActionResult> Create(ReservedSlot slot)
    {
        slot.Date = slot.Date.UtcDateTime.Date;
        _context.Slots.Add(slot);
        await _context.SaveChangesAsync();

        return Ok(slot);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSlot(int id)
    {
        var post = await _context.Slots.FindAsync(id);
        if (post == null)
        {
            return NotFound();
        }

        _context.Slots.Remove(post);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ReservedSlot newSlot)
    {
        if (id != newSlot.Id)
        {
            return BadRequest();
        }

        var slotExists = await _context.Slots.AnyAsync(p => p.Id == id);

        if(!slotExists)
        {
            return NotFound();
        }
    
        _context.Slots.Update(newSlot);
        await _context.SaveChangesAsync();           
    
        return NoContent();
    }
}