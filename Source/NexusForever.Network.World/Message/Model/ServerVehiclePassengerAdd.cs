using NexusForever.Network.Message;
using NexusForever.Network.World.Message.Model.Shared;

namespace NexusForever.Network.World.Message.Model
{
    [Message(GameMessageOpcode.ServerVehiclePassengerAdd)]
    public partial class ServerVehiclePassengerAdd : IWritable
    {
        public uint VehicleUnitId { get; set; }
        public VehiclePassenger Passenger { get; set; }

        public void Write(GamePacketWriter writer)
        {
            writer.Write(VehicleUnitId);
            Passenger.Write(writer);
        }
    }
}
