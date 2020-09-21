﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolManagement.Models;

namespace SchoolManagement.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    partial class SchoolDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SchoolManagement.Models.Classes", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClassName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("MajorId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("ClassId")
                        .HasName("PK__Classes__CB1927C03F14F819");

                    b.HasIndex("CourseId");

                    b.HasIndex("MajorId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("SchoolManagement.Models.Courses", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("FinishDay")
                        .HasColumnType("date");

                    b.Property<DateTime?>("StartDay")
                        .HasColumnType("date");

                    b.HasKey("CourseId")
                        .HasName("PK__Courses__C92D71A798C7CD5F");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("SchoolManagement.Models.InfomationSubjects", b =>
                {
                    b.Property<int>("ProgramId")
                        .HasColumnType("int");

                    b.Property<int>("MajorId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("StudyYear")
                        .HasColumnType("int");

                    b.Property<int?>("PraticeHour")
                        .HasColumnType("int");

                    b.Property<int?>("Semester")
                        .HasColumnType("int");

                    b.Property<int?>("TheoreticalHour")
                        .HasColumnType("int");

                    b.HasKey("ProgramId", "MajorId", "SubjectId", "StudyYear")
                        .HasName("PK__Infomati__D9F90FD2679F151F");

                    b.HasIndex("MajorId");

                    b.HasIndex("SubjectId");

                    b.ToTable("InfomationSubjects");
                });

            modelBuilder.Entity("SchoolManagement.Models.Majors", b =>
                {
                    b.Property<int>("MajorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("FoundedYear")
                        .HasColumnType("int");

                    b.Property<string>("MajorName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("MajorId")
                        .HasName("PK__Majors__D5B8BF91E864AD82");

                    b.ToTable("Majors");
                });

            modelBuilder.Entity("SchoolManagement.Models.Programs", b =>
                {
                    b.Property<int>("ProgramId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProgramName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("ProgramId")
                        .HasName("PK__Programs__7525605804CB3EE2");

                    b.ToTable("Programs");
                });

            modelBuilder.Entity("SchoolManagement.Models.Results", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("ExamTime")
                        .HasColumnType("int");

                    b.Property<double?>("TestScore")
                        .HasColumnType("float");

                    b.HasKey("StudentId", "SubjectId", "ExamTime")
                        .HasName("PK__Results__0800C6081B50451D");

                    b.HasIndex("SubjectId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("SchoolManagement.Models.Students", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("BirthDay")
                        .HasColumnType("date");

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("StudentName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("StudentId")
                        .HasName("PK__Students__32C52B999360B586");

                    b.HasIndex("ClassId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SchoolManagement.Models.Subjects", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MajorId")
                        .HasColumnType("int");

                    b.Property<string>("SubjectName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("SubjectId")
                        .HasName("PK__Subjects__AC1BA3A8DAB31507");

                    b.HasIndex("MajorId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("SchoolManagement.Models.Classes", b =>
                {
                    b.HasOne("SchoolManagement.Models.Courses", "Course")
                        .WithMany("Classes")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("FK__Classes__CourseI__2B3F6F97")
                        .IsRequired();

                    b.HasOne("SchoolManagement.Models.Majors", "Major")
                        .WithMany("Classes")
                        .HasForeignKey("MajorId")
                        .HasConstraintName("FK__Classes__MajorId__2A4B4B5E")
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolManagement.Models.InfomationSubjects", b =>
                {
                    b.HasOne("SchoolManagement.Models.Majors", "Major")
                        .WithMany("InfomationSubjects")
                        .HasForeignKey("MajorId")
                        .HasConstraintName("FK__Infomatio__Major__38996AB5")
                        .IsRequired();

                    b.HasOne("SchoolManagement.Models.Programs", "Program")
                        .WithMany("InfomationSubjects")
                        .HasForeignKey("ProgramId")
                        .HasConstraintName("FK__Infomatio__Progr__37A5467C")
                        .IsRequired();

                    b.HasOne("SchoolManagement.Models.Subjects", "Subject")
                        .WithMany("InfomationSubjects")
                        .HasForeignKey("SubjectId")
                        .HasConstraintName("FK__Infomatio__Subje__398D8EEE")
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolManagement.Models.Results", b =>
                {
                    b.HasOne("SchoolManagement.Models.Students", "Student")
                        .WithMany("Results")
                        .HasForeignKey("StudentId")
                        .HasConstraintName("FK__Results__Student__33D4B598")
                        .IsRequired();

                    b.HasOne("SchoolManagement.Models.Subjects", "Subject")
                        .WithMany("Results")
                        .HasForeignKey("SubjectId")
                        .HasConstraintName("FK__Results__Subject__34C8D9D1")
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolManagement.Models.Students", b =>
                {
                    b.HasOne("SchoolManagement.Models.Classes", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId")
                        .HasConstraintName("FK__Students__ClassI__2E1BDC42")
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolManagement.Models.Subjects", b =>
                {
                    b.HasOne("SchoolManagement.Models.Majors", "Major")
                        .WithMany("Subjects")
                        .HasForeignKey("MajorId")
                        .HasConstraintName("FK__Subjects__Subjec__30F848ED")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
