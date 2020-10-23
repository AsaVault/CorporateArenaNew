using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CorporateArena.Presentation.Core.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 150, nullable: true),
                    AuthorID = table.Column<int>(nullable: false),
                    isApproved = table.Column<bool>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    ArticleLikesCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BrainTeasers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Riddle = table.Column<string>(nullable: true),
                    UserCreated = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    CorrectAnswer = table.Column<string>(nullable: true),
                    Gift = table.Column<string>(nullable: true),
                    isApproved = table.Column<bool>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrainTeasers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RolePrivileges",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleID = table.Column<int>(nullable: false),
                    PrivilegeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePrivileges", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    UserCreated = table.Column<int>(nullable: true),
                    UserModified = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TrafficUpdates",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UserCreated = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrafficUpdates", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    UserCreated = table.Column<int>(nullable: true),
                    UserModified = table.Column<int>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    RoleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vacancies",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    JobDescription = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    UserCreated = table.Column<int>(nullable: false),
                    Mode = table.Column<string>(nullable: true),
                    Industry = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ArticleComments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 150, nullable: true),
                    Content = table.Column<string>(nullable: true),
                    ArticleID = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    UserCreated = table.Column<int>(nullable: false),
                    CommentLikesCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleComments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ArticleComments_Articles_ArticleID",
                        column: x => x.ArticleID,
                        principalTable: "Articles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleLikes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCreated = table.Column<int>(nullable: false),
                    ArticleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleLikes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ArticleLikes_Articles_ArticleID",
                        column: x => x.ArticleID,
                        principalTable: "Articles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BrainTeaserAnswers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    UserCreated = table.Column<int>(nullable: false),
                    Answer = table.Column<string>(nullable: true),
                    isApproved = table.Column<bool>(nullable: false),
                    BrainTeaserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrainTeaserAnswers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BrainTeaserAnswers_BrainTeasers_BrainTeaserID",
                        column: x => x.BrainTeaserID,
                        principalTable: "BrainTeasers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BrainTeaserWinners",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    UserCreated = table.Column<int>(nullable: false),
                    Answer = table.Column<string>(nullable: true),
                    isDisplayed = table.Column<bool>(nullable: false),
                    BrainTeaserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrainTeaserWinners", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BrainTeaserWinners_BrainTeasers_BrainTeaserID",
                        column: x => x.BrainTeaserID,
                        principalTable: "BrainTeasers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    UserCreated = table.Column<int>(nullable: true),
                    UserModified = table.Column<int>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    OtherName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    RoleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AppUsers_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Privileges",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    Entity = table.Column<string>(nullable: true),
                    RoleID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privileges", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Privileges_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrafficComments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCreated = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    TrafficUpdateID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrafficComments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TrafficComments_TrafficUpdates_TrafficUpdateID",
                        column: x => x.TrafficUpdateID,
                        principalTable: "TrafficUpdates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentLikes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCreated = table.Column<int>(nullable: false),
                    ArticleID = table.Column<int>(nullable: false),
                    CommentID = table.Column<int>(nullable: false),
                    ArticleCommentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentLikes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CommentLikes_ArticleComments_ArticleCommentID",
                        column: x => x.ArticleCommentID,
                        principalTable: "ArticleComments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Privileges",
                columns: new[] { "ID", "Action", "DisplayName", "Entity", "Name", "RoleID" },
                values: new object[,]
                {
                    { 1, "Create", "Create User", "User", "CreateUser", null },
                    { 30, "Delete", "Delete TrafficUpdate", "TrafficUpdate", "DeleteTrafficUpdate", null },
                    { 29, "Update", "Update TrafficUpdate", "TrafficUpdate", "UpdateTrafficUpdate", null },
                    { 28, "Read", "Read TrafficUpdate", "TrafficUpdate", "ReadTrafficUpdate", null },
                    { 27, "Create", "Create TrafficUpdate", "TrafficUpdate", "CreateTrafficUpdate ", null },
                    { 26, "Like", "Like ArticleComment", "ArticleComment", "LikeArticleComment", null },
                    { 25, "Create", "Create ArticleComment", "ArticleComment", "CreateArticleComment", null },
                    { 23, "Comment", "Comment on Article", "Article", "CommentArticle", null },
                    { 22, "Delete", "Delete Article", "Article", "DeleteArticle", null },
                    { 21, "Update", "Update Article", "Article", "UpdateArticle", null },
                    { 20, "Read", "Read Article", "Article", "ReadArticle", null },
                    { 19, "Create", "Create Article", "Article", "CreateArticle", null },
                    { 18, "Delete", "Delete Vacancy", "Vacancy", "DeleteVacancy", null },
                    { 17, "Update", "Update Vacancy", "Vacancy", "UpdateVacancy", null },
                    { 16, "Read", "Read Vacancy", "Vacancy", "ReadVacancy", null },
                    { 24, "Like", "Like Article", "Article", "LikeArticle", null },
                    { 14, "Delete", "Delete BrainTeaser", "BrainTeaser", "DeleteBrainTeaser", null },
                    { 15, "Create", "Create Vacancy", "Vacancy", "CreateVacancy", null },
                    { 2, "Read", "Read User", "User", "ReadUser", null },
                    { 3, "Update", "Update User", "User", "UpdateUser", null },
                    { 4, "Delete", "Delete User", "User", "DeleteUser", null },
                    { 6, "Create", "Create Role", "Role", "CreateRole", null },
                    { 7, "Read", "Read Role", "Role", "ReadRole", null },
                    { 5, "Create", "Create UserRole", "UserRole", "CreateUserRole", null },
                    { 8, "Update", "Update Role", "Role", "UpdateRole", null },
                    { 9, "Delete", "Delete Role", "Role", "DeleteRole", null },
                    { 10, "Create", "Create RolePrivilege", "RolePrivilege", "CreateRolePrivilege", null },
                    { 11, "Create", "Create BrainTeaser", "BrainTeaser", "CreateBrainTeaser", null },
                    { 12, "Read", "Read BrainTeaser", "BrainTeaser", "ReadBrainTeaser", null },
                    { 13, "Update", "Update BrainTeaser", "BrainTeaser", "UpdateBrainTeaser", null }
                });

            migrationBuilder.InsertData(
                table: "RolePrivileges",
                columns: new[] { "ID", "PrivilegeID", "RoleID" },
                values: new object[,]
                {
                    { 26, 20, 1 },
                    { 21, 15, 1 },
                    { 22, 16, 1 },
                    { 23, 17, 1 },
                    { 24, 18, 1 },
                    { 25, 19, 1 },
                    { 20, 14, 1 },
                    { 27, 21, 1 },
                    { 34, 28, 1 },
                    { 29, 23, 1 },
                    { 30, 24, 1 },
                    { 31, 25, 1 },
                    { 32, 26, 1 },
                    { 33, 27, 1 },
                    { 35, 29, 1 },
                    { 19, 13, 1 },
                    { 28, 22, 1 },
                    { 18, 12, 1 },
                    { 3, 12, 2 },
                    { 16, 10, 1 },
                    { 1, 2, 2 },
                    { 2, 7, 2 },
                    { 36, 30, 1 },
                    { 4, 16, 2 },
                    { 5, 20, 2 },
                    { 6, 28, 2 },
                    { 17, 11, 1 },
                    { 7, 1, 1 },
                    { 9, 3, 1 },
                    { 10, 4, 1 },
                    { 11, 5, 1 },
                    { 12, 6, 1 },
                    { 13, 7, 1 },
                    { 14, 8, 1 },
                    { 15, 9, 1 },
                    { 8, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "DateCreated", "DateModified", "DisplayName", "Name", "UserCreated", "UserModified" },
                values: new object[,]
                {
                    { 2, new DateTime(2020, 10, 8, 21, 1, 36, 630, DateTimeKind.Local).AddTicks(1652), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Basic", "Basic", 1, null },
                    { 1, new DateTime(2020, 10, 8, 21, 1, 36, 627, DateTimeKind.Local).AddTicks(5195), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SuperUser", "SuperUser", 1, null }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "ID", "DateCreated", "DateModified", "RoleID", "UserCreated", "UserID", "UserModified" },
                values: new object[] { 1, new DateTime(2020, 10, 8, 21, 1, 36, 631, DateTimeKind.Local).AddTicks(6955), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 1, null });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "ID", "DateCreated", "DateModified", "Email", "FirstName", "IsActive", "IsDeleted", "LastName", "OtherName", "Password", "PhoneNumber", "RoleID", "Token", "UserCreated", "UserModified", "UserName" },
                values: new object[] { 1, new DateTime(2020, 10, 8, 21, 1, 36, 630, DateTimeKind.Local).AddTicks(8291), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tkolawole@Inspirecoders.com", "System", true, null, "User", null, "Password@1", null, 1, null, null, null, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_RoleID",
                table: "AppUsers",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleComments_ArticleID",
                table: "ArticleComments",
                column: "ArticleID");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleLikes_ArticleID",
                table: "ArticleLikes",
                column: "ArticleID");

            migrationBuilder.CreateIndex(
                name: "IX_BrainTeaserAnswers_BrainTeaserID",
                table: "BrainTeaserAnswers",
                column: "BrainTeaserID");

            migrationBuilder.CreateIndex(
                name: "IX_BrainTeaserWinners_BrainTeaserID",
                table: "BrainTeaserWinners",
                column: "BrainTeaserID");

            migrationBuilder.CreateIndex(
                name: "IX_CommentLikes_ArticleCommentID",
                table: "CommentLikes",
                column: "ArticleCommentID");

            migrationBuilder.CreateIndex(
                name: "IX_Privileges_RoleID",
                table: "Privileges",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_TrafficComments_TrafficUpdateID",
                table: "TrafficComments",
                column: "TrafficUpdateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "ArticleLikes");

            migrationBuilder.DropTable(
                name: "BrainTeaserAnswers");

            migrationBuilder.DropTable(
                name: "BrainTeaserWinners");

            migrationBuilder.DropTable(
                name: "CommentLikes");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Privileges");

            migrationBuilder.DropTable(
                name: "RolePrivileges");

            migrationBuilder.DropTable(
                name: "TrafficComments");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Vacancies");

            migrationBuilder.DropTable(
                name: "BrainTeasers");

            migrationBuilder.DropTable(
                name: "ArticleComments");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "TrafficUpdates");

            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
