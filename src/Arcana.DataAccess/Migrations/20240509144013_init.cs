using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Arcana.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Path = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ShortName = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Action = table.Column<string>(type: "text", nullable: true),
                    Controller = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    PermissionId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_UserRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "UserRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Profession = table.Column<string>(type: "text", nullable: true),
                    About = table.Column<string>(type: "text", nullable: true),
                    DetailId = table.Column<long>(type: "bigint", nullable: false),
                    PictureId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructors_Assets_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Assets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Instructors_Users_DetailId",
                        column: x => x.DetailId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DetailId = table.Column<long>(type: "bigint", nullable: false),
                    PictureId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Assets_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Assets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Students_Users_DetailId",
                        column: x => x.DetailId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric(18,3)", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    CountOfLessons = table.Column<int>(type: "integer", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    InstructorId = table.Column<long>(type: "bigint", nullable: false),
                    FileId = table.Column<long>(type: "bigint", nullable: false),
                    LanguageId = table.Column<long>(type: "bigint", nullable: false),
                    CourseCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Assets_FileId",
                        column: x => x.FileId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_CourseCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CourseCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_CourseCategories_CourseCategoryId",
                        column: x => x.CourseCategoryId,
                        principalTable: "CourseCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Courses_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorComments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: true),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    InstructorId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstructorComments_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstructorComments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InstructorStars",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Stars = table.Column<byte>(type: "smallint", nullable: false),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    InstructorId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorStars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstructorStars_Instructors_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstructorStars_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseComments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseComments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseComments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseModules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseModules_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseStars",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    Stars = table.Column<byte>(type: "smallint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseStars_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseStars_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    FileId = table.Column<long>(type: "bigint", nullable: true),
                    ModuleId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Assets_FileId",
                        column: x => x.FileId,
                        principalTable: "Assets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lessons_CourseModules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "CourseModules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: true),
                    ModuleId = table.Column<long>(type: "bigint", nullable: false),
                    FileId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Assets_FileId",
                        column: x => x.FileId,
                        principalTable: "Assets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Questions_CourseModules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "CourseModules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    QuestionCount = table.Column<int>(type: "integer", nullable: false),
                    ModuleId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quizzes_CourseModules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "CourseModules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonComments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LessonId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonComments_LessonComments_ParentId",
                        column: x => x.ParentId,
                        principalTable: "LessonComments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LessonComments_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LessonComments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuestionOptions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: true),
                    QuestionId = table.Column<long>(type: "bigint", nullable: false),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionOptions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizApplications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    QuizId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizApplications_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuizApplications_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuizQuestions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuizId = table.Column<long>(type: "bigint", nullable: false),
                    QuestionId = table.Column<long>(type: "bigint", nullable: false),
                    QuizId1 = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuizQuestions_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuizQuestions_Quizzes_QuizId1",
                        column: x => x.QuizId1,
                        principalTable: "Quizzes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuestionAnswers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuizId = table.Column<long>(type: "bigint", nullable: false),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    QuestionId = table.Column<long>(type: "bigint", nullable: false),
                    OptionId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    DeletedByUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionAnswers_QuestionOptions_OptionId",
                        column: x => x.OptionId,
                        principalTable: "QuestionOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionAnswers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuestionAnswers_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestionAnswers_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "Path", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2283), 0L, null, null, false, "Picture", "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.vecteezy.com%2Ffree-photos%2Fpicture&psig=AOvVaw3XaUHI9Jhqr2Yekc8F0A7X&ust=1715337265006000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCNjGn7WvgIYDFQAAAAAdAAAAABAE", null, null },
                    { 2L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2284), 0L, null, null, false, "Picture2", "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.vecteezy.com%2Ffree-photos%2Fpicture&psig=AOvVaw3XaUHI9Jhqr2Yekc8F0A7X&ust=1715337265006000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCNjGn7WvgIYDFQAAAAAdAAAAABAE", null, null }
                });

            migrationBuilder.InsertData(
                table: "CourseCategories",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1741), 0L, null, null, false, "IT", null, null });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "ShortName", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1763), 0L, null, null, false, "English", "EN", null, null },
                    { 2L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1764), 0L, null, null, false, "Spanish", "ES", null, null }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "Controller", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1L, "Post", "Students", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1246), 0L, null, null, false, null, null },
                    { 2L, "Put", "Students", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1249), 0L, null, null, false, null, null },
                    { 3L, "Delete", "Students", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1250), 0L, null, null, false, null, null },
                    { 4L, "Get", "Students", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1251), 0L, null, null, false, null, null },
                    { 5L, "Get", "Students", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1252), 0L, null, null, false, null, null },
                    { 6L, "UploadPicture", "Students", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1254), 0L, null, null, false, null, null },
                    { 7L, "DeletePicture", "Students", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1255), 0L, null, null, false, null, null },
                    { 8L, "Post", "Instructors", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1256), 0L, null, null, false, null, null },
                    { 9L, "Put", "Instructors", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1257), 0L, null, null, false, null, null },
                    { 10L, "Delete", "Instructors", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1258), 0L, null, null, false, null, null },
                    { 11L, "Get", "Instructors", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1259), 0L, null, null, false, null, null },
                    { 12L, "Get", "Instructors", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1260), 0L, null, null, false, null, null },
                    { 13L, "UploadPicture", "Instructors", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1262), 0L, null, null, false, null, null },
                    { 14L, "DeletePicture", "Instructors", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1263), 0L, null, null, false, null, null },
                    { 15L, "Post", "Users", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1264), 0L, null, null, false, null, null },
                    { 16L, "Put", "Users", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1265), 0L, null, null, false, null, null },
                    { 17L, "Delete", "Users", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1266), 0L, null, null, false, null, null },
                    { 18L, "Get", "Users", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1268), 0L, null, null, false, null, null },
                    { 19L, "Get", "Users", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1269), 0L, null, null, false, null, null },
                    { 20L, "ChangePassword", "Users", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1270), 0L, null, null, false, null, null },
                    { 21L, "Post", "Lessons", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1271), 0L, null, null, false, null, null },
                    { 22L, "Put", "Lessons", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1279), 0L, null, null, false, null, null },
                    { 23L, "Delete", "Lessons", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1280), 0L, null, null, false, null, null },
                    { 24L, "Get", "Lessons", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1281), 0L, null, null, false, null, null },
                    { 25L, "Get", "Lessons", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1282), 0L, null, null, false, null, null },
                    { 26L, "UploadPicture", "Lessons", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1283), 0L, null, null, false, null, null },
                    { 27L, "DeletePicture", "Lessons", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1284), 0L, null, null, false, null, null },
                    { 28L, "Post", "Courses", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1285), 0L, null, null, false, null, null },
                    { 29L, "Put", "Courses", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1286), 0L, null, null, false, null, null },
                    { 30L, "Delete", "Courses", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1288), 0L, null, null, false, null, null },
                    { 31L, "Get", "Courses", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1289), 0L, null, null, false, null, null },
                    { 32L, "Get", "Courses", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1290), 0L, null, null, false, null, null },
                    { 33L, "Post", "UserRoles", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1291), 0L, null, null, false, null, null },
                    { 34L, "Put", "UserRoles", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1292), 0L, null, null, false, null, null },
                    { 35L, "Delete", "UserRoles", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1293), 0L, null, null, false, null, null },
                    { 36L, "Get", "UserRoles", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1294), 0L, null, null, false, null, null },
                    { 37L, "Get", "UserRoles", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1295), 0L, null, null, false, null, null },
                    { 38L, "Post", "Permissions", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1296), 0L, null, null, false, null, null },
                    { 39L, "Put", "Permissions", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1297), 0L, null, null, false, null, null },
                    { 40L, "Delete", "Permissions", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1302), 0L, null, null, false, null, null },
                    { 41L, "Get", "Permissions", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1303), 0L, null, null, false, null, null },
                    { 42L, "Get", "Permissions", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1304), 0L, null, null, false, null, null },
                    { 43L, "Post", "StudentCourses", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1305), 0L, null, null, false, null, null },
                    { 44L, "Put", "StudentCourses", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1306), 0L, null, null, false, null, null },
                    { 45L, "Delete", "StudentCourses", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1307), 0L, null, null, false, null, null },
                    { 46L, "Get", "StudentCourses", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1308), 0L, null, null, false, null, null },
                    { 47L, "Get", "StudentCourses", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1310), 0L, null, null, false, null, null },
                    { 48L, "Post", "Quizzes", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1311), 0L, null, null, false, null, null },
                    { 49L, "Put", "Quizzes", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1312), 0L, null, null, false, null, null },
                    { 50L, "Delete", "Quizzes", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1313), 0L, null, null, false, null, null },
                    { 51L, "Get", "Quizzes", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1314), 0L, null, null, false, null, null },
                    { 52L, "Get", "Quizzes", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1315), 0L, null, null, false, null, null },
                    { 53L, "GenerateQuestions", "Quizzes", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1316), 0L, null, null, false, null, null },
                    { 54L, "Post", "QuizQuestions", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1317), 0L, null, null, false, null, null },
                    { 55L, "Put", "QuizQuestions", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1318), 0L, null, null, false, null, null },
                    { 56L, "Delete", "QuizQuestions", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1319), 0L, null, null, false, null, null },
                    { 57L, "Get", "QuizQuestions", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1321), 0L, null, null, false, null, null },
                    { 58L, "Get", "QuizQuestions", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1322), 0L, null, null, false, null, null },
                    { 59L, "Post", "QuizApplications", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1323), 0L, null, null, false, null, null },
                    { 60L, "Put", "QuizApplications", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1324), 0L, null, null, false, null, null },
                    { 61L, "Delete", "QuizApplications", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1325), 0L, null, null, false, null, null },
                    { 62L, "Get", "QuizApplications", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1327), 0L, null, null, false, null, null },
                    { 63L, "Get", "QuizApplications", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1328), 0L, null, null, false, null, null },
                    { 64L, "Post", "Questions", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1329), 0L, null, null, false, null, null },
                    { 65L, "Put", "Questions", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1330), 0L, null, null, false, null, null },
                    { 66L, "Delete", "Questions", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1331), 0L, null, null, false, null, null },
                    { 67L, "Get", "Questions", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1332), 0L, null, null, false, null, null },
                    { 68L, "Get", "Questions", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1333), 0L, null, null, false, null, null },
                    { 69L, "UploadPicture", "Questions", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1334), 0L, null, null, false, null, null },
                    { 70L, "DeletePicture", "Questions", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1335), 0L, null, null, false, null, null },
                    { 71L, "Post", "UserRoles", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1336), 0L, null, null, false, null, null },
                    { 72L, "Put", "UserRoles", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1337), 0L, null, null, false, null, null },
                    { 73L, "Delete", "UserRoles", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1338), 0L, null, null, false, null, null },
                    { 74L, "Get", "UserRoles", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1339), 0L, null, null, false, null, null },
                    { 75L, "Get", "UserRoles", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1340), 0L, null, null, false, null, null },
                    { 76L, "Post", "QuestionOptions", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1341), 0L, null, null, false, null, null },
                    { 77L, "Put", "QuestionOptions", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1342), 0L, null, null, false, null, null },
                    { 78L, "Delete", "QuestionOptions", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1343), 0L, null, null, false, null, null },
                    { 79L, "Get", "QuestionOptions", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1344), 0L, null, null, false, null, null },
                    { 80L, "Get", "QuestionOptions", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1345), 0L, null, null, false, null, null },
                    { 81L, "Post", "QuestionAnswers", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1346), 0L, null, null, false, null, null },
                    { 82L, "Put", "QuestionAnswers", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1347), 0L, null, null, false, null, null },
                    { 83L, "Delete", "QuestionAnswers", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1348), 0L, null, null, false, null, null },
                    { 84L, "Get", "QuestionAnswers", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1350), 0L, null, null, false, null, null },
                    { 85L, "Get", "QuestionAnswers", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1351), 0L, null, null, false, null, null },
                    { 86L, "Post", "LessonComments", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1358), 0L, null, null, false, null, null },
                    { 87L, "Put", "LessonComments", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1359), 0L, null, null, false, null, null },
                    { 88L, "Delete", "LessonComments", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1360), 0L, null, null, false, null, null },
                    { 89L, "Get", "LessonComments", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1361), 0L, null, null, false, null, null },
                    { 90L, "Get", "LessonComments", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1362), 0L, null, null, false, null, null },
                    { 91L, "Post", "Languages", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1363), 0L, null, null, false, null, null },
                    { 92L, "Put", "Languages", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1364), 0L, null, null, false, null, null },
                    { 93L, "Delete", "Languages", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1365), 0L, null, null, false, null, null },
                    { 94L, "Get", "Languages", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1366), 0L, null, null, false, null, null },
                    { 95L, "Get", "Languages", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1367), 0L, null, null, false, null, null },
                    { 96L, "Post", "InstructorStars", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1368), 0L, null, null, false, null, null },
                    { 97L, "Put", "InstructorStars", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1369), 0L, null, null, false, null, null },
                    { 98L, "Delete", "InstructorStars", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1370), 0L, null, null, false, null, null },
                    { 99L, "Get", "InstructorStars", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1372), 0L, null, null, false, null, null },
                    { 100L, "Get", "InstructorStars", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1373), 0L, null, null, false, null, null },
                    { 101L, "Post", "InstructorComments", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1374), 0L, null, null, false, null, null },
                    { 102L, "Put", "InstructorComments", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1375), 0L, null, null, false, null, null },
                    { 103L, "Delete", "InstructorComments", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1376), 0L, null, null, false, null, null },
                    { 104L, "Get", "InstructorComments", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1377), 0L, null, null, false, null, null },
                    { 105L, "Get", "InstructorComments", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1378), 0L, null, null, false, null, null },
                    { 106L, "Post", "RolePermissions", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1381), 0L, null, null, false, null, null },
                    { 107L, "Put", "RolePermissions", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1382), 0L, null, null, false, null, null },
                    { 108L, "Delete", "RolePermissions", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1384), 0L, null, null, false, null, null },
                    { 109L, "Get", "RolePermissions", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1385), 0L, null, null, false, null, null },
                    { 110L, "Get", "RolePermissions", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1386), 0L, null, null, false, null, null },
                    { 111L, "Post", "CourseModules", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1387), 0L, null, null, false, null, null },
                    { 112L, "Put", "CourseModules", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1388), 0L, null, null, false, null, null },
                    { 113L, "Delete", "CourseModules", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1389), 0L, null, null, false, null, null },
                    { 114L, "Get", "CourseModules", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1390), 0L, null, null, false, null, null },
                    { 115L, "Get", "CourseModules", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1392), 0L, null, null, false, null, null },
                    { 116L, "Post", "CourseStars", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1393), 0L, null, null, false, null, null },
                    { 117L, "Put", "CourseStars", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1394), 0L, null, null, false, null, null },
                    { 118L, "Delete", "CourseStars", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1395), 0L, null, null, false, null, null },
                    { 119L, "Get", "CourseStars", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1396), 0L, null, null, false, null, null },
                    { 120L, "Get", "CourseStars", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1397), 0L, null, null, false, null, null },
                    { 121L, "Login", "Accounts", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1398), 0L, null, null, false, null, null },
                    { 122L, "SendCode", "Accounts", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1399), 0L, null, null, false, null, null },
                    { 123L, "Confirm", "Accounts", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1400), 0L, null, null, false, null, null },
                    { 124L, "ResetPassword", "Accounts", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1401), 0L, null, null, false, null, null },
                    { 125L, "Post", "CourseComments", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1402), 0L, null, null, false, null, null },
                    { 126L, "Put", "CourseComments", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1403), 0L, null, null, false, null, null },
                    { 127L, "Delete", "CourseComments", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1405), 0L, null, null, false, null, null },
                    { 128L, "Get", "CourseComments", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1407), 0L, null, null, false, null, null },
                    { 129L, "Get", "CourseComments", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1408), 0L, null, null, false, null, null },
                    { 130L, "Post", "CourseCategories", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1409), 0L, null, null, false, null, null },
                    { 131L, "Put", "CourseCategories", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1410), 0L, null, null, false, null, null },
                    { 132L, "Delete", "CourseCategories", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1411), 0L, null, null, false, null, null },
                    { 133L, "Get", "CourseCategories", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1412), 0L, null, null, false, null, null },
                    { 134L, "Get", "CourseCategories", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1413), 0L, null, null, false, null, null }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1713), 0L, null, null, false, "Admin", null, null },
                    { 2L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1714), 0L, null, null, false, "Student", null, null },
                    { 3L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1715), 0L, null, null, false, "Instructor", null, null }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "PermissionId", "RoleId", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1798), 0L, null, null, false, 1L, 1L, null, null },
                    { 2L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1800), 0L, null, null, false, 2L, 1L, null, null },
                    { 3L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1801), 0L, null, null, false, 3L, 1L, null, null },
                    { 4L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1802), 0L, null, null, false, 4L, 1L, null, null },
                    { 5L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1803), 0L, null, null, false, 5L, 1L, null, null },
                    { 6L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1804), 0L, null, null, false, 6L, 1L, null, null },
                    { 7L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1805), 0L, null, null, false, 7L, 1L, null, null },
                    { 8L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1807), 0L, null, null, false, 8L, 1L, null, null },
                    { 9L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1808), 0L, null, null, false, 9L, 1L, null, null },
                    { 10L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1809), 0L, null, null, false, 10L, 1L, null, null },
                    { 11L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1810), 0L, null, null, false, 11L, 1L, null, null },
                    { 12L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1812), 0L, null, null, false, 12L, 1L, null, null },
                    { 13L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1813), 0L, null, null, false, 13L, 1L, null, null },
                    { 14L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1814), 0L, null, null, false, 14L, 1L, null, null },
                    { 15L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1815), 0L, null, null, false, 15L, 1L, null, null },
                    { 16L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1816), 0L, null, null, false, 16L, 1L, null, null },
                    { 17L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1996), 0L, null, null, false, 17L, 1L, null, null },
                    { 18L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1997), 0L, null, null, false, 18L, 1L, null, null },
                    { 19L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1998), 0L, null, null, false, 19L, 1L, null, null },
                    { 20L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(1999), 0L, null, null, false, 20L, 1L, null, null },
                    { 21L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2007), 0L, null, null, false, 21L, 1L, null, null },
                    { 22L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2008), 0L, null, null, false, 22L, 1L, null, null },
                    { 23L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2009), 0L, null, null, false, 23L, 1L, null, null },
                    { 24L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2010), 0L, null, null, false, 24L, 1L, null, null },
                    { 25L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2011), 0L, null, null, false, 25L, 1L, null, null },
                    { 26L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2012), 0L, null, null, false, 26L, 1L, null, null },
                    { 27L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2013), 0L, null, null, false, 27L, 1L, null, null },
                    { 28L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2014), 0L, null, null, false, 28L, 1L, null, null },
                    { 29L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2015), 0L, null, null, false, 29L, 1L, null, null },
                    { 30L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2016), 0L, null, null, false, 30L, 1L, null, null },
                    { 31L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2019), 0L, null, null, false, 31L, 1L, null, null },
                    { 32L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2020), 0L, null, null, false, 32L, 1L, null, null },
                    { 33L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2021), 0L, null, null, false, 33L, 1L, null, null },
                    { 34L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2022), 0L, null, null, false, 34L, 1L, null, null },
                    { 35L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2023), 0L, null, null, false, 35L, 1L, null, null },
                    { 36L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2024), 0L, null, null, false, 36L, 1L, null, null },
                    { 37L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2025), 0L, null, null, false, 37L, 1L, null, null },
                    { 38L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2026), 0L, null, null, false, 38L, 1L, null, null },
                    { 39L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2027), 0L, null, null, false, 39L, 1L, null, null },
                    { 40L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2028), 0L, null, null, false, 40L, 1L, null, null },
                    { 41L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2029), 0L, null, null, false, 41L, 1L, null, null },
                    { 42L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2032), 0L, null, null, false, 42L, 1L, null, null },
                    { 43L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2033), 0L, null, null, false, 43L, 1L, null, null },
                    { 44L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2034), 0L, null, null, false, 44L, 1L, null, null },
                    { 45L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2035), 0L, null, null, false, 45L, 1L, null, null },
                    { 46L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2036), 0L, null, null, false, 46L, 1L, null, null },
                    { 47L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2037), 0L, null, null, false, 47L, 1L, null, null },
                    { 48L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2038), 0L, null, null, false, 48L, 1L, null, null },
                    { 49L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2039), 0L, null, null, false, 49L, 1L, null, null },
                    { 50L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2040), 0L, null, null, false, 50L, 1L, null, null },
                    { 51L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2041), 0L, null, null, false, 51L, 1L, null, null },
                    { 52L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2043), 0L, null, null, false, 52L, 1L, null, null },
                    { 53L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2044), 0L, null, null, false, 53L, 1L, null, null },
                    { 54L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2046), 0L, null, null, false, 54L, 1L, null, null },
                    { 55L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2047), 0L, null, null, false, 55L, 1L, null, null },
                    { 56L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2048), 0L, null, null, false, 56L, 1L, null, null },
                    { 57L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2049), 0L, null, null, false, 57L, 1L, null, null },
                    { 58L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2050), 0L, null, null, false, 58L, 1L, null, null },
                    { 59L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2051), 0L, null, null, false, 59L, 1L, null, null },
                    { 60L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2052), 0L, null, null, false, 60L, 1L, null, null },
                    { 61L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2053), 0L, null, null, false, 61L, 1L, null, null },
                    { 62L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2055), 0L, null, null, false, 62L, 1L, null, null },
                    { 63L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2056), 0L, null, null, false, 63L, 1L, null, null },
                    { 64L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2057), 0L, null, null, false, 64L, 1L, null, null },
                    { 65L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2058), 0L, null, null, false, 65L, 1L, null, null },
                    { 66L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2059), 0L, null, null, false, 66L, 1L, null, null },
                    { 67L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2060), 0L, null, null, false, 67L, 1L, null, null },
                    { 68L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2061), 0L, null, null, false, 68L, 1L, null, null },
                    { 69L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2062), 0L, null, null, false, 69L, 1L, null, null },
                    { 70L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2063), 0L, null, null, false, 70L, 1L, null, null },
                    { 71L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2065), 0L, null, null, false, 71L, 1L, null, null },
                    { 72L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2066), 0L, null, null, false, 72L, 1L, null, null },
                    { 73L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2067), 0L, null, null, false, 73L, 1L, null, null },
                    { 74L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2068), 0L, null, null, false, 74L, 1L, null, null },
                    { 75L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2069), 0L, null, null, false, 75L, 1L, null, null },
                    { 76L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2070), 0L, null, null, false, 76L, 1L, null, null },
                    { 77L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2072), 0L, null, null, false, 77L, 1L, null, null },
                    { 78L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2082), 0L, null, null, false, 78L, 1L, null, null },
                    { 79L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2083), 0L, null, null, false, 79L, 1L, null, null },
                    { 80L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2084), 0L, null, null, false, 80L, 1L, null, null },
                    { 81L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2085), 0L, null, null, false, 81L, 1L, null, null },
                    { 82L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2086), 0L, null, null, false, 82L, 1L, null, null },
                    { 83L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2087), 0L, null, null, false, 83L, 1L, null, null },
                    { 84L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2089), 0L, null, null, false, 84L, 1L, null, null },
                    { 85L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2091), 0L, null, null, false, 85L, 1L, null, null },
                    { 86L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2092), 0L, null, null, false, 86L, 1L, null, null },
                    { 87L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2095), 0L, null, null, false, 87L, 1L, null, null },
                    { 88L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2096), 0L, null, null, false, 88L, 1L, null, null },
                    { 89L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2097), 0L, null, null, false, 89L, 1L, null, null },
                    { 90L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2098), 0L, null, null, false, 90L, 1L, null, null },
                    { 91L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2100), 0L, null, null, false, 91L, 1L, null, null },
                    { 92L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2101), 0L, null, null, false, 92L, 1L, null, null },
                    { 93L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2102), 0L, null, null, false, 93L, 1L, null, null },
                    { 94L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2103), 0L, null, null, false, 94L, 1L, null, null },
                    { 95L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2104), 0L, null, null, false, 95L, 1L, null, null },
                    { 96L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2105), 0L, null, null, false, 96L, 1L, null, null },
                    { 97L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2106), 0L, null, null, false, 97L, 1L, null, null },
                    { 98L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2107), 0L, null, null, false, 98L, 1L, null, null },
                    { 99L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2109), 0L, null, null, false, 99L, 1L, null, null },
                    { 100L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2110), 0L, null, null, false, 100L, 1L, null, null },
                    { 101L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2111), 0L, null, null, false, 101L, 1L, null, null },
                    { 102L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2112), 0L, null, null, false, 102L, 1L, null, null },
                    { 103L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2113), 0L, null, null, false, 103L, 1L, null, null },
                    { 104L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2115), 0L, null, null, false, 104L, 1L, null, null },
                    { 105L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2116), 0L, null, null, false, 105L, 1L, null, null },
                    { 106L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2117), 0L, null, null, false, 106L, 1L, null, null },
                    { 107L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2118), 0L, null, null, false, 107L, 1L, null, null },
                    { 108L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2119), 0L, null, null, false, 108L, 1L, null, null },
                    { 109L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2120), 0L, null, null, false, 109L, 1L, null, null },
                    { 110L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2121), 0L, null, null, false, 110L, 1L, null, null },
                    { 111L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2122), 0L, null, null, false, 111L, 1L, null, null },
                    { 112L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2123), 0L, null, null, false, 112L, 1L, null, null },
                    { 113L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2124), 0L, null, null, false, 113L, 1L, null, null },
                    { 114L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2125), 0L, null, null, false, 114L, 1L, null, null },
                    { 115L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2126), 0L, null, null, false, 115L, 1L, null, null },
                    { 116L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2127), 0L, null, null, false, 116L, 1L, null, null },
                    { 117L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2128), 0L, null, null, false, 117L, 1L, null, null },
                    { 118L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2130), 0L, null, null, false, 118L, 1L, null, null },
                    { 119L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2131), 0L, null, null, false, 119L, 1L, null, null },
                    { 120L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2132), 0L, null, null, false, 120L, 1L, null, null },
                    { 121L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2133), 0L, null, null, false, 121L, 1L, null, null },
                    { 122L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2135), 0L, null, null, false, 122L, 1L, null, null },
                    { 123L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2136), 0L, null, null, false, 123L, 1L, null, null },
                    { 124L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2137), 0L, null, null, false, 124L, 1L, null, null },
                    { 125L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2138), 0L, null, null, false, 125L, 1L, null, null },
                    { 126L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2139), 0L, null, null, false, 126L, 1L, null, null },
                    { 127L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2140), 0L, null, null, false, 127L, 1L, null, null },
                    { 128L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2141), 0L, null, null, false, 128L, 1L, null, null },
                    { 129L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2142), 0L, null, null, false, 129L, 1L, null, null },
                    { 130L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2144), 0L, null, null, false, 130L, 1L, null, null },
                    { 131L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2145), 0L, null, null, false, 131L, 1L, null, null },
                    { 132L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2146), 0L, null, null, false, 132L, 1L, null, null },
                    { 133L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2147), 0L, null, null, false, 133L, 1L, null, null },
                    { 134L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2148), 0L, null, null, false, 134L, 1L, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DateOfBirth", "DeletedAt", "DeletedByUserId", "Email", "FirstName", "IsDeleted", "LastName", "Password", "Phone", "RoleId", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2254), 0L, new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Email1@gmail.com", "FirstName1", false, "LastName1", "Password1", "+998991111111", 1L, null, null },
                    { 2L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2257), 0L, new DateTime(2002, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Email2@gmail.com", "FirstName2", false, "LastName2", "Password2", "+998992222222", 2L, null, null },
                    { 3L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2259), 0L, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Email3@gmail.com", "FirstName3", false, "LastName3", "Password3", "+998993333333", 3L, null, null }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "About", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "DetailId", "IsDeleted", "PictureId", "Profession", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, "Description", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2692), 0L, null, null, 3L, false, 2L, "Software Developer", null, null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "DetailId", "IsDeleted", "PictureId", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2339), 0L, null, null, 2L, false, 1L, null, null });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "CountOfLessons", "CourseCategoryId", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "Description", "Duration", "FileId", "InstructorId", "IsDeleted", "LanguageId", "Level", "Name", "Price", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, 1L, 150, null, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2312), 0L, null, null, "Course Description", 7, 1L, 1L, false, 1L, 2, ".NET", 2200000.00m, null, null });

            migrationBuilder.InsertData(
                table: "InstructorComments",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "InstructorId", "IsDeleted", "StudentId", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, null, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2739), 0L, null, null, 1L, false, 1L, null, null });

            migrationBuilder.InsertData(
                table: "InstructorStars",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "InstructorId", "IsDeleted", "Stars", "StudentId", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2719), 0L, null, null, 1L, false, (byte)5, 1L, null, null });

            migrationBuilder.InsertData(
                table: "CourseComments",
                columns: new[] { "Id", "Content", "CourseId", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "StudentId", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, "Course Comment", 1L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2573), 0L, null, null, false, 1L, null, null });

            migrationBuilder.InsertData(
                table: "CourseModules",
                columns: new[] { "Id", "CourseId", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, 1L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2599), 0L, null, null, false, "Module1", null, null });

            migrationBuilder.InsertData(
                table: "CourseStars",
                columns: new[] { "Id", "CourseId", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Stars", "StudentId", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, 1L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2623), 0L, null, null, false, (byte)5, 1L, null, null });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "Id", "CourseId", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "StudentId", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, 1L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2544), 0L, null, null, false, 1L, null, null });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "Description", "FileId", "IsDeleted", "ModuleId", "Title", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2651), 0L, null, null, "Lesson Description", 2L, false, 1L, "Lesson1", null, null });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "FileId", "IsDeleted", "ModuleId", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, "Content", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2874), 0L, null, null, 2L, false, 1L, null, null });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "ModuleId", "Name", "QuestionCount", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2759), 0L, null, null, false, 1L, "Quiz1", 5, null, null });

            migrationBuilder.InsertData(
                table: "LessonComments",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "LessonId", "ParentId", "UpdatedAt", "UpdatedByUserId", "UserId" },
                values: new object[] { 1L, "Lesson Comment", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2669), 0L, null, null, false, 1L, null, null, null, 2L });

            migrationBuilder.InsertData(
                table: "QuestionOptions",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsCorrect", "IsDeleted", "QuestionId", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1L, "asd", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2891), 0L, null, null, true, false, 1L, null, null },
                    { 2L, "dsd", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2893), 0L, null, null, false, false, 1L, null, null },
                    { 3L, "bdb", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2894), 0L, null, null, false, false, 1L, null, null },
                    { 4L, "waw", new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2895), 0L, null, null, false, false, 1L, null, null }
                });

            migrationBuilder.InsertData(
                table: "QuizApplications",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "EndTime", "IsDeleted", "QuizId", "StartTime", "StudentId", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2854), 0L, null, null, new DateTime(2024, 11, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), false, 1L, new DateTime(2024, 10, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), 1L, null, null });

            migrationBuilder.InsertData(
                table: "QuizQuestions",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "QuestionId", "QuizId", "QuizId1", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2928), 0L, null, null, false, 1L, 1L, null, null, null });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "OptionId", "QuestionId", "QuizId", "StudentId", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, new DateTime(2024, 5, 9, 14, 40, 13, 87, DateTimeKind.Utc).AddTicks(2910), 0L, null, null, false, 1L, 1L, 1L, 1L, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_CourseComments_CourseId",
                table: "CourseComments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseComments_StudentId",
                table: "CourseComments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseModules_CourseId",
                table: "CourseModules",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseCategoryId",
                table: "Courses",
                column: "CourseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_FileId",
                table: "Courses",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LanguageId",
                table: "Courses",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStars_CourseId",
                table: "CourseStars",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStars_StudentId",
                table: "CourseStars",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorComments_InstructorId",
                table: "InstructorComments",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorComments_StudentId",
                table: "InstructorComments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_DetailId",
                table: "Instructors",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_PictureId",
                table: "Instructors",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorStars_InstructorId",
                table: "InstructorStars",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorStars_StudentId",
                table: "InstructorStars",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonComments_LessonId",
                table: "LessonComments",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonComments_ParentId",
                table: "LessonComments",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonComments_UserId",
                table: "LessonComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_FileId",
                table: "Lessons",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ModuleId",
                table: "Lessons",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswers_OptionId",
                table: "QuestionAnswers",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswers_QuestionId",
                table: "QuestionAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswers_QuizId",
                table: "QuestionAnswers",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswers_StudentId",
                table: "QuestionAnswers",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionOptions_QuestionId",
                table: "QuestionOptions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_FileId",
                table: "Questions",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ModuleId",
                table: "Questions",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizApplications_QuizId",
                table: "QuizApplications",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizApplications_StudentId",
                table: "QuizApplications",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestions_QuestionId",
                table: "QuizQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestions_QuizId",
                table: "QuizQuestions",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestions_QuizId1",
                table: "QuizQuestions",
                column: "QuizId1");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_ModuleId",
                table: "Quizzes",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId",
                table: "RolePermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_StudentId",
                table: "StudentCourses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DetailId",
                table: "Students",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_PictureId",
                table: "Students",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseComments");

            migrationBuilder.DropTable(
                name: "CourseStars");

            migrationBuilder.DropTable(
                name: "InstructorComments");

            migrationBuilder.DropTable(
                name: "InstructorStars");

            migrationBuilder.DropTable(
                name: "LessonComments");

            migrationBuilder.DropTable(
                name: "QuestionAnswers");

            migrationBuilder.DropTable(
                name: "QuizApplications");

            migrationBuilder.DropTable(
                name: "QuizQuestions");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "QuestionOptions");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "CourseModules");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "CourseCategories");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserRoles");
        }
    }
}
