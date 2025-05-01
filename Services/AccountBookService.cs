namespace Homework_SkillTree.Services;
using Homework_SkillTree.Data;
using Homework_SkillTree.Models;
using Homework_SkillTree.Models.DB;
using Microsoft.EntityFrameworkCore;

public class AccountBookService : IAccountBookService
{
    private readonly MyBlogContext _context;

    public AccountBookService(MyBlogContext context)
    {
        _context = context;
    }

    public async Task<List<HomeViewModel>> GetAllAsync()
    {
        return await _context.AccountBooks
            .Select(e => new HomeViewModel
            {
                Category = e.Categoryyy.ToString(),
                Money = e.Amounttt,
                CreateDate = e.Dateee,
                Description = string.IsNullOrWhiteSpace(e.Remarkkk) ? null : e.Remarkkk
            })
            .ToListAsync();
    }

    public async Task AddAsync(HomeViewModel model)
    {
        var entity = new AccountBook
        {
            Id = Guid.NewGuid(),
            Categoryyy = model.Category == "1" ? 1 : 0,
            Amounttt = (int)Math.Round(model.Money, 0, MidpointRounding.ToZero),
            Dateee = model.CreateDate,
            Remarkkk = model.Description ?? string.Empty
        };

        await _context.AccountBooks.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

}