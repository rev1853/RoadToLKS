using System;
using System.Collections.Generic;

namespace MenampilkanDataDariDatabase.Models;

public partial class Promotion
{
    public int Id { get; set; }

    public int JobId { get; set; }

    public int EmployeeId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Job Job { get; set; } = null!;
}
