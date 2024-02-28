using System;
using System.Collections.Generic;

namespace JWTAuthentication.Database;

public partial class Job
{
    public int Id { get; set; }

    public int DepartmentId { get; set; }

    public int JobLevelId { get; set; }

    public int? SupervisorJobId { get; set; }

    public string Name { get; set; } = null!;

    public int HeadCount { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Job> InverseSupervisorJob { get; set; } = new List<Job>();

    public virtual JobLevel JobLevel { get; set; } = null!;

    public virtual ICollection<Mutation> Mutations { get; set; } = new List<Mutation>();

    public virtual ICollection<Position> Positions { get; set; } = new List<Position>();

    public virtual ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();

    public virtual Job? SupervisorJob { get; set; }
}
