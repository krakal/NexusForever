using NexusForever.Network.Message;

namespace NexusForever.Network.World.Message.Model
{
    [Message(GameMessageOpcode.ClientPurchaseFlightPathTakeShuttle)]
    public class ClientPurchaseFlightPathTakeShuttle : IReadable
    {
        public uint[] TaxiNodeId { get; private set; } // When array length is 1, the value is a TaxiRouteId for TakeShuttle 

        public void Read(GamePacketReader reader)
        {
            uint count = reader.ReadUInt();
            for (uint i = 0; i < count; i++)
            {
                TaxiNodeId[i] = reader.ReadUInt();
            }
        }
    }
}
