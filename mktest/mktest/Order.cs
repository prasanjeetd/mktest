using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace mktest
{
    public class Order
    {
        public List<OrderItem> orderItems { get; set; }

        public decimal total { get; set; }

        Payment payment = new Payment();

        public Order()
        {

            orderItems = new List<OrderItem>();
        }

        public void Process()
        {
            this.total = orderItems.Sum(x => (x.product.Mrp * x.Qty) - x.discount);

            bool isSuccesfulPayment = payment.Pay(this);

            if (isSuccesfulPayment)
            {
                foreach (var orderItem in orderItems)
                {
                    orderItem.product.ExecutePostOrder();
                }
            }
        }

    }
}
