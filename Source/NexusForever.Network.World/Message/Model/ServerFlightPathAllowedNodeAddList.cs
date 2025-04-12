using NexusForever.Network.Message;

namespace NexusForever.Network.World.Message.Model
{
    [Message(GameMessageOpcode.ServerFlightPathAllowedNodeAddList)]
    public class ServerFlightPathAllowedNodeAddList : IWritable
    {
        public List<uint> AllowedTaxiNodeIds { get; set; }

        public void Write(GamePacketWriter writer)
        {
            writer.Write(AllowedTaxiNodeIds.Count);
            foreach (var nodeId in AllowedTaxiNodeIds)
            {
                writer.Write(nodeId);
            }
        }
    }
}