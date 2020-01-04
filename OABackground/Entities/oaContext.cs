using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OABackground.Entities
{
    public partial class oaContext : DbContext
    {
        public oaContext()
        {
        }

        public oaContext(DbContextOptions<oaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Awardpunish> Awardpunish { get; set; }
        public virtual DbSet<Conventionapply> Conventionapply { get; set; }
        public virtual DbSet<Materialapply> Materialapply { get; set; }
        public virtual DbSet<Plantable> Plantable { get; set; }
        public virtual DbSet<Section> Section { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Teacherinfomation> Teacherinfomation { get; set; }
        public virtual DbSet<Teacherpassword> Teacherpassword { get; set; }
        public virtual DbSet<Teachplan> Teachplan { get; set; }
        public virtual DbSet<Wage> Wage { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=rm-uf6052662m189321aio.mysql.rds.aliyuncs.com;UserId=root;Password=Q123968574q;Database=oa");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Awardpunish>(entity =>
            {
                entity.ToTable("awardpunish");

                entity.HasIndex(e => e.Sid)
                    .HasName("Sid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(12)");

                entity.Property(e => e.ApplyTime)
                    .HasColumnName("applyTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.AwardContent)
                    .IsRequired()
                    .HasColumnName("awardContent")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CheckTime)
                    .HasColumnName("checkTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Issue)
                    .IsRequired()
                    .HasColumnName("issue")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.PunishContent)
                    .HasColumnName("punishContent")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Sid)
                    .IsRequired()
                    .HasColumnType("char(12)");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.S)
                    .WithMany(p => p.Awardpunish)
                    .HasForeignKey(d => d.Sid)
                    .HasConstraintName("Sid");
            });

            modelBuilder.Entity<Conventionapply>(entity =>
            {
                entity.ToTable("conventionapply");

                entity.HasIndex(e => e.Contact)
                    .HasName("cid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasColumnName("contact")
                    .HasColumnType("char(12)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ConventionPlace)
                    .IsRequired()
                    .HasColumnName("conventionPlace")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.ConventionState)
                    .HasColumnName("conventionState")
                    .HasColumnType("int(1)");

                entity.Property(e => e.EndTime)
                    .HasColumnName("endTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.StartTime)
                    .HasColumnName("startTime")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.ContactNavigation)
                    .WithMany(p => p.Conventionapply)
                    .HasForeignKey(d => d.Contact)
                    .HasConstraintName("cid");
            });

            modelBuilder.Entity<Materialapply>(entity =>
            {
                entity.ToTable("materialapply");

                entity.HasIndex(e => e.Departmentid)
                    .HasName("departmentID");

                entity.HasIndex(e => e.Tid)
                    .HasName("tID");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Departmentid)
                    .IsRequired()
                    .HasColumnName("departmentid")
                    .HasColumnType("char(10)");

                entity.Property(e => e.Goodsname)
                    .IsRequired()
                    .HasColumnName("goodsname")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Goodsnum)
                    .HasColumnName("goodsnum")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Goodsprice)
                    .HasColumnName("goodsprice")
                    .HasColumnType("float(9,2)");

                entity.Property(e => e.Remarks)
                    .IsRequired()
                    .HasColumnName("remarks")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Tid)
                    .IsRequired()
                    .HasColumnName("tid")
                    .HasColumnType("char(12)");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Materialapply)
                    .HasForeignKey(d => d.Departmentid)
                    .HasConstraintName("departmentID");

                entity.HasOne(d => d.T)
                    .WithMany(p => p.Materialapply)
                    .HasForeignKey(d => d.Tid)
                    .HasConstraintName("tID");
            });

            modelBuilder.Entity<Plantable>(entity =>
            {
                entity.ToTable("plantable");

                entity.HasIndex(e => e.Teacherid)
                    .HasName("pttid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Committime)
                    .HasColumnName("committime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasColumnName("filename")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Filepath)
                    .IsRequired()
                    .HasColumnName("filepath")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Issue)
                    .HasColumnName("issue")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Teacherid)
                    .IsRequired()
                    .HasColumnName("teacherid")
                    .HasColumnType("char(12)");
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.ToTable("section");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("char(10)");

                entity.Property(e => e.Chairman)
                    .IsRequired()
                    .HasColumnName("chairman")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasColumnType("varchar(11)");

                entity.Property(e => e.Workplace)
                    .IsRequired()
                    .HasColumnName("workplace")
                    .HasColumnType("varchar(30)");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("char(12)");

                entity.Property(e => e.Class)
                    .IsRequired()
                    .HasColumnName("class")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Dormitory)
                    .IsRequired()
                    .HasColumnName("dormitory")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Grade)
                    .IsRequired()
                    .HasColumnName("grade")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Parent)
                    .HasColumnName("parent")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.ParentPhone)
                    .IsRequired()
                    .HasColumnName("parentPhone")
                    .HasColumnType("varchar(11)");

                entity.Property(e => e.SelfPhone)
                    .IsRequired()
                    .HasColumnName("selfPhone")
                    .HasColumnType("varchar(11)");

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasColumnType("char(2)")
                    .HasDefaultValueSql("'男'");
            });

            modelBuilder.Entity<Teacherinfomation>(entity =>
            {
                entity.HasKey(e => e.Teacherid)
                    .HasName("PRIMARY");

                entity.ToTable("teacherinfomation");

                entity.HasIndex(e => e.Departmentid)
                    .HasName("dID");

                entity.Property(e => e.Teacherid)
                    .HasColumnName("teacherid")
                    .HasColumnType("char(12)");

                entity.Property(e => e.Departmentid)
                    .IsRequired()
                    .HasColumnName("departmentid")
                    .HasColumnType("char(10)");

                entity.Property(e => e.EntryTime)
                    .HasColumnName("entryTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Profession)
                    .IsRequired()
                    .HasColumnName("profession")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasColumnName("sex")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Tname)
                    .IsRequired()
                    .HasColumnName("tname")
                    .HasColumnType("varchar(20)");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Teacherinfomation)
                    .HasForeignKey(d => d.Departmentid)
                    .HasConstraintName("dID");
            });

            modelBuilder.Entity<Teacherpassword>(entity =>
            {
                entity.ToTable("teacherpassword");

                entity.HasIndex(e => e.Teacherid)
                    .HasName("teachersid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Pwdsalt)
                    .IsRequired()
                    .HasColumnName("pwdsalt")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Teacherid)
                    .IsRequired()
                    .HasColumnName("teacherid")
                    .HasColumnType("char(12)");

                entity.Property(e => e.Teacherpassword1)
                    .IsRequired()
                    .HasColumnName("teacherpassword")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Teacherpassword)
                    .HasForeignKey(d => d.Teacherid)
                    .HasConstraintName("teachersid");
            });

            modelBuilder.Entity<Teachplan>(entity =>
            {
                entity.ToTable("teachplan");

                entity.HasIndex(e => e.Tid)
                    .HasName("PlanTID");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("char(12)");

                entity.Property(e => e.Examination)
                    .IsRequired()
                    .HasColumnName("examination")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.TeachSubject)
                    .IsRequired()
                    .HasColumnName("teachSubject")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.TeachTime)
                    .IsRequired()
                    .HasColumnName("teachTime")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Tid)
                    .IsRequired()
                    .HasColumnType("char(12)");

                entity.HasOne(d => d.T)
                    .WithMany(p => p.Teachplan)
                    .HasForeignKey(d => d.Tid)
                    .HasConstraintName("PlanTID");
            });

            modelBuilder.Entity<Wage>(entity =>
            {
                entity.ToTable("wage");

                entity.HasIndex(e => e.Teacherid)
                    .HasName("teacherID");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Basicwage)
                    .HasColumnName("basicwage")
                    .HasColumnType("float(9,2)");

                entity.Property(e => e.Bonus)
                    .HasColumnName("bonus")
                    .HasColumnType("float(9,2)");

                entity.Property(e => e.Overtimewage)
                    .HasColumnName("overtimewage")
                    .HasColumnType("float(9,2)");

                entity.Property(e => e.Teacherid)
                    .IsRequired()
                    .HasColumnName("teacherid")
                    .HasColumnType("char(12)");

                entity.Property(e => e.Totalwage)
                    .HasColumnName("totalwage")
                    .HasColumnType("float(9,2)");

                entity.Property(e => e.Wagetime)
                    .HasColumnName("wagetime")
                    .HasColumnType("date");

                entity.Property(e => e.Welfare)
                    .HasColumnName("welfare")
                    .HasColumnType("float(9,2)");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Wage)
                    .HasForeignKey(d => d.Teacherid)
                    .HasConstraintName("teacherID");
            });
        }
    }
}
