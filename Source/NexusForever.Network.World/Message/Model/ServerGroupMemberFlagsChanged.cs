using NexusForever.Network.Message;
using NexusForever.Network.World.Message.Model.Shared;
using NexusForever.Game.Static.Group;

namespace NexusForever.Network.World.Message.Model
{
    [Message(GameMessageOpcode.ServerGroupMemberFlagsChanged)]
    public class ServerGroupMemberFlagsChanged : IWritable
    {
        public ulong GroupId { get; set; }
        public uint Unused { get; set; } // Unpacked but unused by Client
        public PlayerIdentity MemberIdentity { get; set; } = new PlayerIdentity();
        public GroupMemberInfoFlags ChangedFlags { get; set; }
        public bool IsFromPromotion { get; set; }

        public void Write(GamePacketWriter writer)
        {
            writer.Write(GroupId);
            writer.Write(Unused);
            MemberIdentity.Write(writer);
            writer.Write(ChangedFlags, 32);
            writer.Write(IsFromPromotion);
        }
    }
}
