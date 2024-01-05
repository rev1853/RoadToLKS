﻿using System;
using System.Collections.Generic;

namespace SmkMovies.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;
}
