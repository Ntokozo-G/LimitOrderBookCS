using System;

namespace Order
{
    //Unique Id generator, this is a helper class and generates a uniques id for each order so we can be able to identify
    //each unique order when we have to modify or delete from the orderbook
    public class UniqueIdGenerator
    {
        public string GetId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}