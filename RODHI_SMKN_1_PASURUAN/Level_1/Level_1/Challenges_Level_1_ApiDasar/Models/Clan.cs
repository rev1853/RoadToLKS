﻿using System;
using System.Collections.Generic;

namespace Challenges_Level_1_ApiDasar.Models;

public partial class Clan
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Hero> Heroes { get; set; } = new List<Hero>();
}