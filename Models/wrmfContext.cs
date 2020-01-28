using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RainFall.WebApi.Models
{
    public partial class WrmfContext : DbContext
    {
       

        public WrmfContext(DbContextOptions<WrmfContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Channel> Channel { get; set; }
        public virtual DbSet<DiagramChannel> DiagramChannel { get; set; }
        public virtual DbSet<DiagramNode> DiagramNode { get; set; }
        public virtual DbSet<Model> Model { get; set; }
        public virtual DbSet<NetworkDiagram> NetworkDiagram { get; set; }
        public virtual DbSet<Node> Node { get; set; }
        public virtual DbSet<Scenario> Scenario { get; set; }
        public virtual DbSet<StudyArea> StudyArea { get; set; }
        public virtual DbSet<SubArea> SubArea { get; set; }
        public virtual DbSet<User> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Channel>(entity =>
            {
                entity.Property(e => e.ChannelId)
                    .HasColumnName("ChannelID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ChannelName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ScenarioId).HasColumnName("ScenarioID");
            });

            modelBuilder.Entity<DiagramChannel>(entity =>
            {
                entity.HasKey(e => e.DiagramMemberId)
                    .HasName("PK__DiagramC__E2883138C42A44AB");

                entity.Property(e => e.DiagramMemberId)
                    .HasColumnName("DiagramMemberID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ChannelId).HasColumnName("ChannelID");

                entity.Property(e => e.DiagramId).HasColumnName("DiagramID");
            });

            modelBuilder.Entity<DiagramNode>(entity =>
            {
                entity.HasKey(e => e.DiagramMemberId)
                    .HasName("PK__DiagramN__E288313819AD3C3B");

                entity.Property(e => e.DiagramMemberId)
                    .HasColumnName("DiagramMemberID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DiagramId).HasColumnName("DiagramID");

                entity.Property(e => e.NodeId).HasColumnName("NodeID");
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.Property(e => e.ModelId)
                    .HasColumnName("ModelID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Model1)
                    .HasColumnName("Model")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NetworkDiagram>(entity =>
            {
                entity.HasKey(e => e.DiagramId)
                    .HasName("PK__NetworkD__CC908F5FFB8D15FE");

                entity.Property(e => e.DiagramId)
                    .HasColumnName("DiagramID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DiagramName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ScenarioId).HasColumnName("ScenarioID");
            });

            modelBuilder.Entity<Node>(entity =>
            {
                entity.Property(e => e.NodeId)
                    .HasColumnName("NodeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.NodeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ScenarioId).HasColumnName("ScenarioID");
            });

            modelBuilder.Entity<Scenario>(entity =>
            {
                entity.Property(e => e.ScenarioId)
                    .HasColumnName("ScenarioID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Scenario1)
                    .HasColumnName("Scenario")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ScenarioLabel)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SubAreaId).HasColumnName("SubAreaID");
            });

            modelBuilder.Entity<StudyArea>(entity =>
            {
                entity.Property(e => e.StudyAreaId)
                    .HasColumnName("StudyAreaID")
                    .ValueGeneratedNever();

                entity.Property(e => e.StudyArea1)
                    .HasColumnName("StudyArea")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudyAreaLabel)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SubArea>(entity =>
            {
                entity.Property(e => e.SubAreaId)
                    .HasColumnName("SubAreaID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ModelId).HasColumnName("ModelID");

                entity.Property(e => e.StudyAreaId).HasColumnName("StudyAreaID");

                entity.Property(e => e.SubArea1)
                    .HasColumnName("SubArea")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubAreaLabel)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CellPhoneNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
