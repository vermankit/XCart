namespace EventBus.Messages.Events
{
    public class OrderUpdatedEvent : IntegrationBaseEvent
    {
        public string CustomerId { get; set; }
        public List<int> ProductIds { get; set; }
        public string OrderId { get; set; }
    }
}
