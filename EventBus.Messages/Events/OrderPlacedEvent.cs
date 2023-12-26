namespace EventBus.Messages.Events
{
    public class OrderPlacedEvent : IntegrationBaseEvent
    {
        public string CustomerId { get; set; }
        public List<int> ProductIds { get; set; }
    }
}
