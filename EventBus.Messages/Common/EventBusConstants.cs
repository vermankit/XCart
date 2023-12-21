using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Common
{
    public class EventBusConstants
    {
        public const string OrderPlacedQueue = "orderplaced-queue";
        public const string OrderUpdatedQueue = "orderupdated-queue";
        public const string OrderCreatedQueue = "ordercreated-queue";
    }
}
