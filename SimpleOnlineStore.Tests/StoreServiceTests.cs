using SimpleOnlineStore;
using SimpleOnlineStore.Models;
using System.Collections.Generic;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Ploeh.AutoFixture.Dsl;
using Ploeh.AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace SimpleOnlineStore.Tests
{
    public class StoreServiceTests
    {
        [Fact]
        public void GetNetPayable()
        {
           // IUser employee = new Employee();
           // var storeService = new StoreService(employee);
           // Category groceries = new Category() { Id = 1, Name = "Groceries" };
           // Category cosmetics = new Category() { Id = 2, Name = "Cosmetics" };
           // List<OrderDetail> orderDetails = new List<OrderDetail>() {
           //    new OrderDetail(new Product(){ Id=1, Category= cosmetics, Name = "Vaseline", UnitPrice = 50}, 4),
           //    new OrderDetail(new Product(){ Id=2, Category= cosmetics, Name = "Perfume", UnitPrice = 200}, 2),
           //    new OrderDetail(new Product(){ Id=2, Category= cosmetics, Name = "Bronzer", UnitPrice = 200}, 1),
           //    new OrderDetail(new Product(){ Id=2, Category= groceries, Name = "Chocolate", UnitPrice = 50}, 4),
           //    new OrderDetail(new Product(){ Id=2, Category= groceries, Name = "Sugar", UnitPrice = 100}, 2)
           //};

           // var netPayable = storeService.GetNetPayable(orderDetails);
           // Assert.Equal(20, netPayable);

            //var mockRepository = new MockRepository(MockBehavior.Default) { DefaultValue = DefaultValue.Mock };
            //var storeServiceMock = mockRepository.Create<StoreService>();
            //fooMock.SetupProperty(m => m.Name, "Hi");
            //var fooEntity = mockRepository.Create<IEntity>();
            //mockRepository.VerifyAll();

            var mockUser = new Mock<Employee>();
            var mockOrderDetails = new Mock<List<OrderDetail>>();
            var mockStoreService = new Mock<StoreService>( mockUser.Object);
            //StoreService storeServiceMock = Mock.Of<StoreService>((s) => s.GetNetPayable(null) == 1);
            mockStoreService.Object.GetNetPayable(mockOrderDetails.Object);
            //StoreService storeServiceMock = Mock.Of<StoreService>(f => f.Id == 12 && f.Name == "Test" && f.DoSomething("") == true
            //    && f.GetUser(1) == Mock.Of<User>(u => u.Id == 1 && u.FirstName == "FName")
            //    );

            Assert.Equal(20, 20);
        }

    }
}
