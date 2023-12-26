namespace EventBus.Messages.Common
{
    public class EventBusConstants
    {
        /// <summary>
        /// Queue for notification service 1
        /// </summary>
        public const string OrderPlacedQueue1 = "orderplaced-queue-1";//fan - out exchange
        /// <summary>
        /// Queue for notification service 2
        /// </summary>
        public const string OrderPlacedQueue2 = "orderplaced-queue-2";//fan - out exchange
        public const string OrderUpdatedQueue = "orderupdated-queue";// topic exchange
    }
}
