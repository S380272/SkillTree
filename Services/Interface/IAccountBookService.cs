namespace Homework_SkillTree.Services;

using Homework_SkillTree.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

public interface IAccountBookService
{
    Task<List<Homework_SkillTree.Models.HomeViewModel>> GetAllAsync();

    Task AddAsync(HomeViewModel model);
}