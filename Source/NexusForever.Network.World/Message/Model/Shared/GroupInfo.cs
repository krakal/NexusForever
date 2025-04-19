using NexusForever.Network.Message;
using NexusForever.Game.Static.Group;

namespace NexusForever.Network.World.Message.Model.Shared
{
    public class GroupInfo : IWritable
    {
        public ulong GroupId { get; set; }
        public GroupFlags Flags { get; set; }
        public List<GroupMemberInfo> MemberInfos { get; set; } = new List<GroupMemberInfo>();
        public uint MaxGroupSize { get; set; }

        public LootRule LootRule { get; set; }
        public LootRule LootThresholdRule { get; set; }
        public LootThreshold LootThresholdQuality { get; set; }
        public HarvestLootRule LootRuleHarvest { get; set; }

        public PlayerIdentity Leader { get; set; } = new PlayerIdentity();
        public ushort RealmId { get; set; }     //< Why again? Tf?

        public GroupMarkerInfo MarkerInfo { get; set; }

        public void Write(GamePacketWriter writer)
        {
            writer.Write(GroupId);
            writer.Write(Flags, 32);
            writer.Write(MemberInfos.Count);
            writer.Write(MaxGroupSize);

            writer.Write(LootRule, 3u);
            writer.Write(LootThresholdRule, 3u);
            writer.Write(LootThresholdQuality, 4u);
            writer.Write(LootRuleHarvest, 2u);

            MemberInfos.ForEach(member => member.Write(writer));

            Leader.Write(writer);
            writer.Write(RealmId, 14);

            MarkerInfo.Write(writer);
        }
    }
}
