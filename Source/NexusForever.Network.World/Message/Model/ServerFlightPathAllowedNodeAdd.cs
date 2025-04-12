using NexusForever.Network.Message;

namespace NexusForever.Network.World.Message.Model
{
    [Message(GameMessageOpcode.ServerFlightPathAllowedNodeAdd)]
    public class ServerFlightPathAllowedNodeAdd : IWritable
    {
        public uint TaxiNodeId { get; set; }

        public void Write(GamePacketWriter writer)
        {
            writer.Write(TaxiNodeId, 14);
        }
    }
}