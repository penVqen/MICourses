﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MICourses.Models;

public partial class MIContext : DbContext
{
    public MIContext()
    {
    }

    public MIContext(DbContextOptions<MIContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Achievment> Achievments { get; set; }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Certificate> Certificates { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Users_Achievment> Users_Achievments { get; set; }

    public virtual DbSet<Users_Comment> Users_Comments { get; set; }

    public virtual DbSet<Users_Course> Users_Courses { get; set; }

    public virtual DbSet<Users_Lesson> Users_Lessons { get; set; }

    public virtual DbSet<Users_Test> Users_Tests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-JVTTJKA\\SQLEXPRESS;Initial Catalog=MIDatabase;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasOne(d => d.ID_QuestionNavigation).WithMany(p => p.Answers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Answers_Questions");
        });

        modelBuilder.Entity<Certificate>(entity =>
        {
            entity.HasOne(d => d.ID_CourseNavigation).WithMany(p => p.Certificates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Certificates_Courses");

            entity.HasOne(d => d.ID_UserNavigation).WithMany(p => p.Certificates)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Certificates_Users");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasOne(d => d.ID_LessonNavigation).WithMany(p => p.Comments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Lessons");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.HasOne(d => d.ID_CourseNavigation).WithMany(p => p.Lessons)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lessons_Courses");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasOne(d => d.ID_TestNavigation).WithMany(p => p.Questions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Questions_Tests");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasOne(d => d.ID_LessonNavigation).WithMany(p => p.Tests)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tests_Lessons");
        });

        modelBuilder.Entity<Users_Achievment>(entity =>
        {
            entity.HasOne(d => d.ID_AchievmentNavigation).WithMany(p => p.Users_Achievments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Achievments_Achievments");

            entity.HasOne(d => d.ID_UserNavigation).WithMany(p => p.Users_Achievments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Achievments_Users");
        });

        modelBuilder.Entity<Users_Comment>(entity =>
        {
            entity.HasOne(d => d.ID_CommentNavigation).WithMany(p => p.Users_Comments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Comments_Comments");

            entity.HasOne(d => d.ID_UserNavigation).WithMany(p => p.Users_Comments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Comments_Users");
        });

        modelBuilder.Entity<Users_Course>(entity =>
        {
            entity.HasOne(d => d.ID_CourseNavigation).WithMany(p => p.Users_Courses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Courses_Courses");

            entity.HasOne(d => d.ID_UserNavigation).WithMany(p => p.Users_Courses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Courses_Users");
        });

        modelBuilder.Entity<Users_Lesson>(entity =>
        {
            entity.HasOne(d => d.ID_LessonNavigation).WithMany(p => p.Users_Lessons)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Lessons_Lessons");

            entity.HasOne(d => d.ID_UserNavigation).WithMany(p => p.Users_Lessons)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Lessons_Users");
        });

        modelBuilder.Entity<Users_Test>(entity =>
        {
            entity.HasOne(d => d.ID_TestNavigation).WithMany(p => p.Users_Tests)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Tests_Tests");

            entity.HasOne(d => d.ID_UserNavigation).WithMany(p => p.Users_Tests)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Tests_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}