using NexusForever.Network.Session;
using NexusForever.ModelMigration;

namespace NexusForever.Network.Message
{
    public interface IMessageHandler<in TSession, in TMessage>
        where TSession : IGameSession
        where TMessage : IMessageModel
    {
        void HandleMessage(TSession session, TMessage packet);
    }
}
