using SimpleOnlineStore.Models;
using System.Collections.Generic;

namespace SimpleOnlineStore
{
    public class StoreService
    {
        private IUser _user;
        public StoreService(IUser user)
        {
            this._user = user;
        }
        public double GetNetPayable(List<OrderDetail> orderDetails)
        {
            IDiscount collectiveDiscount = new CollectiveDiscount();
            Order order = new Order(collectiveDiscount) { CreatedBy = this._user };
            orderDetails.ForEach((item) =>
            {
                order.AddOrderDetail(item);
            });
            return order.GetTotal();
        }
    }
}
