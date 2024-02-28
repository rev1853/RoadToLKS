using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeroAPI.Models;

public partial class Element
{
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Element1 { get; set; } = null!;

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}
