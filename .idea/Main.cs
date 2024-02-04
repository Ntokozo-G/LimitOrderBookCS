using System;
using System.Collections.Generic;

namespace Order
{
    public class Main
    {
        public static void Main(string[] args)
        {
            UniqueIdGenerator uniqueId = new UniqueIdGenerator();
            OrderBook orderBook = new OrderBook();

            Order order1 = new Order(uniqueId.GetId(), 100.0, "bid", 10, DateTime.Now);
            Order order2 = new Order(uniqueId.GetId(), 99.0, "bid", 20, DateTime.Now);
            Order order3 = new Order(uniqueId.GetId(), 100.0, "offer", 30, DateTime.Now);
            Order order4 = new Order(uniqueId.GetId(), 101.0, "offer", 40, DateTime.Now);
            Order order5 = new Order(uniqueId.GetId(), 97.0, "bid", 50, DateTime.Now);
            Order order6 = new Order(uniqueId.GetId(), 14.0, "offer", 60, DateTime.Now);
            Order order7 = new Order(uniqueId.GetId(), 101.0, "bid", 60, DateTime.Now);
            Order order8 = new Order(uniqueId.GetId(), 100, "bid", 100, DateTime.Now);
            Order order9 = new Order(uniqueId.GetId(), 12.0, "offer", 10, DateTime.Now);
            Order order10 = new Order(uniqueId.GetId(), 12.0, "offer", 100, DateTime.Now);

            orderBook.AddOrder(order1);
            orderBook.AddOrder(order2);
            orderBook.AddOrder(order3);
            orderBook.AddOrder(order4);
            orderBook.AddOrder(order5);
            orderBook.AddOrder(order6);
            orderBook.AddOrder(order7);
            orderBook.AddOrder(order8);
            orderBook.AddOrder(order9);
            orderBook.AddOrder(order10);

            Console.WriteLine("Added orders in the orderbook:");
            Console.WriteLine("Added orders in the orderbook: " + OrderSide.BID.Label);
            List<Order> bidList = orderBook.GetOrders(OrderSide.BID.Label);
            bidList.ForEach(e => Console.WriteLine(" " + e.Id + "  " + e.Price + "  " + e.Side + "  " + e.Size + "  " + e.Timestamp));

            Console.WriteLine("Added orders in the orderbook: " + OrderSide.OFFER.Label);
            List<Order> offerList = orderBook.GetOrders(OrderSide.OFFER.Label);
            offerList.ForEach(e => Console.WriteLine("  " + e.Id + "  " + e.Price + "  " + e.Side + "  " + e.Size + "  " + e.Timestamp));

            Console.WriteLine("Orderbook bid after modification:");
            orderBook.ModifyOrder(order8.Id, 50);

            List<Order> bidListM = orderBook.GetOrders(OrderSide.BID.Label);
            bidListM.ForEach(e => Console.WriteLine(" " + e.Id + "  " + e.Price + "  " + e.Side + "  " + e.Size + "  " + e.Timestamp));

            Console.WriteLine("Orderbook offer after modification:");
            orderBook.ModifyOrder(order9.Id, 30);
            List<Order> offerListM = orderBook.GetOrders(OrderSide.OFFER.Label);
            offerListM.ForEach(e => Console.WriteLine(" " + e.Id + "  " + e.Price + "  " + e.Side + "  " + e.Size + "  " + e.Timestamp));

            Console.WriteLine("Orderbook bid after modification:");
            orderBook.ModifyOrder(order1.Id, 70);

            List<Order> bidListMw = orderBook.GetOrders(OrderSide.BID.Label);
            bidListMw.ForEach(e => Console.WriteLine(" " + e.Id + "  " + e.Price + "  " + e.Side + "  " + e.Size + "  " + e.Timestamp));
        }
    }
}