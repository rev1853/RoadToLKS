﻿using System;
using System.Collections.Generic;

namespace _01_API.Models;

public partial class HeroSkill
{
    public int Id { get; set; }

    public int HeroId { get; set; }

    public int SkillId { get; set; }

    public double Power { get; set; }

    public virtual Hero Hero { get; set; } = null!;

    public virtual Skill Skill { get; set; } = null!;
}