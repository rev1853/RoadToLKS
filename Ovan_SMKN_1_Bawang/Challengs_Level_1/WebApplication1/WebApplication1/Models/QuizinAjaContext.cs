using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public partial class QuizinAjaContext : DbContext
{
    public QuizinAjaContext()
    {
    }
    public List<Participant> GetParticipants()
    {
        return Participants.ToList();
    }
    public QuizinAjaContext(DbContextOptions<QuizinAjaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Participant> Participants { get; set; }

    public virtual DbSet<ParticipantAnswer> ParticipantAnswers { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Quiz> Quizzes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=GIO;Initial Catalog=QuizinAja;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Participant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Particip__3214EC2785078BD3");

            entity.ToTable("Participant");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ParticipantNickname)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ParticipationDate).HasColumnType("datetime");
            entity.Property(e => e.QuizId).HasColumnName("QuizID");

            entity.HasOne(d => d.Quiz).WithMany(p => p.Participants)
                .HasForeignKey(d => d.QuizId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_QuizParticipant_Quiz_QuizID");
        });

        modelBuilder.Entity<ParticipantAnswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Particip__3214EC2714689788");

            entity.ToTable("ParticipantAnswer");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Answer)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ParticipantId).HasColumnName("ParticipantID");
            entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

            entity.HasOne(d => d.Participant).WithMany(p => p.ParticipantAnswers)
                .HasForeignKey(d => d.ParticipantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_QuizParticipantAnswer_Participant_ParticipantID");

            entity.HasOne(d => d.Question).WithMany(p => p.ParticipantAnswers)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_QuizParticipantAnswer_Question_QuestionID");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Question__3214EC276D9C2CEC");

            entity.ToTable("Question");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CorrectAnswer)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OptionA)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OptionB)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OptionC)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.OptionD)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Question1)
                .HasColumnType("text")
                .HasColumnName("Question");
            entity.Property(e => e.QuizId).HasColumnName("QuizID");

            entity.HasOne(d => d.Quiz).WithMany(p => p.Questions)
                .HasForeignKey(d => d.QuizId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Quiz__3214EC27878E5BA1");

            entity.ToTable("Quiz");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Quizzes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC27E74CCF5E");

            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FullName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
