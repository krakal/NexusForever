using NexusForever.Network.Message;

namespace NexusForever.Network.World.Message.Model
{
    [Message(GameMessageOpcode.ClientCastRapidTransport)]
    public class ClientCastRapidTransport : IReadable
    {
        public ushort TaxiNodeId { get; private set; }
        public uint ClientSpellCastUniqueId { get; private set; }

        public void Read(GamePacketReader reader)
        {
            TaxiNodeId = reader.ReadUShort(14u);
            ClientSpellCastUniqueId = reader.ReadUInt();
        }
    }
}
