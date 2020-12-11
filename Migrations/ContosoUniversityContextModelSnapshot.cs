﻿// <auto-generated />
using System;
using HomeWork.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HomeWork.Migrations
{
    [DbContext(typeof(ContosoUniversityContext))]
    partial class ContosoUniversityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("HomeWork.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CourseID")
                        .UseIdentityColumn();

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DepartmentID")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CourseId");

                    b.HasIndex(new[] { "DepartmentId" }, "IX_DepartmentID");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("HomeWork.Models.CourseInstructor", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("CourseID");

                    b.Property<int>("InstructorId")
                        .HasColumnType("int")
                        .HasColumnName("InstructorID");

                    b.HasKey("CourseId", "InstructorId")
                        .HasName("PK_dbo.CourseInstructor");

                    b.HasIndex(new[] { "CourseId" }, "IX_CourseID");

                    b.HasIndex(new[] { "InstructorId" }, "IX_InstructorID");

                    b.ToTable("CourseInstructor");
                });

            modelBuilder.Entity("HomeWork.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DepartmentID")
                        .UseIdentityColumn();

                    b.Property<decimal>("Budget")
                        .HasColumnType("money");

                    b.Property<int?>("InstructorId")
                        .HasColumnType("int")
                        .HasColumnName("InstructorID");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.HasKey("DepartmentId");

                    b.HasIndex(new[] { "InstructorId" }, "IX_InstructorID")
                        .HasDatabaseName("IX_InstructorID1");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("HomeWork.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EnrollmentID")
                        .UseIdentityColumn();

                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("CourseID");

                    b.Property<int?>("Grade")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("StudentID");

                    b.HasKey("EnrollmentId");

                    b.HasIndex(new[] { "CourseId" }, "IX_CourseID")
                        .HasDatabaseName("IX_CourseID1");

                    b.HasIndex(new[] { "StudentId" }, "IX_StudentID");

                    b.ToTable("Enrollment");
                });

            modelBuilder.Entity("HomeWork.Models.OfficeAssignment", b =>
                {
                    b.Property<int>("InstructorId")
                        .HasColumnType("int")
                        .HasColumnName("InstructorID");

                    b.Property<string>("Location")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("InstructorId")
                        .HasName("PK_dbo.OfficeAssignment");

                    b.HasIndex(new[] { "InstructorId" }, "IX_InstructorID")
                        .HasDatabaseName("IX_InstructorID2");

                    b.ToTable("OfficeAssignment");
                });

            modelBuilder.Entity("HomeWork.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasDefaultValueSql("('Instructor')");

                    b.Property<DateTime?>("EnrollmentDate")
                        .HasColumnType("datetime");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("HireDate")
                        .HasColumnType("datetime");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("HomeWork.Models.VwCourseStudent", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("CourseID");

                    b.Property<string>("CourseTitle")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int")
                        .HasColumnName("DepartmentID");

                    b.Property<string>("DepartmentName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("StudentID");

                    b.Property<string>("StudentName")
                        .HasMaxLength(101)
                        .HasColumnType("nvarchar(101)");

                    b.ToView("vwCourseStudents");
                });

            modelBuilder.Entity("HomeWork.Models.VwCourseStudentCount", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int")
                        .HasColumnName("CourseID");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int")
                        .HasColumnName("DepartmentID");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("StudentCount")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.ToView("vwCourseStudentCount");
                });

            modelBuilder.Entity("HomeWork.Models.VwDepartmentCourseCount", b =>
                {
                    b.Property<int?>("CourseCount")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int")
                        .HasColumnName("DepartmentID");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.ToView("vwDepartmentCourseCount");
                });

            modelBuilder.Entity("HomeWork.Models.Course", b =>
                {
                    b.HasOne("HomeWork.Models.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("FK_dbo.Course_dbo.Department_DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("HomeWork.Models.CourseInstructor", b =>
                {
                    b.HasOne("HomeWork.Models.Course", "Course")
                        .WithMany("CourseInstructors")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("FK_dbo.CourseInstructor_dbo.Course_CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeWork.Models.Person", "Instructor")
                        .WithMany("CourseInstructors")
                        .HasForeignKey("InstructorId")
                        .HasConstraintName("FK_dbo.CourseInstructor_dbo.Instructor_InstructorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("HomeWork.Models.Department", b =>
                {
                    b.HasOne("HomeWork.Models.Person", "Instructor")
                        .WithMany("Departments")
                        .HasForeignKey("InstructorId")
                        .HasConstraintName("FK_dbo.Department_dbo.Instructor_InstructorID");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("HomeWork.Models.Enrollment", b =>
                {
                    b.HasOne("HomeWork.Models.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("FK_dbo.Enrollment_dbo.Course_CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeWork.Models.Person", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentId")
                        .HasConstraintName("FK_dbo.Enrollment_dbo.Person_StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("HomeWork.Models.OfficeAssignment", b =>
                {
                    b.HasOne("HomeWork.Models.Person", "Instructor")
                        .WithOne("OfficeAssignment")
                        .HasForeignKey("HomeWork.Models.OfficeAssignment", "InstructorId")
                        .HasConstraintName("FK_dbo.OfficeAssignment_dbo.Instructor_InstructorID")
                        .IsRequired();

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("HomeWork.Models.Course", b =>
                {
                    b.Navigation("CourseInstructors");

                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("HomeWork.Models.Department", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("HomeWork.Models.Person", b =>
                {
                    b.Navigation("CourseInstructors");

                    b.Navigation("Departments");

                    b.Navigation("Enrollments");

                    b.Navigation("OfficeAssignment");
                });
#pragma warning restore 612, 618
        }
    }
}
