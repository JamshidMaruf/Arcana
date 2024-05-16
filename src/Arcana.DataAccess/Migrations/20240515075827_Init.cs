using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Arcana.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
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
                    FileId = table.Column<long>(type: "bigint", nullable: true),
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
                        principalColumn: "Id");
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
                name: "CourseStar",
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
                        onDelete: ReferentialAction.Cascade);
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
                    { 1L, new DateTime(2024, 5, 15, 7, 58, 25, 970, DateTimeKind.Utc).AddTicks(9879), 0L, null, null, false, "Picture", "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.vecteezy.com%2Ffree-photos%2Fpicture&psig=AOvVaw3XaUHI9Jhqr2Yekc8F0A7X&ust=1715337265006000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCNjGn7WvgIYDFQAAAAAdAAAAABAE", null, null },
                    { 2L, new DateTime(2024, 5, 15, 7, 58, 25, 970, DateTimeKind.Utc).AddTicks(9881), 0L, null, null, false, "Picture2", "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.vecteezy.com%2Ffree-photos%2Fpicture&psig=AOvVaw3XaUHI9Jhqr2Yekc8F0A7X&ust=1715337265006000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCNjGn7WvgIYDFQAAAAAdAAAAABAE", null, null }
                });

            migrationBuilder.InsertData(
                table: "CourseCategories",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, new DateTime(2024, 5, 15, 7, 58, 25, 971, DateTimeKind.Utc).AddTicks(181), 0L, null, null, false, "IT", null, null });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "ShortName", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 5, 15, 7, 58, 25, 973, DateTimeKind.Utc).AddTicks(8310), 0L, null, null, false, "English", "EN", null, null },
                    { 2L, new DateTime(2024, 5, 15, 7, 58, 25, 973, DateTimeKind.Utc).AddTicks(8311), 0L, null, null, false, "Spanish", "ES", null, null }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "Controller", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1L, "PostAsync", "Students", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4384), 0L, null, null, false, null, null },
                    { 2L, "PutAsync", "Students", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4385), 0L, null, null, false, null, null },
                    { 3L, "DeleteAsync", "Students", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4386), 0L, null, null, false, null, null },
                    { 4L, "GetAllAsync", "Students", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4388), 0L, null, null, false, null, null },
                    { 5L, "GetAsync", "Students", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4389), 0L, null, null, false, null, null },
                    { 6L, "UploadPictureAsync", "Students", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4390), 0L, null, null, false, null, null },
                    { 7L, "DeletePictureAsync", "Students", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4391), 0L, null, null, false, null, null },
                    { 8L, "PostAsync", "Instructors", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4392), 0L, null, null, false, null, null },
                    { 9L, "PutAsync", "Instructors", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4393), 0L, null, null, false, null, null },
                    { 10L, "DeleteAsync", "Instructors", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4394), 0L, null, null, false, null, null },
                    { 11L, "GetAllAsync", "Instructors", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4395), 0L, null, null, false, null, null },
                    { 12L, "GetAsync", "Instructors", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4396), 0L, null, null, false, null, null },
                    { 13L, "UploadPictureAsync", "Instructors", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4397), 0L, null, null, false, null, null },
                    { 14L, "DeletePictureAsync", "Instructors", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4398), 0L, null, null, false, null, null },
                    { 15L, "PostAsync", "Users", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4400), 0L, null, null, false, null, null },
                    { 16L, "PutAsync", "Users", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4401), 0L, null, null, false, null, null },
                    { 17L, "DeleteAsync", "Users", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4402), 0L, null, null, false, null, null },
                    { 18L, "GetAllAsync", "Users", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4403), 0L, null, null, false, null, null },
                    { 19L, "GetAsync", "Users", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4404), 0L, null, null, false, null, null },
                    { 20L, "ChangePasswordAsync", "Users", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4405), 0L, null, null, false, null, null },
                    { 21L, "PostAsync", "Lessons", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4406), 0L, null, null, false, null, null },
                    { 22L, "PutAsync", "Lessons", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4407), 0L, null, null, false, null, null },
                    { 23L, "DeleteAsync", "Lessons", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4408), 0L, null, null, false, null, null },
                    { 24L, "GetAllAsync", "Lessons", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4409), 0L, null, null, false, null, null },
                    { 25L, "GetAsync", "Lessons", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4410), 0L, null, null, false, null, null },
                    { 26L, "UploadPictureAsync", "Lessons", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4411), 0L, null, null, false, null, null },
                    { 27L, "DeletePictureAsync", "Lessons", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4412), 0L, null, null, false, null, null },
                    { 28L, "PostAsync", "Courses", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4414), 0L, null, null, false, null, null },
                    { 29L, "PutAsync", "Courses", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4415), 0L, null, null, false, null, null },
                    { 30L, "DeleteAsync", "Courses", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4416), 0L, null, null, false, null, null },
                    { 31L, "GetAllAsync", "Courses", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4417), 0L, null, null, false, null, null },
                    { 32L, "GetAsync", "Courses", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4418), 0L, null, null, false, null, null },
                    { 33L, "PostAsync", "UserRoles", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4419), 0L, null, null, false, null, null },
                    { 34L, "PutAsync", "UserRoles", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4420), 0L, null, null, false, null, null },
                    { 35L, "DeleteAsync", "UserRoles", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4421), 0L, null, null, false, null, null },
                    { 36L, "GetAllAsync", "UserRoles", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4422), 0L, null, null, false, null, null },
                    { 37L, "GetAsync", "UserRoles", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4423), 0L, null, null, false, null, null },
                    { 38L, "PostAsync", "Permissions", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4424), 0L, null, null, false, null, null },
                    { 39L, "PutAsync", "Permissions", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4425), 0L, null, null, false, null, null },
                    { 40L, "DeleteAsync", "Permissions", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4466), 0L, null, null, false, null, null },
                    { 41L, "GetAllAsync", "Permissions", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4467), 0L, null, null, false, null, null },
                    { 42L, "GetAsync", "Permissions", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4468), 0L, null, null, false, null, null },
                    { 43L, "PostAsync", "StudentCourses", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4469), 0L, null, null, false, null, null },
                    { 44L, "PutAsync", "StudentCourses", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4471), 0L, null, null, false, null, null },
                    { 45L, "DeleteAsync", "StudentCourses", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4472), 0L, null, null, false, null, null },
                    { 46L, "GetAllAsync", "StudentCourses", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4473), 0L, null, null, false, null, null },
                    { 47L, "GetAsync", "StudentCourses", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4474), 0L, null, null, false, null, null },
                    { 48L, "PostAsync", "Quizzes", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4475), 0L, null, null, false, null, null },
                    { 49L, "PutAsync", "Quizzes", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4476), 0L, null, null, false, null, null },
                    { 50L, "DeleteAsync", "Quizzes", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4478), 0L, null, null, false, null, null },
                    { 51L, "GetAllAsync", "Quizzes", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4479), 0L, null, null, false, null, null },
                    { 52L, "GetAsync", "Quizzes", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4480), 0L, null, null, false, null, null },
                    { 53L, "GenerateQuestionsAsync", "Quizzes", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4481), 0L, null, null, false, null, null },
                    { 54L, "PostAsync", "QuizQuestions", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4482), 0L, null, null, false, null, null },
                    { 55L, "PutAsync", "QuizQuestions", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4483), 0L, null, null, false, null, null },
                    { 56L, "DeleteAsync", "QuizQuestions", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4484), 0L, null, null, false, null, null },
                    { 57L, "GetAllAsync", "QuizQuestions", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4485), 0L, null, null, false, null, null },
                    { 58L, "GetAsync", "QuizQuestions", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4486), 0L, null, null, false, null, null },
                    { 59L, "PostAsync", "QuizApplications", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4487), 0L, null, null, false, null, null },
                    { 60L, "PutAsync", "QuizApplications", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4488), 0L, null, null, false, null, null },
                    { 61L, "DeleteAsync", "QuizApplications", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4490), 0L, null, null, false, null, null },
                    { 62L, "GetAllAsync", "QuizApplications", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4491), 0L, null, null, false, null, null },
                    { 63L, "GetAsync", "QuizApplications", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4492), 0L, null, null, false, null, null },
                    { 64L, "PostAsync", "Questions", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4493), 0L, null, null, false, null, null },
                    { 65L, "PutAsync", "Questions", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4494), 0L, null, null, false, null, null },
                    { 66L, "DeleteAsync", "Questions", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4495), 0L, null, null, false, null, null },
                    { 67L, "GetAllAsync", "Questions", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4496), 0L, null, null, false, null, null },
                    { 68L, "GetAsync", "Questions", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4497), 0L, null, null, false, null, null },
                    { 69L, "UploadPictureAsync", "Questions", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4498), 0L, null, null, false, null, null },
                    { 70L, "DeletePictureAsync", "Questions", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4499), 0L, null, null, false, null, null },
                    { 71L, "PostAsync", "UserRoles", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4500), 0L, null, null, false, null, null },
                    { 72L, "PutAsync", "UserRoles", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4501), 0L, null, null, false, null, null },
                    { 73L, "DeleteAsync", "UserRoles", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4502), 0L, null, null, false, null, null },
                    { 74L, "GetAllAsync", "UserRoles", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4503), 0L, null, null, false, null, null },
                    { 75L, "GetAsync", "UserRoles", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4504), 0L, null, null, false, null, null },
                    { 76L, "PostAsync", "QuestionOptions", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4505), 0L, null, null, false, null, null },
                    { 77L, "PutAsync", "QuestionOptions", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4506), 0L, null, null, false, null, null },
                    { 78L, "DeleteAsync", "QuestionOptions", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4507), 0L, null, null, false, null, null },
                    { 79L, "GetAllAsync", "QuestionOptions", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4508), 0L, null, null, false, null, null },
                    { 80L, "GetAsync", "QuestionOptions", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4509), 0L, null, null, false, null, null },
                    { 81L, "PostAsync", "QuestionAnswers", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4511), 0L, null, null, false, null, null },
                    { 82L, "PutAsync", "QuestionAnswers", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4512), 0L, null, null, false, null, null },
                    { 83L, "DeleteAsync", "QuestionAnswers", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4513), 0L, null, null, false, null, null },
                    { 84L, "GetAllAsync", "QuestionAnswers", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4514), 0L, null, null, false, null, null },
                    { 86L, "PostAsync", "LessonComments", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4515), 0L, null, null, false, null, null },
                    { 87L, "PutAsync", "LessonComments", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4516), 0L, null, null, false, null, null },
                    { 88L, "DeleteAsync", "LessonComments", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4517), 0L, null, null, false, null, null },
                    { 89L, "GetAllAsync", "LessonComments", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4518), 0L, null, null, false, null, null },
                    { 90L, "GetAsync", "LessonComments", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4519), 0L, null, null, false, null, null },
                    { 91L, "PostAsync", "Languages", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4520), 0L, null, null, false, null, null },
                    { 92L, "PutAsync", "Languages", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4521), 0L, null, null, false, null, null },
                    { 93L, "DeleteAsync", "Languages", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4522), 0L, null, null, false, null, null },
                    { 94L, "GetAllAsync", "Languages", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4523), 0L, null, null, false, null, null },
                    { 95L, "GetAsync", "Languages", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4524), 0L, null, null, false, null, null },
                    { 96L, "PostAsync", "InstructorStars", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4526), 0L, null, null, false, null, null },
                    { 97L, "PutAsync", "InstructorStars", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4527), 0L, null, null, false, null, null },
                    { 98L, "DeleteAsync", "InstructorStars", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4528), 0L, null, null, false, null, null },
                    { 99L, "GetAllAsync", "InstructorStars", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4529), 0L, null, null, false, null, null },
                    { 100L, "GetAsync", "InstructorStars", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4530), 0L, null, null, false, null, null },
                    { 101L, "PostAsync", "InstructorComments", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4531), 0L, null, null, false, null, null },
                    { 102L, "PutAsync", "InstructorComments", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4532), 0L, null, null, false, null, null },
                    { 103L, "DeleteAsync", "InstructorComments", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4533), 0L, null, null, false, null, null },
                    { 104L, "GetAllAsync", "InstructorComments", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4534), 0L, null, null, false, null, null },
                    { 105L, "GetAsync", "InstructorComments", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4570), 0L, null, null, false, null, null },
                    { 106L, "PostAsync", "RolePermissions", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4571), 0L, null, null, false, null, null },
                    { 107L, "PutAsync", "RolePermissions", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4572), 0L, null, null, false, null, null },
                    { 108L, "DeleteAsync", "RolePermissions", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4574), 0L, null, null, false, null, null },
                    { 109L, "GetAllAsync", "RolePermissions", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4575), 0L, null, null, false, null, null },
                    { 110L, "GetAsync", "RolePermissions", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4576), 0L, null, null, false, null, null },
                    { 111L, "PostAsync", "CourseModules", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4577), 0L, null, null, false, null, null },
                    { 112L, "PutAsync", "CourseModules", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4578), 0L, null, null, false, null, null },
                    { 113L, "DeleteAsync", "CourseModules", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4579), 0L, null, null, false, null, null },
                    { 114L, "GetAllAsync", "CourseModules", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4580), 0L, null, null, false, null, null },
                    { 115L, "GetAsync", "CourseModules", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4581), 0L, null, null, false, null, null },
                    { 116L, "PostAsync", "CourseStar", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4582), 0L, null, null, false, null, null },
                    { 117L, "PutAsync", "CourseStar", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4583), 0L, null, null, false, null, null },
                    { 118L, "DeleteAsync", "CourseStar", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4584), 0L, null, null, false, null, null },
                    { 119L, "GetAllAsync", "CourseStar", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4585), 0L, null, null, false, null, null },
                    { 120L, "GetAsync", "CourseStar", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4586), 0L, null, null, false, null, null },
                    { 121L, "PostAsync", "CourseComments", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4587), 0L, null, null, false, null, null },
                    { 122L, "PutAsync", "CourseComments", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4588), 0L, null, null, false, null, null },
                    { 123L, "DeleteAsync", "CourseComments", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4589), 0L, null, null, false, null, null },
                    { 124L, "GetAllAsync", "CourseComments", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4590), 0L, null, null, false, null, null },
                    { 125L, "GetAsync", "CourseComments", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4591), 0L, null, null, false, null, null },
                    { 126L, "PostAsync", "CourseCategories", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4592), 0L, null, null, false, null, null },
                    { 127L, "PutAsync", "CourseCategories", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4593), 0L, null, null, false, null, null },
                    { 128L, "DeleteAsync", "CourseCategories", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4594), 0L, null, null, false, null, null },
                    { 129L, "GetAllAsync", "CourseCategories", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4595), 0L, null, null, false, null, null },
                    { 130L, "GetAsync", "CourseCategories", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4596), 0L, null, null, false, null, null }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 5, 15, 7, 58, 26, 987, DateTimeKind.Utc).AddTicks(6264), 0L, null, null, false, "Admin", null, null },
                    { 2L, new DateTime(2024, 5, 15, 7, 58, 26, 987, DateTimeKind.Utc).AddTicks(6270), 0L, null, null, false, "Student", null, null },
                    { 3L, new DateTime(2024, 5, 15, 7, 58, 26, 987, DateTimeKind.Utc).AddTicks(6273), 0L, null, null, false, "Instructor", null, null }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "PermissionId", "RoleId", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5888), 0L, null, null, false, 1L, 1L, null, null },
                    { 2L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5890), 0L, null, null, false, 2L, 1L, null, null },
                    { 3L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5891), 0L, null, null, false, 3L, 1L, null, null },
                    { 4L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5892), 0L, null, null, false, 4L, 1L, null, null },
                    { 5L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5893), 0L, null, null, false, 5L, 1L, null, null },
                    { 6L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5894), 0L, null, null, false, 6L, 1L, null, null },
                    { 7L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5895), 0L, null, null, false, 7L, 1L, null, null },
                    { 8L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5896), 0L, null, null, false, 8L, 1L, null, null },
                    { 9L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5897), 0L, null, null, false, 9L, 1L, null, null },
                    { 10L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5899), 0L, null, null, false, 10L, 1L, null, null },
                    { 11L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5900), 0L, null, null, false, 11L, 1L, null, null },
                    { 12L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5901), 0L, null, null, false, 12L, 1L, null, null },
                    { 13L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5902), 0L, null, null, false, 13L, 1L, null, null },
                    { 14L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5903), 0L, null, null, false, 14L, 1L, null, null },
                    { 15L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5904), 0L, null, null, false, 15L, 1L, null, null },
                    { 16L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5905), 0L, null, null, false, 16L, 1L, null, null },
                    { 17L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5906), 0L, null, null, false, 17L, 1L, null, null },
                    { 18L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5907), 0L, null, null, false, 18L, 1L, null, null },
                    { 19L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5908), 0L, null, null, false, 19L, 1L, null, null },
                    { 20L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5909), 0L, null, null, false, 20L, 1L, null, null },
                    { 21L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5910), 0L, null, null, false, 21L, 1L, null, null },
                    { 22L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5911), 0L, null, null, false, 22L, 1L, null, null },
                    { 23L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5912), 0L, null, null, false, 23L, 1L, null, null },
                    { 24L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5913), 0L, null, null, false, 24L, 1L, null, null },
                    { 25L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5914), 0L, null, null, false, 25L, 1L, null, null },
                    { 26L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5915), 0L, null, null, false, 26L, 1L, null, null },
                    { 27L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5916), 0L, null, null, false, 27L, 1L, null, null },
                    { 28L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5917), 0L, null, null, false, 28L, 1L, null, null },
                    { 29L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5918), 0L, null, null, false, 29L, 1L, null, null },
                    { 30L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5919), 0L, null, null, false, 30L, 1L, null, null },
                    { 31L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5920), 0L, null, null, false, 31L, 1L, null, null },
                    { 32L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5921), 0L, null, null, false, 32L, 1L, null, null },
                    { 33L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5922), 0L, null, null, false, 33L, 1L, null, null },
                    { 34L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5923), 0L, null, null, false, 34L, 1L, null, null },
                    { 35L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5924), 0L, null, null, false, 35L, 1L, null, null },
                    { 36L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5925), 0L, null, null, false, 36L, 1L, null, null },
                    { 37L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5927), 0L, null, null, false, 37L, 1L, null, null },
                    { 38L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5928), 0L, null, null, false, 38L, 1L, null, null },
                    { 39L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5929), 0L, null, null, false, 39L, 1L, null, null },
                    { 40L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5930), 0L, null, null, false, 40L, 1L, null, null },
                    { 41L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5931), 0L, null, null, false, 41L, 1L, null, null },
                    { 42L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5932), 0L, null, null, false, 42L, 1L, null, null },
                    { 43L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5933), 0L, null, null, false, 43L, 1L, null, null },
                    { 44L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5934), 0L, null, null, false, 44L, 1L, null, null },
                    { 45L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5942), 0L, null, null, false, 45L, 1L, null, null },
                    { 46L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5943), 0L, null, null, false, 46L, 1L, null, null },
                    { 47L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5944), 0L, null, null, false, 47L, 1L, null, null },
                    { 48L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5945), 0L, null, null, false, 48L, 1L, null, null },
                    { 49L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5946), 0L, null, null, false, 49L, 1L, null, null },
                    { 50L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5947), 0L, null, null, false, 50L, 1L, null, null },
                    { 51L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5948), 0L, null, null, false, 51L, 1L, null, null },
                    { 52L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5949), 0L, null, null, false, 52L, 1L, null, null },
                    { 53L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5950), 0L, null, null, false, 53L, 1L, null, null },
                    { 54L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5951), 0L, null, null, false, 54L, 1L, null, null },
                    { 55L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5952), 0L, null, null, false, 55L, 1L, null, null },
                    { 56L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5953), 0L, null, null, false, 56L, 1L, null, null },
                    { 57L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5954), 0L, null, null, false, 57L, 1L, null, null },
                    { 58L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5955), 0L, null, null, false, 58L, 1L, null, null },
                    { 59L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5956), 0L, null, null, false, 59L, 1L, null, null },
                    { 60L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5958), 0L, null, null, false, 60L, 1L, null, null },
                    { 61L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5959), 0L, null, null, false, 61L, 1L, null, null },
                    { 62L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5960), 0L, null, null, false, 62L, 1L, null, null },
                    { 63L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5961), 0L, null, null, false, 63L, 1L, null, null },
                    { 64L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5962), 0L, null, null, false, 64L, 1L, null, null },
                    { 65L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5963), 0L, null, null, false, 65L, 1L, null, null },
                    { 66L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5964), 0L, null, null, false, 66L, 1L, null, null },
                    { 67L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5965), 0L, null, null, false, 67L, 1L, null, null },
                    { 68L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5966), 0L, null, null, false, 68L, 1L, null, null },
                    { 69L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5967), 0L, null, null, false, 69L, 1L, null, null },
                    { 70L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5968), 0L, null, null, false, 70L, 1L, null, null },
                    { 71L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5969), 0L, null, null, false, 71L, 1L, null, null },
                    { 72L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5970), 0L, null, null, false, 72L, 1L, null, null },
                    { 73L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5971), 0L, null, null, false, 73L, 1L, null, null },
                    { 74L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5972), 0L, null, null, false, 74L, 1L, null, null },
                    { 75L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5973), 0L, null, null, false, 75L, 1L, null, null },
                    { 76L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5974), 0L, null, null, false, 76L, 1L, null, null },
                    { 77L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5975), 0L, null, null, false, 77L, 1L, null, null },
                    { 78L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5976), 0L, null, null, false, 78L, 1L, null, null },
                    { 79L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5977), 0L, null, null, false, 79L, 1L, null, null },
                    { 80L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5980), 0L, null, null, false, 80L, 1L, null, null },
                    { 81L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5981), 0L, null, null, false, 81L, 1L, null, null },
                    { 82L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5982), 0L, null, null, false, 82L, 1L, null, null },
                    { 83L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5982), 0L, null, null, false, 83L, 1L, null, null },
                    { 84L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5983), 0L, null, null, false, 84L, 1L, null, null },
                    { 86L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5984), 0L, null, null, false, 86L, 1L, null, null },
                    { 87L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5985), 0L, null, null, false, 87L, 1L, null, null },
                    { 88L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5986), 0L, null, null, false, 88L, 1L, null, null },
                    { 89L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5987), 0L, null, null, false, 89L, 1L, null, null },
                    { 90L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5988), 0L, null, null, false, 90L, 1L, null, null },
                    { 91L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5989), 0L, null, null, false, 91L, 1L, null, null },
                    { 92L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5990), 0L, null, null, false, 92L, 1L, null, null },
                    { 93L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5991), 0L, null, null, false, 93L, 1L, null, null },
                    { 94L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5992), 0L, null, null, false, 94L, 1L, null, null },
                    { 95L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5993), 0L, null, null, false, 95L, 1L, null, null },
                    { 96L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5994), 0L, null, null, false, 96L, 1L, null, null },
                    { 97L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5995), 0L, null, null, false, 97L, 1L, null, null },
                    { 98L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5996), 0L, null, null, false, 98L, 1L, null, null },
                    { 99L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5997), 0L, null, null, false, 99L, 1L, null, null },
                    { 100L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5998), 0L, null, null, false, 100L, 1L, null, null },
                    { 101L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(5999), 0L, null, null, false, 101L, 1L, null, null },
                    { 102L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(6000), 0L, null, null, false, 102L, 1L, null, null },
                    { 103L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(6006), 0L, null, null, false, 103L, 1L, null, null },
                    { 104L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(6007), 0L, null, null, false, 104L, 1L, null, null },
                    { 105L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(6008), 0L, null, null, false, 105L, 1L, null, null },
                    { 106L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(6009), 0L, null, null, false, 106L, 1L, null, null },
                    { 107L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(6011), 0L, null, null, false, 107L, 1L, null, null },
                    { 108L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(6012), 0L, null, null, false, 108L, 1L, null, null },
                    { 109L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(6013), 0L, null, null, false, 109L, 1L, null, null },
                    { 110L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(6014), 0L, null, null, false, 110L, 1L, null, null },
                    { 111L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(6015), 0L, null, null, false, 111L, 1L, null, null },
                    { 112L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(6016), 0L, null, null, false, 112L, 1L, null, null },
                    { 113L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(6017), 0L, null, null, false, 113L, 1L, null, null },
                    { 114L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(6018), 0L, null, null, false, 114L, 1L, null, null },
                    { 115L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(6019), 0L, null, null, false, 115L, 1L, null, null },
                    { 116L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(6020), 0L, null, null, false, 116L, 1L, null, null },
                    { 117L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(6020), 0L, null, null, false, 117L, 1L, null, null },
                    { 118L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(6021), 0L, null, null, false, 118L, 1L, null, null },
                    { 119L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(6022), 0L, null, null, false, 119L, 1L, null, null },
                    { 120L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(6023), 0L, null, null, false, 120L, 1L, null, null },
                    { 121L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(6024), 0L, null, null, false, 121L, 1L, null, null },
                    { 122L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(6025), 0L, null, null, false, 122L, 1L, null, null },
                    { 123L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(6026), 0L, null, null, false, 123L, 1L, null, null },
                    { 124L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(6027), 0L, null, null, false, 124L, 1L, null, null },
                    { 125L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(6028), 0L, null, null, false, 125L, 1L, null, null },
                    { 126L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(6029), 0L, null, null, false, 126L, 1L, null, null },
                    { 127L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(6030), 0L, null, null, false, 127L, 1L, null, null },
                    { 128L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(6031), 0L, null, null, false, 128L, 1L, null, null },
                    { 129L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(6032), 0L, null, null, false, 129L, 1L, null, null },
                    { 130L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(6033), 0L, null, null, false, 130L, 1L, null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DateOfBirth", "DeletedAt", "DeletedByUserId", "Email", "FirstName", "IsDeleted", "LastName", "Password", "Phone", "RoleId", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 5, 15, 7, 58, 26, 291, DateTimeKind.Utc).AddTicks(4732), 0L, new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Email1@gmail.com", "FirstName1", false, "LastName1", "$2a$12$ztRzpwiSNoy7THNO6ZmSJu/aHpfJwFfynndGlRmjGlKMxs2wYkmdW", "+998991111111", 1L, null, null },
                    { 2L, new DateTime(2024, 5, 15, 7, 58, 26, 598, DateTimeKind.Utc).AddTicks(4892), 0L, new DateTime(2002, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Email2@gmail.com", "FirstName2", false, "LastName2", "$2a$12$ViCHHEzIw5JY46RPfhupSew1lJjhb/Ek4KhtsNNXCCRySvgzfmNti", "+998992222222", 2L, null, null },
                    { 3L, new DateTime(2024, 5, 15, 7, 58, 26, 986, DateTimeKind.Utc).AddTicks(6510), 0L, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Email3@gmail.com", "FirstName3", false, "LastName3", "$2a$12$0bdRqrfNR7m/t1gaw7klze/h1SSgDYoaU7ToUOWQs/sQMnx3qizPe", "+998993333333", 3L, null, null }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "About", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "DetailId", "IsDeleted", "PictureId", "Profession", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, "Description", new DateTime(2024, 5, 15, 7, 58, 25, 973, DateTimeKind.Utc).AddTicks(5816), 0L, null, null, 3L, false, 2L, "Software Developer", null, null });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "DetailId", "IsDeleted", "PictureId", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(8220), 0L, null, null, 2L, false, 1L, null, null });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "CountOfLessons", "CourseCategoryId", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "Description", "Duration", "FileId", "InstructorId", "IsDeleted", "LanguageId", "Level", "Name", "Price", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, 1L, 150, null, new DateTime(2024, 5, 15, 7, 58, 25, 972, DateTimeKind.Utc).AddTicks(7289), 0L, null, null, "Course Description", 7, 1L, 1L, false, 1L, 2, ".NET", 2200000.00m, null, null });

            migrationBuilder.InsertData(
                table: "InstructorComments",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "InstructorId", "IsDeleted", "StudentId", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, null, new DateTime(2024, 5, 15, 7, 58, 25, 973, DateTimeKind.Utc).AddTicks(3597), 0L, null, null, 1L, false, 1L, null, null });

            migrationBuilder.InsertData(
                table: "InstructorStars",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "InstructorId", "IsDeleted", "Stars", "StudentId", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, new DateTime(2024, 5, 15, 7, 58, 25, 973, DateTimeKind.Utc).AddTicks(8128), 0L, null, null, 1L, false, (byte)5, 1L, null, null });

            migrationBuilder.InsertData(
                table: "CourseComments",
                columns: new[] { "Id", "Content", "CourseId", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "StudentId", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, "Course Comment", 1L, new DateTime(2024, 5, 15, 7, 58, 25, 971, DateTimeKind.Utc).AddTicks(3470), 0L, null, null, false, 1L, null, null });

            migrationBuilder.InsertData(
                table: "CourseModules",
                columns: new[] { "Id", "CourseId", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Name", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, 1L, new DateTime(2024, 5, 15, 7, 58, 25, 972, DateTimeKind.Utc).AddTicks(8600), 0L, null, null, false, "Module1", null, null });

            migrationBuilder.InsertData(
                table: "CourseStar",
                columns: new[] { "Id", "CourseId", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "Stars", "StudentId", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, 1L, new DateTime(2024, 5, 15, 7, 58, 25, 973, DateTimeKind.Utc).AddTicks(899), 0L, null, null, false, (byte)5, 1L, null, null });

            migrationBuilder.InsertData(
                table: "StudentCourses",
                columns: new[] { "Id", "CourseId", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "StudentId", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, 1L, new DateTime(2024, 5, 15, 7, 58, 25, 977, DateTimeKind.Utc).AddTicks(444), 0L, null, null, false, 1L, null, null });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "Description", "FileId", "IsDeleted", "ModuleId", "Title", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(4203), 0L, null, null, "Lesson Description", 2L, false, 1L, "Lesson1", null, null });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "FileId", "IsDeleted", "ModuleId", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, "Content", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(9735), 0L, null, null, 2L, false, 1L, null, null });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "ModuleId", "Name", "QuestionCount", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, new DateTime(2024, 5, 15, 7, 58, 25, 975, DateTimeKind.Utc).AddTicks(4359), 0L, null, null, false, 1L, "Quiz1", 5, null, null });

            migrationBuilder.InsertData(
                table: "LessonComments",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "LessonId", "ParentId", "UpdatedAt", "UpdatedByUserId", "UserId" },
                values: new object[] { 1L, "Lesson Comment", new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(2013), 0L, null, null, false, 1L, null, null, null, 2L });

            migrationBuilder.InsertData(
                table: "QuestionOptions",
                columns: new[] { "Id", "Content", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsCorrect", "IsDeleted", "QuestionId", "UpdatedAt", "UpdatedByUserId" },
                values: new object[,]
                {
                    { 1L, "asd", new DateTime(2024, 5, 15, 7, 58, 25, 975, DateTimeKind.Utc).AddTicks(918), 0L, null, null, true, false, 1L, null, null },
                    { 2L, "dsd", new DateTime(2024, 5, 15, 7, 58, 25, 975, DateTimeKind.Utc).AddTicks(921), 0L, null, null, false, false, 1L, null, null },
                    { 3L, "bdb", new DateTime(2024, 5, 15, 7, 58, 25, 975, DateTimeKind.Utc).AddTicks(922), 0L, null, null, false, false, 1L, null, null },
                    { 4L, "waw", new DateTime(2024, 5, 15, 7, 58, 25, 975, DateTimeKind.Utc).AddTicks(923), 0L, null, null, false, false, 1L, null, null }
                });

            migrationBuilder.InsertData(
                table: "QuizApplications",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "EndTime", "IsDeleted", "QuizId", "StartTime", "StudentId", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, new DateTime(2024, 5, 15, 7, 58, 25, 975, DateTimeKind.Utc).AddTicks(3245), 0L, null, null, new DateTime(2024, 11, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), false, 1L, new DateTime(2024, 10, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), 1L, null, null });

            migrationBuilder.InsertData(
                table: "QuizQuestions",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "QuestionId", "QuizId", "QuizId1", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, new DateTime(2024, 5, 15, 7, 58, 25, 976, DateTimeKind.Utc).AddTicks(3730), 0L, null, null, false, 1L, 1L, null, null, null });

            migrationBuilder.InsertData(
                table: "QuestionAnswers",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "DeletedAt", "DeletedByUserId", "IsDeleted", "OptionId", "QuestionId", "QuizId", "StudentId", "UpdatedAt", "UpdatedByUserId" },
                values: new object[] { 1L, new DateTime(2024, 5, 15, 7, 58, 25, 974, DateTimeKind.Utc).AddTicks(7560), 0L, null, null, false, 1L, 1L, 1L, 1L, null, null });

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
                table: "CourseStar",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStars_StudentId",
                table: "CourseStar",
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
                name: "CourseStar");

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
