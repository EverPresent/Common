namespace Common.Messaging
{
    public interface IMessagingDetailsSetup : ICommonProgramSetup
    {
        IMessagingDetailsSetup BindEvent<TConsumer>(string exchange, string queue);
        IMessagingDetailsSetup BindCommand<TConsumer>(string exchange, string queue);
        IMessagingDetailsSetup AlsoPublishes<T>();
    }
}
