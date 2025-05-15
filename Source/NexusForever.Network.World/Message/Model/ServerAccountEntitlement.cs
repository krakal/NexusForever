using NexusForever.Network.Message;

namespace NexusForever.Network.World.Message.Model
{
    [Message(GameMessageOpcode.ServerAccountEntitlement)]
    public class ServerAccountEntitlement : Game.Migration.Entitlement.ServerAccountEntitlement, IWritable
    {
        public void Write(GamePacketWriter writer)
        {
            writer.Write(Entitlement, 32u);
            writer.Write(Count);
        }
    }
}
