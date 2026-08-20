using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebProject.Data;
using MyWebProject.DTOs;
using MyWebProject.Models;

namespace MyWebProject.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class NotesController : ControllerBase
{
    private readonly AppDbContext _context;

    public NotesController(AppDbContext context)
    {
        _context = context;
    }

    // GET ALL MY NOTES

    [HttpGet]
    public async Task<IActionResult> GetNotes()
    {
        var userId = GetUserId();

        var notes = await _context.Notes
            .Where(n => n.UserId == userId)
            .ToListAsync();

        return Ok(notes);
    }


    // GET NOTE BY ID

    [HttpGet("{id}")]
    public async Task<IActionResult> GetNote(int id)
    {
        var userId = GetUserId();

        var note = await _context.Notes
            .FirstOrDefaultAsync(n =>
                n.Id == id &&
                n.UserId == userId);

        if (note == null)
        {
            return NotFound(new
            {
                message = "Note not found."
            });
        }

        return Ok(note);
    }


    // CREATE NOTE

    [HttpPost]
    public async Task<IActionResult> CreateNote(
        CreateNoteRequest request)
    {
        var userId = GetUserId();

        var note = new Note
        {
            Title = request.Title,
            Content = request.Content,
            UserId = userId
        };

        _context.Notes.Add(note);

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetNote),
            new { id = note.Id },
            note);
    }


    // UPDATE NOTE

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateNote(
        int id,
        UpdateNoteRequest request)
    {
        var userId = GetUserId();

        var note = await _context.Notes
            .FirstOrDefaultAsync(n =>
                n.Id == id &&
                n.UserId == userId);

        if (note == null)
        {
            return NotFound(new
            {
                message = "Note not found."
            });
        }

        note.Title = request.Title;
        note.Content = request.Content;

        await _context.SaveChangesAsync();

        return Ok(note);
    }


    // DELETE NOTE

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNote(int id)
    {
        var userId = GetUserId();

        var note = await _context.Notes
            .FirstOrDefaultAsync(n =>
                n.Id == id &&
                n.UserId == userId);

        if (note == null)
        {
            return NotFound(new
            {
                message = "Note not found."
            });
        }

        _context.Notes.Remove(note);

        await _context.SaveChangesAsync();

        return NoContent();
    }


    // GET CURRENT USER ID

    private int GetUserId()
    {
        var userId = User.FindFirstValue(
            ClaimTypes.NameIdentifier);

        return int.Parse(userId!);
    }
}