using System;
using System.Collections.Generic;

namespace SimpleOnlineStore.Models
{
    public interface IMembership
    {
        DateTime Date { get; set; }
        double DurationInYear { get; set; }
        Store Store { get; set; }
        IDiscount GetApplicableDiscount();
    }

    public class IUser
    {
        string Name { get; set; }
        string Email { get; set; }
        string Address { get; set; }
        List<Order> Orders { get; set; }
    }

    public abstract class MemberUser : IUser, IMembership
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public List<Order> Orders { get; set; }

        public DateTime Date { get; set; }
        public double DurationInYear { get; set; }
        public Store Store { get; set; }
        public abstract IDiscount GetApplicableDiscount();

        public void PlaceOrder(Order order) {
            if (this.Orders == null)
                this.Orders = new List<Order>();
            this.Orders.Add(order);
        }
    }


    public class Employee : MemberUser
    {
        public double Salary { get; set; }

        public override IDiscount GetApplicableDiscount()
        {
            return new MembershipDiscount(30);
        }
    }

    public class Affiliate : MemberUser
    {
        public string AffiliatedBy { get; set; }
        public override IDiscount GetApplicableDiscount()
        {
            return new MembershipDiscount(10);
        }
    }

    public class Customer : MemberUser
    {
        public string AffiliatedBy { get; set; }
        public override IDiscount GetApplicableDiscount()
        {
            if(this.DurationInYear > 2)
                return new MembershipDiscount(5);
            else
                return new MembershipDiscount(0);
        }
    }

    public class Store
    {
        public string Name { get; set; }
    }
    
    public interface IDiscount
    {
        double Percent { get; set; }
        double GetNetPayable(double amount);
    }

    public class MembershipDiscount : IDiscount
    {
        public double Percent { get; set; }
        public MembershipDiscount(double percent)
        { this.Percent = percent; }
        public double GetNetPayable(double amount)
        {
            return amount - (amount * this.Percent / 100);
        }
    }

    public class CollectiveDiscount : IDiscount
    {
        public double Percent { get; set; }
        public CollectiveDiscount()
        {
            this.Percent = 5;
        }
        public CollectiveDiscount(double percent)
        {
            this.Percent = percent;
        }
        public double GetNetPayable(double amount)
        {
            return (amount - amount % 100) * this.Percent / 100;
        }
    }

}
