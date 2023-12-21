namespace EventBus.Messages.Events
{
    public class IntegrationBaseEvent
    {
        public Guid Id { get; private set; }
        public DateTime CreatedDate { get; private set; }

        public IntegrationBaseEvent()
        {
            Id = Guid.NewGuid();   
            CreatedDate = DateTime.Now;
        }
        public IntegrationBaseEvent(DateTime createdDate, Guid id)
        {
            CreatedDate = createdDate;
            Id = id;
        }
    }
}
