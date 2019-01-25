using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MtgCollectionMgr.Models;

namespace MtgCollectionMgr.Controllers
{
    public class CardModelsController : Controller
    {
        private readonly MtgCollectionMgrContext _context;

        public CardModelsController(MtgCollectionMgrContext context)
        {
            _context = context;
        }

        // GET: CardModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.CardModels.ToListAsync());
        }

        // GET: CardModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardModel = await _context.CardModels
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cardModel == null)
            {
                return NotFound();
            }

            return View(cardModel);
        }

        // GET: CardModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CardModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ImageUrl,ID")] CardModel cardModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cardModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cardModel);
        }

        // GET: CardModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardModel = await _context.CardModels.FindAsync(id);
            if (cardModel == null)
            {
                return NotFound();
            }
            return View(cardModel);
        }

        // POST: CardModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,ImageUrl,ID")] CardModel cardModel)
        {
            if (id != cardModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cardModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardModelExists(cardModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cardModel);
        }

        // GET: CardModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardModel = await _context.CardModels
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cardModel == null)
            {
                return NotFound();
            }

            return View(cardModel);
        }

        // POST: CardModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cardModel = await _context.CardModels.FindAsync(id);
            _context.CardModels.Remove(cardModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardModelExists(int id)
        {
            return _context.CardModels.Any(e => e.ID == id);
        }
    }
}
