using NexusForever.Game.Static.Entity;
using NexusForever.Network.Message;

namespace NexusForever.Network.World.Message.Model
{
    [Message(GameMessageOpcode.ServerUnitMount)]
    public class ServerUnitMount : IWritable
    {
        public uint UnitId { get; set; } // The unit that is mounting
        public uint VehicleUnitId { get; set; } // The vehicle unit that is being mounted
        public VehicleSeatType SeatType { get; set; }
        public byte SeatPosition { get; set; }

        public void Write(GamePacketWriter writer)
        {
            writer.Write(UnitId);
            writer.Write(VehicleUnitId);
            writer.Write(SeatType, 2u);
            writer.Write(SeatPosition, 3u);
        }
    }
}
