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

            // �N��Ʈw�����ഫ�����ϼҫ�
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
            // ��^�@�ӷs�� HomeViewModel ��ҡA�w�]��e���
            return View(new HomeViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(HomeViewModel model)
        {
            if (ModelState.IsValid)
            {
                // �N ViewModel ����ഫ����Ʈw����
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

            // �p�G���ҥ��ѡA��^���ϨëO�d��J���ƾ�
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
