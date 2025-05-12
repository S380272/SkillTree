namespace Homework_SkillTree.Services;
using Homework_SkillTree.Data;
using Homework_SkillTree.Models;
using Homework_SkillTree.Models.DB;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using X.PagedList.EF;
using X.PagedList.Extensions;

public class AccountBookService : IAccountBookService
{
    private readonly MyBlogContext _context;

    public AccountBookService(MyBlogContext context)
    {
        _context = context;
    }

    public async Task<IPagedList<HomeViewModel>> GetAllAsync(int pageNumber, int pageSize)
    {
        return await _context.AccountBooks
            .AsNoTracking()
            .OrderByDescending(e => e.Dateee)
            .Select(e => new HomeViewModel
            {
                Category = e.Categoryyy.ToString(),
                Money = e.Amounttt,
                CreateDate = e.Dateee,
                Description = string.IsNullOrWhiteSpace(e.Remarkkk) ? null : e.Remarkkk
            })
            .ToPagedListAsync(pageNumber, pageSize);
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
        
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}