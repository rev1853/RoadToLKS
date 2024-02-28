using System;
using System.Collections.Generic;

namespace _01_API.Models;

public partial class Element
{
    public int Id { get; set; }

    public string Element1 { get; set; } = null!;

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}
