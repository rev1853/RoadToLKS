using System;
using System.Collections.Generic;

namespace JWTAuthentication.Database;

public partial class JobLevel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
