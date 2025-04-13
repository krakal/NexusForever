using NexusForever.Network.World.Message.Model.Shared;

namespace NexusForever.Network.World.Entity.Model
{
    public class TaxiEntityModel : IEntityModel
    {
        public uint CreatureId { get; set; }
        public ushort UnitVehicleId { get; set; }
        public uint OwnerId { get; set; }
        public List<VehiclePassenger> Passengers { get; set; } = new();

        public void Write(GamePacketWriter writer)
        {
            writer.Write(CreatureId, 18);
            writer.Write(UnitVehicleId, 14);
            writer.Write(OwnerId);

            writer.Write((byte)Passengers.Count, 3);
            Passengers.ForEach(s => s.Write(writer));
        }
    }
}
