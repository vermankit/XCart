namespace XCart.OrderService.Entity
{
    public class Order
    {
        // Properties
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        // Constructor
        public Order(int orderId, DateTime orderDate)
        {
            OrderId = orderId;
            OrderDate = orderDate;
            OrderItems = new List<OrderItem>();
        }
    }
}
