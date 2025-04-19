using NexusForever.Network.Message;
using NexusForever.Network.World.Message.Model.Shared;

namespace NexusForever.Network.World.Message.Model
{
    [Message(GameMessageOpcode.ServerGroupMentoringResult)]
    public class ServerGroupMentoringResult : IWritable
    {
        public ulong GroupId { get; set; }
        public uint Unused { get; set; } // Unpacked but unused by client
        public PlayerIdentity Mentor { get; set; } = new PlayerIdentity();
        public PlayerIdentity Mentee { get; set; } = new PlayerIdentity();
        public bool Cancelled { get; set; } // Set when mentoring is cancelled, otherwise 0

        public void Write(GamePacketWriter writer)
        {
            writer.Write(GroupId);
            writer.Write(Unused);
            Mentor.Write(writer);
            Mentee.Write(writer);
            writer.Write(Cancelled);
        }
    }
}
