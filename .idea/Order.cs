using System;

namespace com.order
{
    //Define properties of the object Order, Our order object will contain an id, price, side and timestamp
    public class Order{


        private String id;
        private double price;
        private string side;
        private long size;
        private  LocalDateTime timestamp;


        public Order(String id, double price, String side, long size, LocalDateTime timestamp)
        {
            this.id = id;
            this.price = price;
            this.side = side;
            this.size = size;
            this.timestamp =timestamp;
        }
    
        public String getId() {
            return id;
        }

        public double getPrice() {
            return price;
        }

        public String getSide() {
            return side;
        }

        public long getSize() {
            return size;
        }

        public LocalDateTime getTimestamp() {
            return timestamp;
        }
    
    

    }
}

