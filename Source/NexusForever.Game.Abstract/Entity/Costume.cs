
namespace NexusForever.Game.Abstract.Entity
{
    public class Costume
    {
        public const byte MaxCostumeItems = 7;

        public uint Index { get; set; }
        public uint Mask { get; set; }
        public byte MannequinIndex { get; set; }
        public uint[] ItemIds { get; set; } = new uint[7];
        public int[] DyeData { get; set; } = new int[7];
    }
}
