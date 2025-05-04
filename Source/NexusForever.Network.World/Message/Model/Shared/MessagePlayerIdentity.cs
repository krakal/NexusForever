using NexusForever.Game.Static.Entity;
using NexusForever.Network.Message;

namespace NexusForever.Network.World.Message.Model.Shared
{
    public class MessagePlayerIdentity : PlayerIdentity, IReadable, IWritable
    {
        public void Read(GamePacketReader reader)
        {
            RealmId     = reader.ReadUShort(14u);
            CharacterId = reader.ReadULong();
        }

        public void Write(GamePacketWriter writer)
        {
            writer.Write(RealmId, 14u);
            writer.Write(CharacterId);
        }
    }
}
