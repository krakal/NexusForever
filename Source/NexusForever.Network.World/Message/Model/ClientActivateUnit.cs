using NexusForever.ModelMigration;
using NexusForever.Network.Message;

namespace NexusForever.Network.World.Message.Model
{
    [Message(GameMessageOpcode.ClientActivateUnit)]
    public class ClientActivateUnit : ClientActivateUnitModel, IReadable
    {
        public void Read(GamePacketReader reader)
        {
            UnitId  = reader.ReadUInt();
        }
    }
}
