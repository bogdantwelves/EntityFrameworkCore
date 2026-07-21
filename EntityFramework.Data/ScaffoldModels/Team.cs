using System;
using System.Collections.Generic;

namespace EntityFramework.Data.ScaffoldModels;

public partial class Team
{
    public int TeamId { get; set; }

    public string? Name { get; set; }

    public string CreatedAt { get; set; } = null!;

    public string UpdatedAt { get; set; } = null!;
}
