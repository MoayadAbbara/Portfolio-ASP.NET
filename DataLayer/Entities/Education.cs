using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class Education
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? StartYear { get; set; }

    public int? EndYear { get; set; }

    public string? Institution { get; set; }

    public string? Description { get; set; }
}
