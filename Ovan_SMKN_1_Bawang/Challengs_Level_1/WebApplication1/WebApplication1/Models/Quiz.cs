using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Quiz
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual User User { get; set; } = null!;
}
