using NexusForever.Game.Static.Entity;

namespace NexusForever.Game.Abstract.Entity
{
    public class BuybackItem
    {
        public uint UniqueId { get; set; }
        public uint ItemId { get; set; }
        public uint Quantity { get; set; }
        public ulong Unk3 { get; set; }
        public uint Unk4 { get; set; }
        public ulong Unk5 { get; set; }
        public ulong Unk6 { get; set; }
        public uint Unk7 { get; set; }
        public byte[] Unk8 { get; set; } = new byte[20];
        public byte[] Unk9 { get; set; } = new byte[32];
        public CurrencyType[] CurrencyTypeId { get; set; } = new CurrencyType[2];
        public ulong[] CurrencyAmount { get; set; } = new ulong[2];
        public uint UnkE { get; set; }
    }
}
