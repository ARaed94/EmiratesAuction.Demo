using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Makes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    TitleAr = table.Column<string>(nullable: true),
                    TitleEn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    TitleAr = table.Column<string>(nullable: true),
                    TitleEn = table.Column<string>(nullable: true),
                    MakeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Makes_MakeId",
                        column: x => x.MakeId,
                        principalTable: "Makes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    TitleAr = table.Column<string>(nullable: true),
                    TitleEn = table.Column<string>(nullable: true),
                    MakeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trims_Makes_MakeId",
                        column: x => x.MakeId,
                        principalTable: "Makes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Auctions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    MakeAr = table.Column<string>(nullable: true),
                    MakeEn = table.Column<string>(nullable: true),
                    MakeId = table.Column<int>(nullable: true),
                    ModelAr = table.Column<string>(nullable: true),
                    ModelEn = table.Column<string>(nullable: true),
                    ModelId = table.Column<int>(nullable: true),
                    MainHeroImageUrl = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    Lot = table.Column<string>(nullable: true),
                    CurrencyAr = table.Column<string>(nullable: true),
                    CurrencyEn = table.Column<string>(nullable: true),
                    CurrentBid = table.Column<double>(nullable: false),
                    Bids = table.Column<int>(nullable: false),
                    TrimAr = table.Column<string>(nullable: true),
                    TrimEn = table.Column<string>(nullable: true),
                    TrimId = table.Column<int>(nullable: true),
                    EndDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auctions_Makes_MakeId",
                        column: x => x.MakeId,
                        principalTable: "Makes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Auctions_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Auctions_Trims_TrimId",
                        column: x => x.TrimId,
                        principalTable: "Trims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuctionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    SharingLink = table.Column<string>(nullable: true),
                    SharingMessageAr = table.Column<string>(nullable: true),
                    SharingMessageEn = table.Column<string>(nullable: true),
                    Mileage = table.Column<decimal>(nullable: false),
                    ImagesCount = table.Column<int>(nullable: false),
                    CarId = table.Column<int>(nullable: false),
                    DescriptionAr = table.Column<string>(nullable: true),
                    DescriptionEn = table.Column<string>(nullable: true),
                    BodyAr = table.Column<string>(nullable: true),
                    BodyEn = table.Column<string>(nullable: true),
                    MinBidIncrement = table.Column<int>(nullable: false),
                    AuctionPriorityId = table.Column<int>(nullable: false),
                    VatPercentage = table.Column<decimal>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Vin = table.Column<string>(nullable: true),
                    AuctionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuctionDetails_Auctions_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "Auctions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Makes",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "LastModifiedOn", "TitleAr", "TitleEn" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 10, 26, 13, 11, 34, 286, DateTimeKind.Local).AddTicks(6688), null, null, "أودي", "Audi" },
                    { 2, new DateTime(2020, 10, 26, 13, 11, 34, 287, DateTimeKind.Local).AddTicks(3447), null, null, "بنتلي", "Bentley" },
                    { 3, new DateTime(2020, 10, 26, 13, 11, 34, 287, DateTimeKind.Local).AddTicks(3469), null, null, "مكلارين", "McLaren" },
                    { 4, new DateTime(2020, 10, 26, 13, 11, 34, 287, DateTimeKind.Local).AddTicks(3473), null, null, "دودج", "Dodge" },
                    { 5, new DateTime(2020, 10, 26, 13, 11, 34, 287, DateTimeKind.Local).AddTicks(3477), null, null, "فيراري", "Ferrari" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "LastModifiedOn", "MakeId", "TitleAr", "TitleEn" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 10, 26, 13, 11, 34, 288, DateTimeKind.Local).AddTicks(5810), null, null, 1, "موديل 1", "Model 1" },
                    { 2, new DateTime(2020, 10, 26, 13, 11, 34, 288, DateTimeKind.Local).AddTicks(6217), null, null, 2, "موديل 2", "Model 2" },
                    { 3, new DateTime(2020, 10, 26, 13, 11, 34, 288, DateTimeKind.Local).AddTicks(6233), null, null, 3, "موديل 3", "Model 3" },
                    { 4, new DateTime(2020, 10, 26, 13, 11, 34, 288, DateTimeKind.Local).AddTicks(6238), null, null, 4, "موديل 4", "Model 4" },
                    { 5, new DateTime(2020, 10, 26, 13, 11, 34, 288, DateTimeKind.Local).AddTicks(6243), null, null, 5, "موديل 5", "Model 5" }
                });

            migrationBuilder.InsertData(
                table: "Trims",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "LastModifiedOn", "MakeId", "TitleAr", "TitleEn" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 10, 26, 13, 11, 34, 288, DateTimeKind.Local).AddTicks(9550), null, null, 1, "نوع 1", "Trim 1" },
                    { 2, new DateTime(2020, 10, 26, 13, 11, 34, 288, DateTimeKind.Local).AddTicks(9944), null, null, 2, "نوع 2", "Trim 2" },
                    { 3, new DateTime(2020, 10, 26, 13, 11, 34, 288, DateTimeKind.Local).AddTicks(9960), null, null, 3, "نوع 3", "Trim 3" },
                    { 4, new DateTime(2020, 10, 26, 13, 11, 34, 288, DateTimeKind.Local).AddTicks(9965), null, null, 4, "نوع 4", "Trim 4" },
                    { 5, new DateTime(2020, 10, 26, 13, 11, 34, 288, DateTimeKind.Local).AddTicks(9970), null, null, 5, "نوع 5", "Trim 5" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuctionDetails_AuctionId",
                table: "AuctionDetails",
                column: "AuctionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_MakeId",
                table: "Auctions",
                column: "MakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_ModelId",
                table: "Auctions",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_TrimId",
                table: "Auctions",
                column: "TrimId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_MakeId",
                table: "Models",
                column: "MakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Trims_MakeId",
                table: "Trims",
                column: "MakeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuctionDetails");

            migrationBuilder.DropTable(
                name: "Auctions");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Trims");

            migrationBuilder.DropTable(
                name: "Makes");
        }
    }
}
