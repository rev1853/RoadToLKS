﻿using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string Password { get; set; } = null!;

    public virtual ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
}
