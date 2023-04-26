using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using team40_iteration6_user.Models;

//namespace team40_iteration6_user.Models
namespace team40_iteration6_user.Team40
{
    public partial class CoreDbContext : IdentityDbContext<AppUser>
    {
        public CoreDbContext()
        {
        }

        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<AttendingStatus> AttendingStatus { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<BookingInstance> BookingInstance { get; set; }
        public virtual DbSet<BookingStatus> BookingStatus { get; set; }
        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<DeliveryCompany> DeliveryCompany { get; set; }
        public virtual DbSet<DiscountRequest> DiscountRequest { get; set; }
        public virtual DbSet<DiscountStatus> DiscountStatus { get; set; }
        public virtual DbSet<DiscountType> DiscountType { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<NewsletterSubscriber> NewsletterSubscriber { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderProduct> OrderProduct { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<PaymentStatus> PaymentStatus { get; set; }
        public virtual DbSet<Policy> Policy { get; set; }
        public virtual DbSet<PrepareOrder> PrepareOrder { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductColor> ProductColor { get; set; }
        public virtual DbSet<ProductPrice> ProductPrice { get; set; }
        public virtual DbSet<ProductRating> ProductRating { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<StockTake> StockTake { get; set; }
        public virtual DbSet<StockTakeTotal> StockTakeTotal { get; set; }
        public virtual DbSet<SubscriberStatus> SubscriberStatus { get; set; }
        public virtual DbSet<Supply> Supplier { get; set; }
        public virtual DbSet<SupplierInventory> SupplierInventory { get; set; }
        public virtual DbSet<SupplierPurchase> SupplierPurchase { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<VwBookingInstanceDetail> VwBookingInstanceDetail { get; set; }
        public virtual DbSet<VwWorkShopDetail> VwWorkShopDetail { get; set; }
        public virtual DbSet<Workshop> Workshop { get; set; }
        public virtual DbSet<WorkshopEquipment> WorkshopEquipment { get; set; }
        public virtual DbSet<WorkshopHost> WorkshopHost { get; set; }
        public virtual DbSet<WorkshopType> WorkshopType { get; set; }
        public virtual DbSet<WorkshopTypeEquipment> WorkshopTypeEquipment { get; set; }
        public virtual DbSet<WorkshopVenue> WorkshopVenue { get; set; }
        public virtual DbSet<WriteOffInventory> WriteOffInventory { get; set; }
        public virtual DbSet<WriteOffReason> WriteOffReason { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:inf370team40.database.windows.net,1433;Database=Team40;Persist Security Info=False;User ID= inf370team40_admin;Password= tuksofniks2022!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                //optionsBuilder.UseSqlServer("Server=LAPTOP-G49DL6P0\\SQLEXPRESS;Database=Team40_1;Trusted_Connection=True;MultipleActiveResultSets=True");
            }
        }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                base.OnModelCreating(modelBuilder);
                entity.Property(e => e.AreaCode).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Country).IsUnicode(false);

                entity.Property(e => e.Province).IsUnicode(false);

                entity.Property(e => e.StreetName).IsUnicode(false);

                entity.Property(e => e.StreetNumber).IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_Address_Client");
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.AdministratorEmail).IsUnicode(false);

                entity.Property(e => e.AdministratorName).IsUnicode(false);

                entity.Property(e => e.AdministratorPhoneNumber).IsUnicode(false);

                entity.Property(e => e.AdministratorSurname).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Admin)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Admin_User");
            });

            modelBuilder.Entity<AttendingStatus>(entity =>
            {
                entity.HasKey(e => e.AttendanceStatusId)
                    .HasName("PK_Attending Status");

                entity.Property(e => e.AttendanceStatusName).IsUnicode(false);
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasOne(d => d.AttendanceStatus)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.AttendanceStatusId)
                    .HasConstraintName("FK_Booking_AttendingStatus");

                entity.HasOne(d => d.BookingInstance)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.BookingInstanceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_BookingInstance");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Client");
            });

            modelBuilder.Entity<BookingInstance>(entity =>
            {
                entity.HasOne(d => d.BookingStatus)
                    .WithMany(p => p.BookingInstance)
                    .HasForeignKey(d => d.BookingStatusId)
                    .HasConstraintName("FK_Booking Instance_BookingStatus");

                entity.HasOne(d => d.Workshop)
                    .WithMany(p => p.BookingInstance)
                    .HasForeignKey(d => d.WorkshopId)
                    .HasConstraintName("FK_Booking Instance_Workshop");
            });

