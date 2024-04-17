using Microsoft.AspNetCore.Mvc;
using NoteApp.Models;
using NoteApp.Data;
using System.Linq;

public class NotesController : Controller
{
    private readonly ApplicationDbContext _context;

    public NotesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Notes/Add
    public IActionResult Add()
    {
        return View();
    }

    // POST: Notes/Add
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(Note note)
    {
        if (ModelState.IsValid)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();
            return RedirectToAction("List");
        }
        return View(note);
    }

    // GET: Notes/List
    public IActionResult List()
    {
        var notes = _context.Notes.ToList();
        return View(notes);
    }
}
