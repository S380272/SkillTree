using System.Diagnostics;
using Homework_SkillTree.Models;
using Homework_SkillTree.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Homework_SkillTree.Services;

namespace Homework_SkillTree.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountBookService _accountBookService;

        public HomeController(IAccountBookService accountBookService,
                              ILogger<HomeController> logger)
        {
            _accountBookService = accountBookService;
            _logger = logger;
        }

        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            // 先取得所有記帳資料
            var allItems = await _accountBookService.GetAllAsync();
            var totalCount = allItems.Count;
            const int pageSize = 10;
            var pagedItems = allItems
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            var result = new PagedResult<HomeViewModel>
            {
                Items = pagedItems,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount
            };
            return View(result);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View(new HomeViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(HomeViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _accountBookService.AddAsync(model);

                return RedirectToAction(nameof(Index));
            }

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
