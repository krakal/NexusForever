using NexusForever.Network.Message;
using NexusForever.Network.World.Message.Model.Shared;

namespace NexusForever.Network.World.Message.Model
{
    [Message(GameMessageOpcode.ClientGroupMentoringAccept)]
    public class ClientGroupMentoringAccept : IReadable
    {
        public ulong GroupId { get; private set; }
        public PlayerIdentity MentorIdentity { get; private set; } = new PlayerIdentity();

        public void Read(GamePacketReader reader)
        {
            GroupId = reader.ReadULong();
            MentorIdentity.Read(reader);
        }
    }
}
