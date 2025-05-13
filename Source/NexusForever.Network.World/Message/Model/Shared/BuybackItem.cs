using NexusForever.Game.Static.Entity;
using NexusForever.Network.Message;

namespace NexusForever.Network.World.Message.Model.Shared
{
    public class BuybackItem : Game.Abstract.Entity.BuybackItem, IWritable
    {
        public void Write(GamePacketWriter writer)
        {
            writer.Write(UniqueId);
            writer.Write(ItemId, 18u);
            writer.Write(Quantity);
            writer.Write(Unk3);
            writer.Write(Unk4);
            writer.Write(Unk5);
            writer.Write(Unk6);
            writer.Write(Unk7, 18u);
            writer.WriteBytes(Unk8, 20u);
            writer.WriteBytes(Unk9, 32u);

            writer.Write(CurrencyAmount, 2u);
            foreach (CurrencyType type in CurrencyTypeId)
                writer.Write(type, 4u);

            writer.Write(UnkE);
        }
    }
}
