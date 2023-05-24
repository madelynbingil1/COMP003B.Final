using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogPage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    CommentId = table.Column<int>(type: "INTEGER", nullable: false),
                    PostId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    PostDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostId);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "BlogPageCategory",
                columns: table => new
                {
                    BlogPagesId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoriesCategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPageCategory", x => new { x.BlogPagesId, x.CategoriesCategoryId });
                    table.ForeignKey(
                        name: "FK_BlogPageCategory_BlogPage_BlogPagesId",
                        column: x => x.BlogPagesId,
                        principalTable: "BlogPage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogPageCategory_Category_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogPageComment",
                columns: table => new
                {
                    BlogPagesId = table.Column<int>(type: "INTEGER", nullable: false),
                    CommentsCommentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPageComment", x => new { x.BlogPagesId, x.CommentsCommentId });
                    table.ForeignKey(
                        name: "FK_BlogPageComment_BlogPage_BlogPagesId",
                        column: x => x.BlogPagesId,
                        principalTable: "BlogPage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogPageComment_Comment_CommentsCommentId",
                        column: x => x.CommentsCommentId,
                        principalTable: "Comment",
                        principalColumn: "CommentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogPagePost",
                columns: table => new
                {
                    BlogPagesId = table.Column<int>(type: "INTEGER", nullable: false),
                    PostsPostId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPagePost", x => new { x.BlogPagesId, x.PostsPostId });
                    table.ForeignKey(
                        name: "FK_BlogPagePost_BlogPage_BlogPagesId",
                        column: x => x.BlogPagesId,
                        principalTable: "BlogPage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogPagePost_Post_PostsPostId",
                        column: x => x.PostsPostId,
                        principalTable: "Post",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogPageTag",
                columns: table => new
                {
                    BlogPagesId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagsTagId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPageTag", x => new { x.BlogPagesId, x.TagsTagId });
                    table.ForeignKey(
                        name: "FK_BlogPageTag_BlogPage_BlogPagesId",
                        column: x => x.BlogPagesId,
                        principalTable: "BlogPage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogPageTag_Tag_TagsTagId",
                        column: x => x.TagsTagId,
                        principalTable: "Tag",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogPageUser",
                columns: table => new
                {
                    BlogPagesId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersUserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPageUser", x => new { x.BlogPagesId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_BlogPageUser_BlogPage_BlogPagesId",
                        column: x => x.BlogPagesId,
                        principalTable: "BlogPage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogPageUser_User_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPageCategory_CategoriesCategoryId",
                table: "BlogPageCategory",
                column: "CategoriesCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPageComment_CommentsCommentId",
                table: "BlogPageComment",
                column: "CommentsCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPagePost_PostsPostId",
                table: "BlogPagePost",
                column: "PostsPostId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPageTag_TagsTagId",
                table: "BlogPageTag",
                column: "TagsTagId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPageUser_UsersUserId",
                table: "BlogPageUser",
                column: "UsersUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPageCategory");

            migrationBuilder.DropTable(
                name: "BlogPageComment");

            migrationBuilder.DropTable(
                name: "BlogPagePost");

            migrationBuilder.DropTable(
                name: "BlogPageTag");

            migrationBuilder.DropTable(
                name: "BlogPageUser");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "BlogPage");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
