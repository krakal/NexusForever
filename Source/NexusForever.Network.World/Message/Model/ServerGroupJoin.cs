using NexusForever.Network.Message;
using NexusForever.Network.World.Message.Model.Shared;

namespace NexusForever.Network.World.Message.Model
{
    [Message(GameMessageOpcode.ServerGroupJoin)]
    public class ServerGroupJoin : IWritable
    {
        public PlayerIdentity Player { get; set; } = new PlayerIdentity();
        public GroupInfo GroupInfo { get; set; } = new GroupInfo();

        public void Write(GamePacketWriter writer)
        {
            Player.Write(writer);
            GroupInfo.Write(writer);
        }
    }
}
