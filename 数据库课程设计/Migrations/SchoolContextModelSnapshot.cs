using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SchoolManagement.Models;

namespace 数据库课程设计.Migrations
{
    [DbContext(typeof(SchoolContext))]
    partial class SchoolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SchoolManagement.Models.Choice", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Score");

                    b.Property<int?>("StuID");

                    b.Property<int?>("TakeId");

                    b.HasKey("ID");

                    b.HasIndex("StuID");

                    b.HasIndex("TakeId");

                    b.ToTable("Choice");
                });

            modelBuilder.Entity("SchoolManagement.Models.Collage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Collage");
                });

            modelBuilder.Entity("SchoolManagement.Models.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BelongsId");

                    b.Property<int>("Credit");

                    b.Property<int>("Hour");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("BelongsId");

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("SchoolManagement.Models.Specialty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BelongsId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("BelongsId");

                    b.ToTable("Specialty");
                });

            modelBuilder.Entity("SchoolManagement.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Sex");

                    b.Property<int?>("belongsId");

                    b.HasKey("ID");

                    b.HasIndex("belongsId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("SchoolManagement.Models.Teach", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CrsId");

                    b.Property<int?>("TchId");

                    b.HasKey("ID");

                    b.HasIndex("CrsId");

                    b.HasIndex("TchId");

                    b.ToTable("Teach");
                });

            modelBuilder.Entity("SchoolManagement.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BelongsId");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<int>("Salary");

                    b.Property<string>("Sex");

                    b.HasKey("Id");

                    b.HasIndex("BelongsId");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("SchoolManagement.Models.Choice", b =>
                {
                    b.HasOne("SchoolManagement.Models.Student", "Stu")
                        .WithMany("Choices")
                        .HasForeignKey("StuID");

                    b.HasOne("SchoolManagement.Models.Lesson", "Take")
                        .WithMany("Choices")
                        .HasForeignKey("TakeId");
                });

            modelBuilder.Entity("SchoolManagement.Models.Lesson", b =>
                {
                    b.HasOne("SchoolManagement.Models.Specialty", "Belongs")
                        .WithMany()
                        .HasForeignKey("BelongsId");
                });

            modelBuilder.Entity("SchoolManagement.Models.Specialty", b =>
                {
                    b.HasOne("SchoolManagement.Models.Collage", "Belongs")
                        .WithMany("Specialtys")
                        .HasForeignKey("BelongsId");
                });

            modelBuilder.Entity("SchoolManagement.Models.Student", b =>
                {
                    b.HasOne("SchoolManagement.Models.Specialty", "belongs")
                        .WithMany("Students")
                        .HasForeignKey("belongsId");
                });

            modelBuilder.Entity("SchoolManagement.Models.Teach", b =>
                {
                    b.HasOne("SchoolManagement.Models.Lesson", "Crs")
                        .WithMany("Teachers")
                        .HasForeignKey("CrsId");

                    b.HasOne("SchoolManagement.Models.Teacher", "Tch")
                        .WithMany("Lessons")
                        .HasForeignKey("TchId");
                });

            modelBuilder.Entity("SchoolManagement.Models.Teacher", b =>
                {
                    b.HasOne("SchoolManagement.Models.Specialty", "Belongs")
                        .WithMany()
                        .HasForeignKey("BelongsId");
                });
        }
    }
}
