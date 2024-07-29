using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities;

public partial class Projects
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? TypeId { get; set; }

    public string? Link { get; set; }

    public DateTime? ProjectDate { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<ProjectPhotos> ProjectPhotos { get; set; } = new List<ProjectPhotos>();

    public virtual ProjectTypes? Type { get; set; }
}
