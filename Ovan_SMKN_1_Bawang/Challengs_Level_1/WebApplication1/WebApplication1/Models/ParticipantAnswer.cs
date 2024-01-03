using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class ParticipantAnswer
{
    public int Id { get; set; }

    public int ParticipantId { get; set; }

    public int QuestionId { get; set; }

    public string Answer { get; set; } = null!;

    public virtual Participant Participant { get; set; } = null!;

    public virtual Question Question { get; set; } = null!;
}
