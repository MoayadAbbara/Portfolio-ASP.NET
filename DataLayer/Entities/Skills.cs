using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class Skills
{
    public int Id { get; set; }

    public string Skill { get; set; } = null!;

    public int? Ratio { get; set; }
}
