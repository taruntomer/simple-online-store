using SimpleOnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleOnlineStore
{
    class Program
    {
        static void Main(string[] args)
        {
            IUser employee = new Employee();
            StoreService storeService = new StoreService(employee);
            Category groceries = new Category() { Id = 1, Name = "Groceries" };
            Category cosmetics = new Category() { Id = 2, Name = "Cosmetics" };
            List<OrderDetail> orderDetails = new List<OrderDetail>() {
               new OrderDetail(new Product(){ Id=1, Category= cosmetics, Name = "Vaseline", UnitPrice = 50}, 4),
               new OrderDetail(new Product(){ Id=2, Category= cosmetics, Name = "Perfume", UnitPrice = 200}, 2),
               new OrderDetail(new Product(){ Id=2, Category= cosmetics, Name = "Bronzer", UnitPrice = 200}, 1),
               new OrderDetail(new Product(){ Id=2, Category= groceries, Name = "Chocolate", UnitPrice = 50}, 4),
               new OrderDetail(new Product(){ Id=2, Category= groceries, Name = "Sugar", UnitPrice = 100}, 2)
           };
            double netPayable = storeService.GetNetPayable(orderDetails);
            Console.WriteLine(netPayable);
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}
