namespace Homework_SkillTree.Services;

using Homework_SkillTree.Models;
using System.Threading.Tasks;
using X.PagedList;

public interface IAccountBookService
{
    Task<IPagedList<HomeViewModel>> GetAllAsync(int pageNumber, int pageSize);

    Task AddAsync(HomeViewModel model);

    Task SaveChangesAsync();
}