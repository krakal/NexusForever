using NexusForever.Game.Static.Entity;

namespace NexusForever.Game.Migration.Entity
{
    public class ItemLocation
    {
        public InventoryLocation Location { get; set; }
        public uint BagIndex { get; set; }
    }
}
