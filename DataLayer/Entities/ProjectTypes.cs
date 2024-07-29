using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class ProjectTypes
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Projects> Projects { get; set; } = new List<Projects>();
}
