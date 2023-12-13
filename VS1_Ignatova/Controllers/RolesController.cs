using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using VS1_Ignatova.Models;
using VS1_Ignatova.Models.Enums;
using VS1_Ignatova.ViewModels.Role;

namespace VS1_Ignatova.Controllers
{
    [Authorize(Roles = "admin")]
    public class RolesController : Controller
    {
        private readonly AppCtx _context;

        public RolesController(AppCtx context)
        {
            _context = context;
        }

        // GET: Roles
        public async Task<IActionResult> Index(string code, string name, short? formOfEdu,
            int page = 1,
            RoleSortState sortOrder = RoleSortState.CodeAsc)
        {
            IdentityUser user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);

            int pageSize = 15;

            //фильтрация
            IQueryable<Role> specialties = _context.Roles
                .Include(s => s.FormOfStudy)                    // связываем специальности с формами обучения
                .Where(w => w.FormOfStudy.IdUser == user.Id);    // в формах обучения есть поле с внешним ключом пользователя


            if (!String.IsNullOrEmpty(code))
            {
                specialties = specialties.Where(p => p.RoleUser.Contains(code));
            }


            // сортировка
            switch (sortOrder)
            {
                case RoleSortState.CodeDesc:
                    specialties = specialties.OrderByDescending(s => s.RoleUser);
                    break;
            }

            // пагинация
            var count = await specialties.CountAsync();
            var items = await specialties.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формируем модель представления
            IndexRoleViewModel viewModel = new()
            {
                PageViewModel = new(count, page, pageSize),
                SortRoleViewModel = new(sortOrder),
               /* FilterRoleViewModel = new(code, name, _context.FormsOfStudy.ToList(), formOfEdu),
                Roles = items*/
            };
            return View(viewModel);
        }

        // GET: Roles/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null || _context.Role == null)
            {
                return NotFound();
            }

            var role = await _context.Role
                .FirstOrDefaultAsync(m => m.Id == id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoleUser")] Role role)
        {
            if (ModelState.IsValid)
            {
                _context.Add(role);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }

        // GET: Roles/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null || _context.Role == null)
            {
                return NotFound();
            }

            var role = await _context.Role.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("Id,RoleUser")] Role role)
        {
            if (id != role.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(role);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoleExists(role.Id))
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
            return View(role);
        }

        // GET: Roles/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null || _context.Role == null)
            {
                return NotFound();
            }

            var role = await _context.Role
                .FirstOrDefaultAsync(m => m.Id == id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            if (_context.Role == null)
            {
                return Problem("Entity set 'AppCtx.Role'  is null.");
            }
            var role = await _context.Role.FindAsync(id);
            if (role != null)
            {
                _context.Role.Remove(role);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoleExists(short id)
        {
          return (_context.Role?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
