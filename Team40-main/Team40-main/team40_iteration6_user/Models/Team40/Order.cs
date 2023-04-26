using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class Order
    {
        [Key]
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }
        [Column("ClientID")]
        public int? ClientId { get; set; }
        [Column("OrderProductID")]
        public int? OrderProductId { get; set; }
        [Column("OrderStatusID")]
        public int? OrderStatusId { get; set; }
        [Column("DeliveryCompanyID")]
        public int? DeliveryCompanyId { get; set; }
        [Column("DiscountID")]
        public int? DiscountId { get; set; }
        [Column("ProductID")]
        public int? ProductId { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Quantity { get; set; }

        [Column("AddressID")]
        public int? AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("Order")]
        public virtual Address Address { get; set; }
        [ForeignKey(nameof(ClientId))]
        [InverseProperty("Order")]
        public virtual Client Client { get; set; }
        [ForeignKey(nameof(DeliveryCompanyId))]
        [InverseProperty("Order")]
        public virtual DeliveryCompany DeliveryCompany { get; set; }
        [ForeignKey(nameof(DiscountId))]
        [InverseProperty(nameof(DiscountRequest.Order))]
        public virtual DiscountRequest Discount { get; set; }
        [ForeignKey(nameof(OrderStatusId))]
        [InverseProperty("Order")]
        public virtual OrderStatus OrderStatus { get; set; }
        [InverseProperty("Order")]
        public virtual OrderProduct OrderProduct { get; set; }


        //[InverseProperty("Order")]
        //public virtual Product Product { get; set; }

    }
}
