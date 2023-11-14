using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Models;

[Route("api/[controller]")]
[ApiController]
public class ToDoController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ToDoController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ToDoItemModel>>> GetTodoItems()
    {
        return await _context.ToDoItems.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ToDoItemModel>> GetTodoItem(int id)
    {
        var todoItem = await _context.ToDoItems.FindAsync(id);

        if (todoItem == null)
        {
            return NotFound();
        }

        return todoItem;
    }

    [HttpPost]
    public async Task<ActionResult<ToDoItemModel>> PostTodoItem(ToDoItemModel item)
    {
        _context.ToDoItems.Add(item);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTodoItem), new { id = item.ItemId }, item);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutTodoItem(int id, ToDoItemModel item)
    {
        if (id != item.ItemId)
        {
            return BadRequest();
        }

        _context.Entry(item).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodoItem(int id)
    {
        var todoItem = await _context.ToDoItems.FindAsync(id);

        if (todoItem == null)
        {
            return NotFound();
        }

        _context.ToDoItems.Remove(todoItem);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
