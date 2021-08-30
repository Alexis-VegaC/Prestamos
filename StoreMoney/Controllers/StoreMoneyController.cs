using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreMoney.Data;
using StoreMoney.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMoney.Controllers
{
    [Authorize]
    public class StoreMoneyController : Controller
    {
        private List<StoresMoney> Stores;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        public StoreMoneyController(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
            Stores = new List<StoresMoney>();
        }

        public IActionResult Red() {
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> StateAccount()
        {
            var userName = HttpContext.User.Identity.Name!;
            var user = await _userManager.FindByNameAsync(userName);

            var storeUser = _context.StoreMoney.Include( x => x.Movements )
                .Where(x => x.UserId == user.Id).FirstOrDefault();

            if (storeUser==null) {

                StoresMoney store = new StoresMoney
                { 
                    Amount = 0,
                    UserId = user.Id
                }; 

                _context.StoreMoney.Add(store);
                _context.SaveChanges();

                storeUser = store;
            }
             
            return View(storeUser);
        }

        public IActionResult Pay()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPay(Movement movement) {
            var userName = HttpContext.User.Identity.Name!;
            var user = await _userManager.FindByNameAsync(userName);
            var storeMoney = _context.StoreMoney.Where(x => x.UserId == user.Id).FirstOrDefault();

            var newMovement = new Movement {
                Operation = "Abono",
                Date = DateTime.Now,
                Quantity = movement.Quantity,
                StoreMoneyId = storeMoney.StoresMoneyId,
                Description = movement.Description
            };

            _context.Movements.Add(newMovement);
            _context.SaveChanges();

            storeMoney.Amount = storeMoney.Amount + movement.Quantity;
            _context.StoreMoney.Update(storeMoney);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Remove()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RemoveDb(Movement movement)
        {
            var userName = HttpContext.User.Identity.Name!;
            var user = await _userManager.FindByNameAsync(userName);
            var storeMoney = _context.StoreMoney.Where(x => x.UserId == user.Id).FirstOrDefault();

            var newMovement = new Movement
            {
                Operation = "Retiro",
                Date = DateTime.Now,
                Quantity = movement.Quantity,
                StoreMoneyId = storeMoney.StoresMoneyId
            };

            _context.Movements.Add(newMovement);
            _context.SaveChanges();

            storeMoney.Amount = storeMoney.Amount - movement.Quantity;
            _context.StoreMoney.Update(storeMoney);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
