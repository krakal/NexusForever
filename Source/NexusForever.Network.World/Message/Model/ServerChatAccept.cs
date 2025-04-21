using NexusForever.Network.Message;
using NexusForever.ModelMigration;

namespace NexusForever.Network.World.Message.Model
{
    [Message(GameMessageOpcode.ServerChatAccept)]
    public class ServerChatAccept : ServerChatAcceptModel, IWritable
    {
        public void Write(GamePacketWriter writer)
        {
            writer.Write(1, 16u); // Result?
            writer.Write(GM);
            writer.Write(0, 5u); // Item count

            writer.WriteStringWide(Name);
            writer.WriteStringWide(RealmName);

            writer.Write(Guid);
            writer.Write(1, 8u); // CharacterId
        }
    }
}
