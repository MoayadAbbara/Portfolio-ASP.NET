using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class ExperienceDetails
{
    public int Id { get; set; }

    public int? ExperienceId { get; set; }

    public string? Details { get; set; }

    public virtual Experience? Experience { get; set; }
}
