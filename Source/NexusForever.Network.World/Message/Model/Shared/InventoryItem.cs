using NexusForever.Game.Static;
using NexusForever.Network.Message;

namespace NexusForever.Network.World.Message.Model.Shared
{
    public class InventoryItem : IWritable
    {
        public Item Item { get; set; }
        public ItemUpdateReason Reason { get; set; }

        public void Write(GamePacketWriter writer)
        {
            Item.Write(writer);
            writer.Write(Reason, 6u);
        }
    }
}
