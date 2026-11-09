
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shooping.Data.Entities;
using Shooping.Data;

public class CountriesController : Controller
{
    private readonly DataContext _context;

    public CountriesController(DataContext context)
    {
        _context = context;
    }

    // GET: COUNTRYS
    [HttpGet]
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Countries.ToListAsync());
    }

    // GET: COUNTRYS/Details/5
    [HttpGet]
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var country = await _context.Countries
            .FirstOrDefaultAsync(m => m.Id == id);
        if (country == null)
        {
            return NotFound();
        }

        return View(country);
    }

    // GET: COUNTRYS/Create
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // POST: COUNTRYS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Country country)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _context.Add(country);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                {
                    ModelState.AddModelError(string.Empty, "Ya existe un pais con el mismo nombre.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
            }
        }
        
        return View(country);
    }

    // GET: COUNTRYS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var country = await _context.Countries.FindAsync(id);
        if (country == null)
        {
            return NotFound();
        }
        return View(country);
    }

    // POST: COUNTRYS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, Country country)
    {
        if (id != country.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(country);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                {
                    ModelState.AddModelError(string.Empty, "Ya existe un pais con el mismo nombre.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
            }
        }
        return View(country);
    }

    // GET: COUNTRYS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var country = await _context.Countries.FindAsync(id);
        if (country == null)
        {
            return NotFound();
        }

        return View(country);
    }

    // POST: COUNTRYS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var country = await _context.Countries.FindAsync(id);
        if (country != null)
        {
            _context.Countries.Remove(country);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
