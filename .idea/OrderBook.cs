using System;
using System.Collections.Generic;

namespace com.order
{
    public class OrderBook
    {
        private Dictionary<string, List<Order>> ordersBySide;
        private Dictionary<string, Order> ordersById;

        public OrderBook()
        {
            ordersBySide = new Dictionary<string, List<Order>>();
            ordersById = new Dictionary<string, Order>();
        }
        
        // Add Order to OrderBook
        public void AddOrder(Order order) {
            string side = order.Side.ToLower();
            string id = order.Id;
            double price = order.Price;
            long size = order.Size;
            int i = 0;
            List<Order> orders;
            ordersBySide.TryGetValue(side, out orders);
            if (side == OrderSide.Bid.Label.ToLower() || side == OrderSide.Offer.Label.ToLower()) {
                if (orders == null) {
                    orders = new LinkedList<Order>();
                    ordersBySide[side] = orders;
                }
                if (side == OrderSide.Bid.Label.ToLower()) {
                    for (; i < orders.Count; i++) {
                        Order o = orders[i];
                        if (o.Price < price) {
                            break;
                        }
                    }
                    orders.Insert(i, order);
                    ordersById[id] = order;
                } else {
                    for (; i < orders.Count; i++) {
                        Order o = orders[i];
                        if (o.Price > price) {
                            break;
                        }
                    }
                    orders.Insert(i, order);
                    ordersById[id] = order;
                }
            }
        }
        
        // Remove/ Delete Order from OrderBook
        public void RemoveOrder(string id)
        {
            Order order = ordersById[id];
            if (order == null)
            {
                return;
            }
            string side = order.Side;
            List<Order> orders = ordersBySide[side];
            if (orders == null)
            {
                return;
            }
            orders.Remove(order);
            ordersById.Remove(id);
        }
        
        // Modify Order in OrderBook, retrive the order by id 
        public void ModifyOrder(string id, long newSize)
        {
            Order order = ordersById[id];
            if (order == null)
            {
                return;
            }
            string side = order.Side.ToLower();
            if (side == OrderSide.Bid.Label.ToLower() || side == OrderSide.Offer.Label.ToLower())
            {
                List<Order> orders;
                if (!ordersBySide.TryGetValue(side, out orders))
                {
                    return;
                }
                string modifiedSide = order.Side;
                string modifiedId = order.Id;
                double modifiedPrice = order.Price;
                long modifiedSize = newSize;
                orders.Remove(order);
                
                Order order1 = new Order(modifiedId, modifiedPrice, modifiedSide, modifiedSize, DateTime.Now);
                
                if ((side.Equals(OrderSide.BID.label)))
                {
                    for (; i < orders.Count; i++)
                    {
                        Order o = orders[i];
                        if (o.Price < modifiedPrice)
                        {
                            break;
                        }
                    }

                    orders.Insert(i, order1);
                    ordersById[id] = order1;
                }
                else
                {
                    for (; i < orders.Count; i++)
                    {
                        Order o = orders[i];
                        if (o.Price > modifiedPrice)
                        {
                            break;
                        }
                    }
                    orders.Insert(i, order1);
                    ordersById[id] = order1;
                }
                ordersBySide[modifiedSide] = orders;
                
            }
        }
        
        // Return Price based on Side ('B' bid or 'O' offer and Level) from OrderBook
        public double GetPrice(string side, int level)
        {
            if (side.ToLower().Equals(OrderSide.BID.Label) || side.ToLower().Equals(OrderSide.OFFER.Label))
            {
                List<Order> orders = ordersBySide[side.ToLower()];
                if (orders == null || orders.Count < level)
                {
                    return double.NaN;
                }
                return orders[level - 1].Price;
            }
            else
            {
                return double.NaN;
            }
        }
        
        //Given a side and a level return the size for that level
        public long GetSize(string side, int level)
        {
            if (side.ToLower() == OrderSide.BID.Label.ToLower() || side.ToLower() == OrderSide.OFFER.Label.ToLower())
            {
                List<Order> orders = ordersBySide[side.ToLower()];
                if (orders == null || orders.Count < level)
                {
                    return 0;
                }
                return orders[level - 1].GetSize();
            }
            else
            {
                return 0;
            }
        }
        
        
        // Return OrderBook Size based on Side ('B' bid or 'O' offer)
        public long GetTotalSize(string side)
        {
            if (side.ToLower() == OrderSide.BID.Label.ToLower() || side.ToLower() == OrderSide.OFFER.Label.ToLower())
            {
                List<Order> orders = OrdersBySide[side.ToLower()];
                if (orders == null)
                {
                    return 0;
                }

                return orders.Count;
            }
            else
            {
                return 0;
            }
        }
        
        // Return all the orders from that side ('B' bid or 'O' offer and Level)  of the book, in level- and time-order based on Side
        public List<Order> GetOrders(string side)
        {
            if ((side.ToLower()).Equals(OrderSide.BID.Label) || side.ToLower().Equals(OrderSide.OFFER.Label))
            {
                List<Order> orders = ordersBySide[side.ToLower()];
                if (orders == null)
                {
                    return new LinkedList<Order>();
                }
                return new LinkedList<Order>(orders);
            }
            else
            {
                return new LinkedList<Order>();
            }
        }
        
        
        
        
        
        
    }
}