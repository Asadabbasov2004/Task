

using Pronia_MVC.Areas.Admin.ViewModels.Setting;

namespace Pronia_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SettingController : Controller
    {
        AppDbContext _db;
        public SettingController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Setting> settingList = _db.Setting.ToList();
            return View(settingList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSettingVm settingvm)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            Setting setting = new Setting()
            {
                Key = settingvm.Key,
                Value = settingvm.Value,
            };
            await _db.Setting.AddAsync(setting);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var setting = _db.Setting.FirstOrDefault(s => s.Id == id);

            _db.Setting.Remove(setting);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Update(int id)
        {
            Setting setting = _db.Setting.Find(id);
            if (setting == null)
            {
                return View("Error");
            }

            UpdateSettingVm updateSettingVM = new UpdateSettingVm
            {
                Id = setting.Id,
                Key = setting.Key,
                Value = setting.Value
            };

            return View(updateSettingVM);
        }




        [HttpPost]
        public async Task<IActionResult> Update(UpdateSettingVm updatevm)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            UpdateSettingVm setting = new UpdateSettingVm()
            {
                Key = updatevm.Key,
                Value = updatevm.Value,

            };

            Setting oldSetting = await _db.Setting.Where(p => p.Id == updatevm.Id).FirstOrDefaultAsync();
            oldSetting.Key = updatevm.Key;
            oldSetting.Value = updatevm.Value;


            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
