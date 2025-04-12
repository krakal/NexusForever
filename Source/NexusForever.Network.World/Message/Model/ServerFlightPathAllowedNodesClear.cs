using NexusForever.Network.Message;

namespace NexusForever.Network.World.Message.Model
{
    [Message(GameMessageOpcode.ServerFlightPathAllowedNodesClear)]
    public class ServerFlightPathAllowedNodesClear : IWritable
    {
        // Zero length message
        public void Write(GamePacketWriter writer)
        {
        }
    }
}