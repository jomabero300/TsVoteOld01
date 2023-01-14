using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using TsVote.Data;
using TsVote.Data.Entities.Gene;
using TsVote.Models.ViewsModelGene;

namespace TsVote.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CountriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Countries
        public async Task<IActionResult> Index()
        {
              return View(await _context.Countries.Include(x=>x.States).ToListAsync());
        }

        // GET: Countries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Countries == null)
            {
                return NotFound();
            }

            Country model = await _context.Countries.Include(x=>x.States)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // GET: Countries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Countries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Country model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
                catch(DbUpdateException ex)
                {
                    if(ex.InnerException.Message.Contains("duplicat"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un país con el mismo nombre");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(model);
        }

        // GET: Countries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Countries == null)
            {
                return NotFound();
            }

            Country model = await _context.Countries.FindAsync(id);

            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Country model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
                catch (DbUpdateException ex)
                {
                    if (ex.InnerException.Message.Contains("duplicat"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un país con el mismo nombre");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(model);
        }

        // GET: Countries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Countries == null)
            {
                return NotFound();
            }

            Country model = await _context.Countries
                .Include(x=>x.States)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Countries == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Countries'  is null.");
            }

            Country model = await _context.Countries.FindAsync(id);

            if (model != null)
            {
                try
                {
                    _context.Countries.Remove(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if(ex.InnerException.Message.Contains("REFERENCE"))
                    {
                        ModelState.AddModelError(string.Empty, "No se puede borrar el país porque tiene registros relacionados");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "No existe elpais");

            }

            return View(model);

        }

        public async Task<IActionResult> AddState(int? id)
        {
            if (id == null || _context.Countries == null)
            {
                return NotFound();
            }

            Country model = await _context.Countries.FindAsync((int)id);

            if (model == null)
            {
                return NotFound();
            }

            return View(new StateViewModel { CountryId = model.Id }) ;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddState([Bind("Id,CountryId,Name")] StateViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    State state = new()
                    {
                        Cities=new List<City> (),
                        Country = await _context.Countries.FindAsync(model.CountryId),
                        Name = model.Name,
                    };

                    _context.Add(state);

                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Details), new { id=model.CountryId});

                }
                catch (DbUpdateException ex)
                {
                    if (ex.InnerException.Message.Contains("duplicat"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un departamento con el mismo nombre en este país");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(model);
        }

        // GET: Countries/EditSatate/5
        public async Task<IActionResult> EditState(int? id)
        {
            if (id == null || _context.States == null)
            {
                return NotFound();
            }

            State state = await _context.States
                .Include(x=>x.Country)
                .FirstOrDefaultAsync(x=>x.Id== id);

            if (state == null)
            {
                return NotFound();
            }

            StateViewModel model = new()
            {
                Id = state.Id,
                CountryId = state.Country.Id,
                Name = state.Name
            };

            return View(model);
        }

        // POST: Countries/EditSatate/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditState(int id, [Bind("Id,CountryId,Name")] StateViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(new State { Id= model.Id,Name=model.Name });

                    await _context.SaveChangesAsync();
                    
                    return RedirectToAction(nameof(Details),new {id=model.CountryId});
                }
                catch (DbUpdateException ex)
                {
                    if (ex.InnerException.Message.Contains("duplicat"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un departamento con el mismo nombre en este país");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(model);
        }


        private bool CountryExists(int id)
        {
          return _context.Countries.Any(e => e.Id == id);
        }
    }
}
