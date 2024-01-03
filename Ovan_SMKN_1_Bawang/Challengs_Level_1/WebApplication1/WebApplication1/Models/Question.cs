using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Question
{
    public int Id { get; set; }

    public int QuizId { get; set; }

    public string Question1 { get; set; } = null!;

    public string OptionA { get; set; } = null!;

    public string OptionB { get; set; } = null!;

    public string OptionC { get; set; } = null!;

    public string OptionD { get; set; } = null!;

    public string CorrectAnswer { get; set; } = null!;

    public virtual ICollection<ParticipantAnswer> ParticipantAnswers { get; set; } = new List<ParticipantAnswer>();

    public virtual Quiz Quiz { get; set; } = null!;
}
