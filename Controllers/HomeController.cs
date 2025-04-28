using System.Diagnostics;
using Homework_SkillTree.Data;

using Homework_SkillTree.Data;
using Homework_SkillTree.Models;
using Homework_SkillTree.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Homework_SkillTree.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SkillTreeContext _skillTreeContext;

        public HomeController(SkillTreeContext skillTreeContext,
                              ILogger<HomeController> logger)
        {
            _logger = logger;
            _skillTreeContext = skillTreeContext;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _skillTreeContext.Homework1s.ToListAsync();

            // 將資料庫實體轉換為視圖模型
            var viewModels = data.Select(h => new HomeViewModel
            {
                Category = h.Category,
                Money = h.Money,
                CreateDate = h.CreateDate,
                Description = h.Description
            }).ToList();

            return View(viewModels);
        }


        [HttpGet]
        public IActionResult Add()
        {
            // 返回一個新的 HomeViewModel 實例，預設當前日期
            return View(new HomeViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(HomeViewModel model)
        {
            if (ModelState.IsValid)
            {
                // 將 ViewModel 資料轉換為資料庫實體
                var homework = new Homework1
                {
                    Category = model.Category,
                    Money = model.Money,
                    CreateDate = model.CreateDate,
                    Description = model.Description ?? string.Empty
                };

                _skillTreeContext.Homework1s.Add(homework);
                await _skillTreeContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            // 如果驗證失敗，返回視圖並保留輸入的數據
            return View(model);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
