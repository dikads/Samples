namespace RabbitCompeatingConsumers.Subscriber
{
    using NServiceBus;

    public class UnobtrusiveMessageConventions : IWantToRunBeforeConfiguration
    {
        public void Init()
        {
            Configure.Instance
                .UseInMemoryTimeoutPersister()
                .DefiningCommandsAs(
                    t =>
                        t.Namespace != null && t.Namespace.StartsWith("RabbitCompeatingConsumers") &&
                        t.Namespace.EndsWith("Commands"))
                .DefiningEventsAs(
                    t =>
                        t.Namespace != null && t.Namespace.StartsWith("RabbitCompeatingConsumers") &&
                        t.Namespace.EndsWith("Events"));
        }
    }
}