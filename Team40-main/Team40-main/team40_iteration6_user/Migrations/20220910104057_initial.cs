using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace team40_iteration6_user.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttendingStatus",
                columns: table => new
                {
                    AttendanceStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendanceStatusName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attending Status", x => x.AttendanceStatusID);
                });

            migrationBuilder.CreateTable(
                name: "BookingStatus",
                columns: table => new
                {
                    BookingStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingStatus", x => x.BookingStatusID);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Brands__DAD4F05E4DF03281", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryCompany",
                columns: table => new
                {
                    DeliveryCompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryCompanyName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DeliveryCompanyEmail = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ContactPersonName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DeliveryCompanyBaseRate = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryCompany", x => x.DeliveryCompanyID);
                });

            migrationBuilder.CreateTable(
                name: "DiscountStatus",
                columns: table => new
                {
                    DiscountStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountStatus", x => x.DiscountStatusID);
                });

            migrationBuilder.CreateTable(
                name: "DiscountType",
                columns: table => new
                {
                    DiscountTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Percentage = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountType", x => x.DiscountTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    GenderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "varchar(225)", unicode: false, maxLength: 225, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.GenderID);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    InventoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    QuantityOnHand = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.InventoryID);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    OrderStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.OrderStatusID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentStatus",
                columns: table => new
                {
                    StatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentStatus", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "ProductColor",
                columns: table => new
                {
                    ProductColorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductColor", x => x.ProductColorID);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    ProductTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ProductTypeName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.ProductTypeID);
                });

            migrationBuilder.CreateTable(
                name: "StockTake",
                columns: table => new
                {
                    StockTakeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminID = table.Column<int>(type: "int", nullable: true),
                    StockTakeDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTake", x => x.StockTakeID);
                });

            migrationBuilder.CreateTable(
                name: "SubscriberStatus",
                columns: table => new
                {
                    SubscriberStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriberStatus", x => x.SubscriberStatusID);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    SupplierID = table.Column<int>(type: "int", nullable: false),
                    SupplierName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    SupplierPhoneNumber = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    SupplierEmail = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    SupplierAddress = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Username = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "WorkshopEquipment",
                columns: table => new
                {
                    WorkshopEquipmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopEquipment", x => x.WorkshopEquipmentID);
                });

            migrationBuilder.CreateTable(
                name: "WorkshopHost",
                columns: table => new
                {
                    HostID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HostName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    HostSurname = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    HostEmail = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopHost", x => x.HostID);
                });

            migrationBuilder.CreateTable(
                name: "WorkshopType",
                columns: table => new
                {
                    WorkshopTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopType", x => x.WorkshopTypeID);
                });

            migrationBuilder.CreateTable(
                name: "WorkshopVenue",
                columns: table => new
                {
                    WorkshopVenueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VenueName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Address = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopVenue", x => x.WorkshopVenueID);
                });

            migrationBuilder.CreateTable(
                name: "WriteOffReason",
                columns: table => new
                {
                    WriteOffReasonID = table.Column<int>(type: "int", nullable: false),
                    WriteOffReason_Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WriteOffReason", x => x.WriteOffReasonID);
                });

            migrationBuilder.CreateTable(
                name: "DiscountRequest",
                columns: table => new
                {
                    DiscountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountDescription = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DiscountTypeID = table.Column<int>(type: "int", nullable: true),
                    DiscountStatusID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount Request", x => x.DiscountID);
                    table.ForeignKey(
                        name: "FK_Discount Request_Discount Status",
                        column: x => x.DiscountStatusID,
                        principalTable: "DiscountStatus",
                        principalColumn: "DiscountStatusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Discount Request_Discount Type",
                        column: x => x.DiscountTypeID,
                        principalTable: "DiscountType",
                        principalColumn: "DiscountTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupplierInventory",
                columns: table => new
                {
                    SupplierPurchaseID = table.Column<int>(type: "int", nullable: false),
                    InventoryID = table.Column<int>(type: "int", nullable: true),
                    InventoryItemPrice = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    SupplierInventoryID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier Inventory", x => x.SupplierPurchaseID);
                    table.ForeignKey(
                        name: "FK_Supplier Inventory_Inventory",
                        column: x => x.InventoryID,
                        principalTable: "Inventory",
                        principalColumn: "InventoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ProductTypeID = table.Column<int>(type: "int", nullable: true),
                    ProductColourID = table.Column<int>(type: "int", nullable: true),
                    GetProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Product_ProductColor",
                        column: x => x.ProductColourID,
                        principalTable: "ProductColor",
                        principalColumn: "ProductColorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_ProductType",
                        column: x => x.ProductTypeID,
                        principalTable: "ProductType",
                        principalColumn: "ProductTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockTakeTotal",
                columns: table => new
                {
                    StockTakeTotalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryID = table.Column<int>(type: "int", nullable: true),
                    StocKTakeID = table.Column<int>(type: "int", nullable: true),
                    StockTakeTotal_Qty = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTakeTotal", x => x.StockTakeTotalID);
                    table.ForeignKey(
                        name: "FK_Stock Take Total_Inventory",
                        column: x => x.InventoryID,
                        principalTable: "Inventory",
                        principalColumn: "InventoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stock Take Total_Stock Take",
                        column: x => x.StocKTakeID,
                        principalTable: "StockTake",
                        principalColumn: "StockTakeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdministratorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    AdministratorName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    AdministratorSurname = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    AdministratorPhoneNumber = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    AdministratorEmail = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdministratorID);
                    table.ForeignKey(
                        name: "FK_Admin_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Surname = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: true),
                    EmailAddress = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    GenderID = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientID);
                    table.ForeignKey(
                        name: "FK_Client_Gender",
                        column: x => x.GenderID,
                        principalTable: "Gender",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Client_User",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkshopType_Equipment",
                columns: table => new
                {
                    WorkshopTypeID = table.Column<int>(type: "int", nullable: false),
                    WorkshopEquipmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopType_Equipment", x => new { x.WorkshopTypeID, x.WorkshopEquipmentID });
                    table.ForeignKey(
                        name: "FK_WorkshopType_Equipment_WorkshopEquipment",
                        column: x => x.WorkshopEquipmentID,
                        principalTable: "WorkshopEquipment",
                        principalColumn: "WorkshopEquipmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkshopType_Equipment_WorkshopType",
                        column: x => x.WorkshopTypeID,
                        principalTable: "WorkshopType",
                        principalColumn: "WorkshopTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Workshop",
                columns: table => new
                {
                    WorkshopID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HostID = table.Column<int>(type: "int", nullable: false),
                    WorkshopTypeID = table.Column<int>(type: "int", nullable: false),
                    WorkshopVenueID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WorkshopDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workshop", x => x.WorkshopID);
                    table.ForeignKey(
                        name: "FK_Workshop_Venue",
                        column: x => x.WorkshopVenueID,
                        principalTable: "WorkshopVenue",
                        principalColumn: "WorkshopVenueID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Workshop_WorkshopHost",
                        column: x => x.HostID,
                        principalTable: "WorkshopHost",
                        principalColumn: "HostID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Workshop_WorkshopType",
                        column: x => x.WorkshopTypeID,
                        principalTable: "WorkshopType",
                        principalColumn: "WorkshopTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WriteOffInventory",
                columns: table => new
                {
                    WriteOffID = table.Column<int>(type: "int", nullable: false),
                    InventoryID = table.Column<int>(type: "int", nullable: true),
                    WriteOffReasonID = table.Column<int>(type: "int", nullable: true),
                    AdminID = table.Column<int>(type: "int", nullable: true),
                    WriteOffDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    WriteOffQty = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Write-Off Inventory", x => x.WriteOffID);
                    table.ForeignKey(
                        name: "FK_Write-Off Inventory_Inventory",
                        column: x => x.InventoryID,
                        principalTable: "Inventory",
                        principalColumn: "InventoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Write-Off Inventory_WriteOffReason",
                        column: x => x.WriteOffReasonID,
                        principalTable: "WriteOffReason",
                        principalColumn: "WriteOffReasonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupplierPurchase",
                columns: table => new
                {
                    SupplierPurchaseID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    QuantityPurchased = table.Column<int>(type: "int", nullable: true),
                    TotalCost = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    SupplierID = table.Column<int>(type: "int", nullable: true),
                    InventoryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierPurchase", x => x.SupplierPurchaseID);
                    table.ForeignKey(
                        name: "FK_Supplier Purchase_Supplier",
                        column: x => x.SupplierID,
                        principalTable: "Supplier",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Supplier Purchase_Supplier Inventory",
                        column: x => x.InventoryID,
                        principalTable: "SupplierInventory",
                        principalColumn: "SupplierPurchaseID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrepareOrder",
                columns: table => new
                {
                    PrepareOrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    InventoryID = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrepareOrder", x => x.PrepareOrderID);
                    table.ForeignKey(
                        name: "FK_PrepareOrder_Inventory",
                        column: x => x.InventoryID,
                        principalTable: "Inventory",
                        principalColumn: "InventoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrepareOrder_Product",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductPrice",
                columns: table => new
                {
                    ProductPriceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPrice", x => x.ProductPriceID);
                    table.ForeignKey(
                        name: "FK_Product Price_Product",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    PolicyID = table.Column<int>(type: "int", nullable: false),
                    PolicyName = table.Column<string>(type: "varchar(225)", unicode: false, maxLength: 225, nullable: true),
                    Description = table.Column<string>(type: "varchar(225)", unicode: false, maxLength: 225, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    AdminID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.PolicyID);
                    table.ForeignKey(
                        name: "FK_Policy_Admin",
                        column: x => x.AdminID,
                        principalTable: "Admin",
                        principalColumn: "AdministratorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetNumber = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    StreetName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    City = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Province = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    AreaCode = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Country = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ClientID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_Address_Client",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ClientID = table.Column<int>(type: "int", nullable: true),
                    BookingID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.CartID);
                    table.ForeignKey(
                        name: "FK_Cart_Client1",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cart_Product",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NewsletterSubscriber",
                columns: table => new
                {
                    NewsletterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    SubscriberStatusID = table.Column<int>(type: "int", nullable: true),
                    ClientID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newsletter Subscriber", x => x.NewsletterID);
                    table.ForeignKey(
                        name: "FK_Newsletter Subscriber_Subscriber Status",
                        column: x => x.SubscriberStatusID,
                        principalTable: "SubscriberStatus",
                        principalColumn: "SubscriberStatusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewsletterSubscriber_Client",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookingInstance",
                columns: table => new
                {
                    BookingInstanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    WorkshopID = table.Column<int>(type: "int", nullable: true),
                    BookingStatusID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingInstance", x => x.BookingInstanceID);
                    table.ForeignKey(
                        name: "FK_Booking Instance_BookingStatus",
                        column: x => x.BookingStatusID,
                        principalTable: "BookingStatus",
                        principalColumn: "BookingStatusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking Instance_Workshop",
                        column: x => x.WorkshopID,
                        principalTable: "Workshop",
                        principalColumn: "WorkshopID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    ClientID = table.Column<int>(type: "int", nullable: true),
                    OrderStatusID = table.Column<int>(type: "int", nullable: true),
                    DeliveryCompanyID = table.Column<int>(type: "int", nullable: true),
                    DiscountID = table.Column<int>(type: "int", nullable: true),
                    AddressID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Order_Address",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Client",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Delivery Company",
                        column: x => x.DeliveryCompanyID,
                        principalTable: "DeliveryCompany",
                        principalColumn: "DeliveryCompanyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Discount Request",
                        column: x => x.DiscountID,
                        principalTable: "DiscountRequest",
                        principalColumn: "DiscountID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Order Status",
                        column: x => x.OrderStatusID,
                        principalTable: "OrderStatus",
                        principalColumn: "OrderStatusID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartID = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    PayfastID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payment_Cart",
                        column: x => x.CartID,
                        principalTable: "Cart",
                        principalColumn: "CartID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_PaymentStatus",
                        column: x => x.StatusID,
                        principalTable: "PaymentStatus",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingInstanceID = table.Column<int>(type: "int", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    AttendanceStatusID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_Booking_AttendingStatus",
                        column: x => x.AttendanceStatusID,
                        principalTable: "AttendingStatus",
                        principalColumn: "AttendanceStatusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_BookingInstance",
                        column: x => x.BookingInstanceID,
                        principalTable: "BookingInstance",
                        principalColumn: "BookingInstanceID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Client",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OrderProductID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order Product", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Order Product_Order",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order Product_Product",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductRating",
                columns: table => new
                {
                    ProductRatingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: true),
                    ReviewDescription = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    OrderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRating", x => x.ProductRatingID);
                    table.ForeignKey(
                        name: "FK_ProductRating_Order Product",
                        column: x => x.ProductID,
                        principalTable: "OrderProduct",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductRating_Product",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_ClientID",
                table: "Address",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_UserID",
                table: "Admin",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_AttendanceStatusID",
                table: "Booking",
                column: "AttendanceStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_BookingInstanceID",
                table: "Booking",
                column: "BookingInstanceID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ClientID",
                table: "Booking",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_BookingInstance_BookingStatusID",
                table: "BookingInstance",
                column: "BookingStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_BookingInstance_WorkshopID",
                table: "BookingInstance",
                column: "WorkshopID");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ClientID",
                table: "Cart",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ProductID",
                table: "Cart",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Client_GenderID",
                table: "Client",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Client_UserID",
                table: "Client",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountRequest_DiscountStatusID",
                table: "DiscountRequest",
                column: "DiscountStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountRequest_DiscountTypeID",
                table: "DiscountRequest",
                column: "DiscountTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_NewsletterSubscriber_ClientID",
                table: "NewsletterSubscriber",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_NewsletterSubscriber_SubscriberStatusID",
                table: "NewsletterSubscriber",
                column: "SubscriberStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_AddressID",
                table: "Order",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ClientID",
                table: "Order",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_DeliveryCompanyID",
                table: "Order",
                column: "DeliveryCompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_DiscountID",
                table: "Order",
                column: "DiscountID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderStatusID",
                table: "Order",
                column: "OrderStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductID",
                table: "OrderProduct",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CartID",
                table: "Payment",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_StatusID",
                table: "Payment",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_AdminID",
                table: "Policy",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_PrepareOrder_InventoryID",
                table: "PrepareOrder",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PrepareOrder_ProductID",
                table: "PrepareOrder",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductColourID",
                table: "Product",
                column: "ProductColourID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTypeID",
                table: "Product",
                column: "ProductTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrice_ProductID",
                table: "ProductPrice",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRating_ProductID",
                table: "ProductRating",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_StockTakeTotal_InventoryID",
                table: "StockTakeTotal",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_StockTakeTotal_StocKTakeID",
                table: "StockTakeTotal",
                column: "StocKTakeID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierInventory_InventoryID",
                table: "SupplierInventory",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierPurchase_InventoryID",
                table: "SupplierPurchase",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierPurchase_SupplierID",
                table: "SupplierPurchase",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_Workshop_HostID",
                table: "Workshop",
                column: "HostID");

            migrationBuilder.CreateIndex(
                name: "IX_Workshop_WorkshopTypeID",
                table: "Workshop",
                column: "WorkshopTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Workshop_WorkshopVenueID",
                table: "Workshop",
                column: "WorkshopVenueID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopType_Equipment_WorkshopEquipmentID",
                table: "WorkshopType_Equipment",
                column: "WorkshopEquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_WriteOffInventory_InventoryID",
                table: "WriteOffInventory",
                column: "InventoryID");

            migrationBuilder.CreateIndex(
                name: "IX_WriteOffInventory_WriteOffReasonID",
                table: "WriteOffInventory",
                column: "WriteOffReasonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "NewsletterSubscriber");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Policy");

            migrationBuilder.DropTable(
                name: "PrepareOrder");

            migrationBuilder.DropTable(
                name: "ProductPrice");

            migrationBuilder.DropTable(
                name: "ProductRating");

            migrationBuilder.DropTable(
                name: "StockTakeTotal");

            migrationBuilder.DropTable(
                name: "SupplierPurchase");

            migrationBuilder.DropTable(
                name: "WorkshopType_Equipment");

            migrationBuilder.DropTable(
                name: "WriteOffInventory");

            migrationBuilder.DropTable(
                name: "AttendingStatus");

            migrationBuilder.DropTable(
                name: "BookingInstance");

            migrationBuilder.DropTable(
                name: "SubscriberStatus");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "PaymentStatus");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "StockTake");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "SupplierInventory");

            migrationBuilder.DropTable(
                name: "WorkshopEquipment");

            migrationBuilder.DropTable(
                name: "WriteOffReason");

            migrationBuilder.DropTable(
                name: "BookingStatus");

            migrationBuilder.DropTable(
                name: "Workshop");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "WorkshopVenue");

            migrationBuilder.DropTable(
                name: "WorkshopHost");

            migrationBuilder.DropTable(
                name: "WorkshopType");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "DeliveryCompany");

            migrationBuilder.DropTable(
                name: "DiscountRequest");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "ProductColor");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "DiscountStatus");

            migrationBuilder.DropTable(
                name: "DiscountType");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
