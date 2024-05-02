using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arcana.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangedPermissionEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Asset_AssetId",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Asset_AssetId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPermissions_Users_UserId",
                table: "UserPermissions");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserPermissions",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPermissions_UserId",
                table: "UserPermissions",
                newName: "IX_UserPermissions_RoleId");

            migrationBuilder.RenameColumn(
                name: "AssetId",
                table: "Students",
                newName: "PictureId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_AssetId",
                table: "Students",
                newName: "IX_Students_PictureId");

            migrationBuilder.RenameColumn(
                name: "Method",
                table: "Permissions",
                newName: "Action");

            migrationBuilder.RenameColumn(
                name: "AssetId",
                table: "Instructors",
                newName: "PictureId");

            migrationBuilder.RenameIndex(
                name: "IX_Instructors_AssetId",
                table: "Instructors",
                newName: "IX_Instructors_PictureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Asset_PictureId",
                table: "Instructors",
                column: "PictureId",
                principalTable: "Asset",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Asset_PictureId",
                table: "Students",
                column: "PictureId",
                principalTable: "Asset",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPermissions_Roles_RoleId",
                table: "UserPermissions",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Asset_PictureId",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Asset_PictureId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPermissions_Roles_RoleId",
                table: "UserPermissions");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "UserPermissions",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserPermissions_RoleId",
                table: "UserPermissions",
                newName: "IX_UserPermissions_UserId");

            migrationBuilder.RenameColumn(
                name: "PictureId",
                table: "Students",
                newName: "AssetId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_PictureId",
                table: "Students",
                newName: "IX_Students_AssetId");

            migrationBuilder.RenameColumn(
                name: "Action",
                table: "Permissions",
                newName: "Method");

            migrationBuilder.RenameColumn(
                name: "PictureId",
                table: "Instructors",
                newName: "AssetId");

            migrationBuilder.RenameIndex(
                name: "IX_Instructors_PictureId",
                table: "Instructors",
                newName: "IX_Instructors_AssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Asset_AssetId",
                table: "Instructors",
                column: "AssetId",
                principalTable: "Asset",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Asset_AssetId",
                table: "Students",
                column: "AssetId",
                principalTable: "Asset",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPermissions_Users_UserId",
                table: "UserPermissions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
