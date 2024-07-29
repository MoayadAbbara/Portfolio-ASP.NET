using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class Experience
{
    public int Id { get; set; }

    public string? JobTitle { get; set; }

    public string? CompanyName { get; set; }

    public int? StartYear { get; set; }

    public int? EndYear { get; set; }

    public string? Location { get; set; }

    public virtual ICollection<ExperienceDetails> ExperienceDetails { get; set; } = new List<ExperienceDetails>();
}
