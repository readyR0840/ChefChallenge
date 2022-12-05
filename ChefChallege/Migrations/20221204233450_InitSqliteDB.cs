using Microsoft.EntityFrameworkCore.Migrations;

namespace ChefChallege.Migrations
{
    public partial class InitSqliteDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    Experience = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DesertRecipe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Ingredients = table.Column<string>(nullable: false),
                    Amounts = table.Column<string>(nullable: false),
                    Instructions = table.Column<string>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesertRecipe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DesertRecipe_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DinnerRecipe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Ingredients = table.Column<string>(nullable: false),
                    Amounts = table.Column<string>(nullable: false),
                    Instructions = table.Column<string>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DinnerRecipe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DinnerRecipe_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SoupRecipe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Ingredients = table.Column<string>(nullable: false),
                    Amounts = table.Column<string>(nullable: false),
                    Instructions = table.Column<string>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoupRecipe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoupRecipe_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Amount = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    DesertRecipeId = table.Column<int>(nullable: true),
                    DinnerRecipeId = table.Column<int>(nullable: true),
                    SoupRecipeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredient_DesertRecipe_DesertRecipeId",
                        column: x => x.DesertRecipeId,
                        principalTable: "DesertRecipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ingredient_DinnerRecipe_DinnerRecipeId",
                        column: x => x.DinnerRecipeId,
                        principalTable: "DinnerRecipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ingredient_SoupRecipe_SoupRecipeId",
                        column: x => x.SoupRecipeId,
                        principalTable: "SoupRecipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DesertRecipe_UserId",
                table: "DesertRecipe",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DinnerRecipe_UserId",
                table: "DinnerRecipe",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_DesertRecipeId",
                table: "Ingredient",
                column: "DesertRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_DinnerRecipeId",
                table: "Ingredient",
                column: "DinnerRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_SoupRecipeId",
                table: "Ingredient",
                column: "SoupRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_SoupRecipe_UserId",
                table: "SoupRecipe",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "DesertRecipe");

            migrationBuilder.DropTable(
                name: "DinnerRecipe");

            migrationBuilder.DropTable(
                name: "SoupRecipe");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
