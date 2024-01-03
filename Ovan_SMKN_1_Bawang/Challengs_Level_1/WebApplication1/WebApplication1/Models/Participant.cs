using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Participant
{
    public int Id { get; set; }

    public int QuizId { get; set; }

    public string ParticipantNickname { get; set; } = null!;

    public DateTime ParticipationDate { get; set; }

    public int TimeTaken { get; set; }

    public virtual ICollection<ParticipantAnswer> ParticipantAnswers { get; set; } = new List<ParticipantAnswer>();

    public virtual Quiz Quiz { get; set; } = null!;
}