            modelBuilder.Entity<BookingStatus>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<Brands>(entity =>
            {
                entity.HasKey(e => e.BrandId)
                    .HasName("PK__Brands__DAD4F05E4DF03281");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_Cart_Client1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Cart_Product");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.EmailAddress).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.PhoneNumber).IsUnicode(false);

                entity.Property(e => e.Surname).IsUnicode(false);

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK_Client_Gender");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Client)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Client_User");
            });

            modelBuilder.Entity<DeliveryCompany>(entity =>
            {
                entity.Property(e => e.ContactPersonName).IsUnicode(false);

                entity.Property(e => e.DeliveryCompanyEmail).IsUnicode(false);

                entity.Property(e => e.DeliveryCompanyName).IsUnicode(false);
                //entity.Property(e => e.Method).IsUnicode(false);
            });

            modelBuilder.Entity<DiscountRequest>(entity =>
            {
                entity.HasKey(e => e.DiscountId)
                    .HasName("PK_Discount Request");

                entity.Property(e => e.DiscountDescription).IsUnicode(false);

                entity.HasOne(d => d.DiscountStatus)
                    .WithMany(p => p.DiscountRequest)
                    .HasForeignKey(d => d.DiscountStatusId)
                    .HasConstraintName("FK_Discount Request_Discount Status");

                entity.HasOne(d => d.DiscountType)
                    .WithMany(p => p.DiscountRequest)
                    .HasForeignKey(d => d.DiscountTypeId)
                    .HasConstraintName("FK_Discount Request_Discount Type");
            });

            modelBuilder.Entity<DiscountStatus>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<DiscountType>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.Property(e => e.GenderName).IsUnicode(false);
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.Property(e => e.ItemName).IsUnicode(false);
            });

            modelBuilder.Entity<NewsletterSubscriber>(entity =>
            {
                entity.HasKey(e => e.NewsletterId)
                    .HasName("PK_Newsletter Subscriber");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.NewsletterSubscriber)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_NewsletterSubscriber_Client");

                entity.HasOne(d => d.SubscriberStatus)
                    .WithMany(p => p.NewsletterSubscriber)
                    .HasForeignKey(d => d.SubscriberStatusId)
                    .HasConstraintName("FK_Newsletter Subscriber_Subscriber Status");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderProductId).IsUnicode(false);
                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_Order_Address");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_Order_Client");

                entity.HasOne(d => d.DeliveryCompany)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.DeliveryCompanyId)
                    .HasConstraintName("FK_Order_Delivery Company");

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.DiscountId)
                    .HasConstraintName("FK_Order_Discount Request");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.OrderStatusId)
                    .HasConstraintName("FK_Order_Order Status");
                entity.Property(e => e.Quantity).IsUnicode(false);
                entity.Property(e => e.ProductId).IsUnicode(false);
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                //entity.Property(e => e.Quantity).IsUnicode(false);
                entity.HasKey(e => e.OrderId)
                    .HasName("PK_Order Product");

                entity.Property(e => e.OrderId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Order)
                    .WithOne(p => p.OrderProduct)
                    .HasForeignKey<OrderProduct>(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order Product_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderProduct)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Order Product_Product");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("FK_Payment_Cart");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_Payment_PaymentStatus");
            });

            modelBuilder.Entity<PaymentStatus>(entity =>
            {
                entity.Property(e => e.StatusName).IsUnicode(false);
            });

            modelBuilder.Entity<Policy>(entity =>
            {
                entity.Property(e => e.PolicyId).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.PolicyName).IsUnicode(false);

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.Policy)
                    .HasForeignKey(d => d.AdminId)
                    .HasConstraintName("FK_Policy_Admin");
            });

            modelBuilder.Entity<PrepareOrder>(entity =>
            {
                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.PrepareOrder)
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("FK_PrepareOrder_Inventory");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PrepareOrder)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_PrepareOrder_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);
                entity.Property(e => e.QuantityOnHand).IsUnicode(false);

                entity.Property(e => e.ProductName).IsUnicode(false);
                entity.Property(e => e.Price).IsUnicode(false);

                entity.HasOne(d => d.ProductColour)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductColourId)
                    .HasConstraintName("FK_Product_ProductColor");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductTypeId)
                    .HasConstraintName("FK_Product_ProductType");
            });

            modelBuilder.Entity<ProductColor>(entity =>
            {
                entity.Property(e => e.ColorName).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<ProductPrice>(entity =>
            {
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductPrice)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Product Price_Product");
            });

            modelBuilder.Entity<ProductRating>(entity =>
            {
                entity.Property(e => e.Rating)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ReviewDescription).IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductRating)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ProductRating_Order Product");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(p => p.ProductRating)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ProductRating_Product");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.ProductTypeName).IsUnicode(false);
            });

            modelBuilder.Entity<StockTakeTotal>(entity =>
            {
                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.StockTakeTotal)
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("FK_Stock Take Total_Inventory");

                entity.HasOne(d => d.StocKtake)
                    .WithMany(p => p.StockTakeTotal)
                    .HasForeignKey(d => d.StocKtakeId)
                    .HasConstraintName("FK_Stock Take Total_Stock Take");

                entity.Property(e => e.Remarks).IsUnicode(false);
            });

            modelBuilder.Entity<SubscriberStatus>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<Supply>(entity =>
            {
                entity.Property(e => e.SupplierId).ValueGeneratedNever();

                entity.Property(e => e.SupplierAddress).IsUnicode(false);

                entity.Property(e => e.SupplierEmail).IsUnicode(false);

                entity.Property(e => e.SupplierName).IsUnicode(false);

                entity.Property(e => e.SupplierPhoneNumber).IsUnicode(false);
            });

            modelBuilder.Entity<SupplierInventory>(entity =>
            {
                entity.HasKey(e => e.SupplierPurchaseId)
                    .HasName("PK_Supplier Inventory");

                entity.Property(e => e.SupplierPurchaseId).ValueGeneratedNever();

                entity.Property(e => e.SupplierInventoryId).IsUnicode(false);

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.SupplierInventory)
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("FK_Supplier Inventory_Inventory");
            });

            modelBuilder.Entity<SupplierPurchase>(entity =>
            {
                entity.Property(e => e.SupplierPurchaseId).ValueGeneratedNever();

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.SupplierPurchase)
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("FK_Supplier Purchase_Supplier Inventory");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.SupplierPurchase)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_Supplier Purchase_Supplier");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);
            });

            modelBuilder.Entity<VwBookingInstanceDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_BookingInstanceDetail");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.HostEmail).IsUnicode(false);

                entity.Property(e => e.HostName).IsUnicode(false);

                entity.Property(e => e.HostSurname).IsUnicode(false);

                entity.Property(e => e.Type).IsUnicode(false);

                entity.Property(e => e.VenueName).IsUnicode(false);
            });

            modelBuilder.Entity<VwWorkShopDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_WorkShopDetail");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.HostEmail).IsUnicode(false);

                entity.Property(e => e.HostName).IsUnicode(false);

                entity.Property(e => e.HostSurname).IsUnicode(false);

                entity.Property(e => e.Type).IsUnicode(false);

                entity.Property(e => e.VenueName).IsUnicode(false);
            });

            modelBuilder.Entity<Workshop>(entity =>
            {
                entity.HasOne(d => d.Host)
                    .WithMany(p => p.Workshop)
                    .HasForeignKey(d => d.HostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Workshop_WorkshopHost");

                entity.HasOne(d => d.WorkshopType)
                    .WithMany(p => p.Workshop)
                    .HasForeignKey(d => d.WorkshopTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Workshop_WorkshopType");

                entity.HasOne(d => d.WorkshopVenue)
                    .WithMany(p => p.Workshop)
                    .HasForeignKey(d => d.WorkshopVenueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Workshop_Venue");
            });

            modelBuilder.Entity<WorkshopEquipment>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<WorkshopHost>(entity =>
            {
                entity.Property(e => e.HostEmail).IsUnicode(false);

                entity.Property(e => e.HostName).IsUnicode(false);

                entity.Property(e => e.HostSurname).IsUnicode(false);
            });

            modelBuilder.Entity<WorkshopType>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);
            });

            modelBuilder.Entity<WorkshopTypeEquipment>(entity =>
            {
                entity.HasKey(e => new { e.WorkshopTypeId, e.WorkshopEquipmentId });

                entity.HasOne(d => d.WorkshopEquipment)
                    .WithMany(p => p.WorkshopTypeEquipment)
                    .HasForeignKey(d => d.WorkshopEquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkshopType_Equipment_WorkshopEquipment");

                entity.HasOne(d => d.WorkshopType)
                    .WithMany(p => p.WorkshopTypeEquipment)
                    .HasForeignKey(d => d.WorkshopTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkshopType_Equipment_WorkshopType");
            });

            modelBuilder.Entity<WorkshopVenue>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.VenueName).IsUnicode(false);
            });

            modelBuilder.Entity<WriteOffInventory>(entity =>
            {
                entity.HasKey(e => e.WriteOffId)
                    .HasName("PK_Write-Off Inventory");

                entity.Property(e => e.WriteOffId).ValueGeneratedNever();

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.WriteOffInventory)
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("FK_Write-Off Inventory_Inventory");

                entity.HasOne(d => d.WriteOffReason)
                    .WithMany(p => p.WriteOffInventory)
                    .HasForeignKey(d => d.WriteOffReasonId)
                    .HasConstraintName("FK_Write-Off Inventory_WriteOffReason");
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<WriteOffReason>(entity =>
            {
                entity.Property(e => e.WriteOffReasonId).ValueGeneratedNever();

                entity.Property(e => e.WriteOffReasonDescription).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
