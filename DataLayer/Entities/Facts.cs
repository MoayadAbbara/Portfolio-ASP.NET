using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class Facts
{
    public int Id { get; set; }

    public string? Fact { get; set; }

    public int? Numbers { get; set; }

    public string? IconClass { get; set; }
}
