﻿using System;
using System.Collections.Generic;

namespace MenampilkanDataDariDatabase.Models;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Abbreviation { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
