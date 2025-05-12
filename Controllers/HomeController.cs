using Homework_SkillTree.Models;
using Homework_SkillTree.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            var pagedList = await _accountBookService.GetAllAsync(page, pageSize);

            return View(pagedList);
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
                await _accountBookService.SaveChangesAsync();

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
