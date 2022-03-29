using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Project_220322.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerRating_Products_ProductId",
                table: "CustomerRating");

            migrationBuilder.DropForeignKey(
                name: "FK_Firm_User_Id",
                table: "Firm");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_User_Id",
                table: "Member");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderdetail_CustomerRating_RateId",
                table: "Orderdetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderdetail_Orders_OrderId",
                table: "Orderdetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderdetail_Products_ProductId",
                table: "Orderdetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_User_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPicture_Products_ProductId",
                table: "ProductPicture");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPicture",
                table: "ProductPicture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orderdetail",
                table: "Orderdetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Member",
                table: "Member");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Firm",
                table: "Firm");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerRating",
                table: "CustomerRating");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "ProductPicture",
                newName: "ProductPictures");

            migrationBuilder.RenameTable(
                name: "Orderdetail",
                newName: "Orderdetails");

            migrationBuilder.RenameTable(
                name: "Member",
                newName: "Members");

            migrationBuilder.RenameTable(
                name: "Firm",
                newName: "Firms");

            migrationBuilder.RenameTable(
                name: "CustomerRating",
                newName: "CustomerRatings");

            migrationBuilder.RenameIndex(
                name: "IX_User_RoleId",
                table: "Users",
                newName: "IX_Users_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPicture_ProductId",
                table: "ProductPictures",
                newName: "IX_ProductPictures_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Orderdetail_RateId",
                table: "Orderdetails",
                newName: "IX_Orderdetails_RateId");

            migrationBuilder.RenameIndex(
                name: "IX_Orderdetail_ProductId",
                table: "Orderdetails",
                newName: "IX_Orderdetails_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerRating_ProductId",
                table: "CustomerRatings",
                newName: "IX_CustomerRatings_ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPictures",
                table: "ProductPictures",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orderdetails",
                table: "Orderdetails",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Firms",
                table: "Firms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerRatings",
                table: "CustomerRatings",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreateDate", "DepartureTime", "Description", "DiscountPersent", "Name", "Notes", "OriginalPrice", "ProductStatus", "Region", "TravelDays", "TripType", "UpdateTime" },
                values: new object[,]
                {
                    { new Guid("9474a00b-a7f8-4e4e-9d8d-51b30971324a"), new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "天龍國", null, "台北一日遊", null, 999m, 0, 0, null, 2, new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c096d10e-7df6-4d3b-a38e-2a93b570b68b"), new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "貢丸好吃", null, "新竹半日遊", null, 888m, 2, 1, null, 2, new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("39bc7b5b-fc3b-4cf9-a220-41bf40ba2619"), new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "出國玩", null, "桃園一日遊", null, 9999m, 1, 1, null, 2, new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("29fa527c-82b2-442e-b8d2-814efc3720e4"), new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "請你吃慶記", null, "台中一日遊", null, 6666m, 1, 2, null, 2, new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9185d0ff-db0c-404d-8d03-e893c7a8642a"), new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "住花蓮王家", null, "花蓮一日遊", null, 7777m, 1, 5, null, 2, new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7d2edc71-28ef-48e5-86c7-217999da3de1"), new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "潛水愛好者的天堂", null, "綠島3天2夜", null, 11111m, 1, 6, null, 2, new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("050a111f-4df0-4da1-9579-2b1a1cce0c60"), new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "來去看花火節", null, "澎湖5天4夜", null, 15555m, 1, 6, null, 2, new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2bb342b9-e417-4e13-b32c-af5460a263d5"), new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "墾丁大街吃飽飽", null, "墾丁3天2夜", null, 8888m, 0, 4, null, 2, new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e91d0aaf-6e2f-44ed-be31-acc299131d22"), new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "來吃米粉湯", null, "宜蘭2天1夜", null, 1122m, 0, 5, null, 2, new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("69ded3c2-0c2f-4806-b25e-3463e41988d6"), new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "高雄發大財", null, "高雄2天1夜", null, 8888m, 2, 4, null, 2, new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerRatings_Products_ProductId",
                table: "CustomerRatings",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Firms_Users_Id",
                table: "Firms",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Users_Id",
                table: "Members",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orderdetails_CustomerRatings_RateId",
                table: "Orderdetails",
                column: "RateId",
                principalTable: "CustomerRatings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orderdetails_Orders_OrderId",
                table: "Orderdetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orderdetails_Products_ProductId",
                table: "Orderdetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPictures_Products_ProductId",
                table: "ProductPictures",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerRatings_Products_ProductId",
                table: "CustomerRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_Firms_Users_Id",
                table: "Firms");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Users_Id",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderdetails_CustomerRatings_RateId",
                table: "Orderdetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderdetails_Orders_OrderId",
                table: "Orderdetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderdetails_Products_ProductId",
                table: "Orderdetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPictures_Products_ProductId",
                table: "ProductPictures");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPictures",
                table: "ProductPictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orderdetails",
                table: "Orderdetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Firms",
                table: "Firms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerRatings",
                table: "CustomerRatings");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("050a111f-4df0-4da1-9579-2b1a1cce0c60"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("29fa527c-82b2-442e-b8d2-814efc3720e4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2bb342b9-e417-4e13-b32c-af5460a263d5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("39bc7b5b-fc3b-4cf9-a220-41bf40ba2619"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("69ded3c2-0c2f-4806-b25e-3463e41988d6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7d2edc71-28ef-48e5-86c7-217999da3de1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9185d0ff-db0c-404d-8d03-e893c7a8642a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9474a00b-a7f8-4e4e-9d8d-51b30971324a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c096d10e-7df6-4d3b-a38e-2a93b570b68b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e91d0aaf-6e2f-44ed-be31-acc299131d22"));

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "ProductPictures",
                newName: "ProductPicture");

            migrationBuilder.RenameTable(
                name: "Orderdetails",
                newName: "Orderdetail");

            migrationBuilder.RenameTable(
                name: "Members",
                newName: "Member");

            migrationBuilder.RenameTable(
                name: "Firms",
                newName: "Firm");

            migrationBuilder.RenameTable(
                name: "CustomerRatings",
                newName: "CustomerRating");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleId",
                table: "User",
                newName: "IX_User_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPictures_ProductId",
                table: "ProductPicture",
                newName: "IX_ProductPicture_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Orderdetails_RateId",
                table: "Orderdetail",
                newName: "IX_Orderdetail_RateId");

            migrationBuilder.RenameIndex(
                name: "IX_Orderdetails_ProductId",
                table: "Orderdetail",
                newName: "IX_Orderdetail_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerRatings_ProductId",
                table: "CustomerRating",
                newName: "IX_CustomerRating_ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Role",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPicture",
                table: "ProductPicture",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orderdetail",
                table: "Orderdetail",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Member",
                table: "Member",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Firm",
                table: "Firm",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerRating",
                table: "CustomerRating",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerRating_Products_ProductId",
                table: "CustomerRating",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Firm_User_Id",
                table: "Firm",
                column: "Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Member_User_Id",
                table: "Member",
                column: "Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orderdetail_CustomerRating_RateId",
                table: "Orderdetail",
                column: "RateId",
                principalTable: "CustomerRating",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orderdetail_Orders_OrderId",
                table: "Orderdetail",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orderdetail_Products_ProductId",
                table: "Orderdetail",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_User_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPicture_Products_ProductId",
                table: "ProductPicture",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
