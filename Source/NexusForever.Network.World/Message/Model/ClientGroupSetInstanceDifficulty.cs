using NexusForever.Network.Message;
using NexusForever.Network.World.Message.Model.Shared;

namespace NexusForever.Network.World.Message.Model
{
    [Message(GameMessageOpcode.ClientGroupSetInstanceDifficulty)]
    public class ClientGroupSetInstanceDifficulty : IReadable
    {
        public ulong GroupId { get; private set; }
        public InstanceDifficulty Difficulty { get; private set; }

        public void Read(GamePacketReader reader)
        {
            GroupId = reader.ReadULong();
            Difficulty = (InstanceDifficulty)reader.ReadByte(2);
        }
    }
}
