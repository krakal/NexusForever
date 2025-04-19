using NexusForever.Network.Message;
using NexusForever.Network.World.Message.Model.Shared;

namespace NexusForever.Network.World.Message.Model
{
    [Message(GameMessageOpcode.ClientCloseMentoringAOIDialog)]
    public class ClientCloseMentoringAOIDialog : IReadable
    {
        public ulong GroupId { get; private set; }
        public PlayerIdentity Identity { get; private set; } = new PlayerIdentity();

        public void Read(GamePacketReader reader)
        {
            GroupId = reader.ReadULong();
            Identity.Read(reader);
        }
    }
}
