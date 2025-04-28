using System;
using System.Collections.Generic;

namespace Homework_SkillTree.Models.DB;

public partial class Homework1
{
    public int Id { get; set; }

    public string Category { get; set; } = null!;

    public decimal Money { get; set; }

    public DateTime CreateDate { get; set; }

    public string Description { get; set; } = null!;
}
