
using Maxim.DAL;
using Maxim.Models;
using Maxim.ViewModels.ServiceVm;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Maxim.Areas.Admin.Controllers
{
    public class ServiceController : Controller
    {
        private readonly AppDbContext _context;

        public ServiceController(AppDbContext context)
        {
            _context = context;
        }
        public async Task <IActionResult> Index()
        {
             List<Service> list =await _context.Service.ToListAsync();
            return View(list);
        }
        public async Task<IActionResult> Create(int id)
        {
            Service service = await _context.Service.Where(x=>x.Id==id).FirstOrDefaultAsync();
            return View(service);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ServiceCreateVm createVm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Service service = new Service()
            {
                Title = createVm.Title,
                Description = createVm.Description,
                IconUrl = createVm.IconUrl,
            };
            await _context.Service.AddAsync(service);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var oldService = await _context.Service.Where(x=>x.Id==id).FirstOrDefaultAsync();
            if(oldService is not null)
            {
                _context.Service.Remove(oldService);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Service");
        }
    }
}
