using NexusForever.Network.Message;
using NexusForever.Network.World.Message.Model.Shared;

namespace NexusForever.Network.World.Message.Model
{
    [Message(GameMessageOpcode.ClientGroupSwapOrder)]
    public class ClientGroupSwapOrder : IReadable
    {
        public ulong Groupid { get; private set; }
        public PlayerIdentity MemberA { get; private set; } = new PlayerIdentity();
        public PlayerIdentity MemberB { get; private set; } = new PlayerIdentity();

        public void Read(GamePacketReader reader)
        {
            Groupid = reader.ReadULong();
            MemberA.Read(reader);
            MemberB.Read(reader);
        }
    }
}