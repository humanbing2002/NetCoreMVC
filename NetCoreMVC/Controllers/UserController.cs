using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NetCoreMVC.Models.DBModel;
using Dapper;

namespace NetCoreMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly MvcdbContext _context;
        private readonly IConfiguration _configuration;
        public UserController(MvcdbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            return View(await _context.dbUser.ToListAsync());
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbUser = await _context.dbUser
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dbUser == null)
            {
                return NotFound();
            }

            return View(dbUser);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,EmpNo,Phone,Adress")] dbUser dbUser)
        {
            if (ModelState.IsValid)
            {
                dbUser.ID = Guid.NewGuid();
                _context.Add(dbUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dbUser);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbUser = await _context.dbUser.FindAsync(id);
            if (dbUser == null)
            {
                return NotFound();
            }
            return View(dbUser);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name,EmpNo,Phone,Adress")] dbUser dbUser)
        {
            if (id != dbUser.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!dbUserExists(dbUser.ID))
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
            return View(dbUser);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbUser = await _context.dbUser
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dbUser == null)
            {
                return NotFound();
            }

            return View(dbUser);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var dbUser = await _context.dbUser.FindAsync(id);
            _context.dbUser.Remove(dbUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public dbUser GetFirstUser()
        {
            using (var cn = new SqlConnection(_configuration.GetValue<string>("ConnectionStrings:DBConectString")))
            {
                string sql = $"SELECT * FROM dbo.dbUser ";
                var result = cn.Query<dbUser>(sql).ToList();

                if (result.Count() > 0)
                {
                    return result.FirstOrDefault();
                }
            }
            return null;

        }
        private bool dbUserExists(Guid id)
        {
            return _context.dbUser.Any(e => e.ID == id);
        }
    }
}
