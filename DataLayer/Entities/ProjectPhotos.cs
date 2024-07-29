using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class ProjectPhotos
{
    public int Id { get; set; }

    public int? ProjectId { get; set; }

    public string? PhotoUrl { get; set; }

    public virtual Projects? Project { get; set; }
}
