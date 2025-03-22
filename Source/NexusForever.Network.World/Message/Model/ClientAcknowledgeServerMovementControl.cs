using NexusForever.Network.Message;

namespace NexusForever.Network.World.Message.Model
{
    [Message(GameMessageOpcode.ClientAcknowledgeServerMovementControl)]
    public class ClientAcknowledgeServerMovementControl : IReadable
    {
        public uint Ticket { get; set; } = 0;

        public void Read(GamePacketReader reader)
        {
            Ticket = reader.ReadUInt();
        }
    }
}
