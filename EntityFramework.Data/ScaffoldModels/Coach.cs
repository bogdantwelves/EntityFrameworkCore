using System;
using System.Collections.Generic;

namespace EntityFramework.Data.ScaffoldModels;

public partial class Coach
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string CreatedAt { get; set; } = null!;

    public string UpdatedAt { get; set; } = null!;
}
