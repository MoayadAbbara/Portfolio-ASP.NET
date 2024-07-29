using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class Services
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Icon { get; set; }
}
