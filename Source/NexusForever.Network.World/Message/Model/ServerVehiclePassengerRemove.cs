using NexusForever.Network.Message;

namespace NexusForever.Network.World.Message.Model
{
    [Message(GameMessageOpcode.ServerVehiclePassengerRemove)]
    public class ServerVehiclePassengerRemove : IWritable
    {
        public uint VehicleUnitId { get; set; }
        public uint PassengerUnitId { get; set; }

        public void Write(GamePacketWriter writer)
        {
            writer.Write(VehicleUnitId);
            writer.Write(PassengerUnitId);
        }
    }
}
