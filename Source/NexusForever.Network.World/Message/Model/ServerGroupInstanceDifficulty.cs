using NexusForever.Network.Message;
using NexusForever.Network.World.Message.Model.Shared;

namespace NexusForever.Network.World.Message.Model
{
    [Message(GameMessageOpcode.ServerGroupInstanceDifficulty)]
    public class ServerGroupInstanceDifficulty : IWritable
    {
        public ulong GroupId { get; set; }
        public uint Unknown { get; set; } // Unpacked but unused by Client
        public InstanceDifficulty Difficulty { get; set; }

        public void Write(GamePacketWriter writer)
        {
            writer.Write(GroupId);
            writer.Write(Unknown);
            writer.Write(Difficulty, 2);
        }
    }
}
