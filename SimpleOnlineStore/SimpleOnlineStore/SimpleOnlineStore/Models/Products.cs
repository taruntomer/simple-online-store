using System;
using System.Collections.Generic;

namespace SimpleOnlineStore.Models
{
    public interface IProduct
    {
        int Id { get; set; }
        string Name { get; set; }
        double UnitPrice { get; set; }
        Category Category { get; set; }
        IProductSpecification Specification { get; set; }
        double GetPrice();
    }

    public interface IProductSpecification
    {
        string Description { get; set; }
        string manufacturer { get; set; }
    }

    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public Category Category { get; set; }
        public IProductSpecification Specification { get; set; }

        public virtual double GetPrice()
        {
            return this.UnitPrice;
        }
    }

    public class CartItem
    {
        public IProduct Product { get; set; }
        public int Quantity { get; set; }
    }

    public class ConcessionalProduct: Product
    {
        protected IDiscount Discount { get; set; }
        protected IProduct Product { get; set; }
        public ConcessionalProduct(IProduct product, IDiscount discount)
        {
            this.Product = product;
            this.Discount = discount;
        }
        public override double GetPrice()
        {
            return this.Discount.GetNetPayable(base.UnitPrice);
        }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category ParentCategory { get; set; }
    }

    public class Order
    {
        private IDiscount _discount = null;
        public Order() { }
        public Order(IDiscount discount) {
            this._discount = discount;
        }
        public int Id { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public DateTime CreatedDate { get; set; }
        public IUser CreatedBy { get; set; }
        public void AddOrderDetail(OrderDetail orderDetail)
        {
            if (this.OrderDetails == null)
                this.OrderDetails = new List<OrderDetail>();
            if (orderDetail.Product.Category.Id != (int)DiscountExcludedCategory.Grocery)
            {
                IDiscount membershipDiscount = (this.CreatedBy as IMembership).GetApplicableDiscount();
                orderDetail.Product = new ConcessionalProduct(orderDetail.Product, membershipDiscount);
            }
            this.OrderDetails.Add(orderDetail);
        }
     
        public double GetTotal() {
            double total = 0;
            if (this.OrderDetails != null && this.OrderDetails.Count > 0)
            {
                this.OrderDetails.ForEach((detail) =>
                {
                    total = total + detail.GetSubTotal();
                });
                if (this._discount != null)
                    total = this._discount.GetNetPayable(total);
            }
            return total;
        } 
    }

    public class OrderDetail
    {
        public IProduct Product { get; set; }
        public int Quantity { get; set; }
        public OrderDetail(IProduct product, int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
        }
        public double GetSubTotal()
        {
            return this.Quantity * this.Product.GetPrice();
        }
    }

    public enum DiscountExcludedCategory
    { 
        Grocery = 1
    }
}
