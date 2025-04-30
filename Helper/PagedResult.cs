namespace Homework_SkillTree.Services;

using System.Collections.Generic;

public class PagedResult<T>
{
    public List<T> Items { get; set; } = new List<T>();
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages => (int)System.Math.Ceiling((double)TotalCount / PageSize);
}