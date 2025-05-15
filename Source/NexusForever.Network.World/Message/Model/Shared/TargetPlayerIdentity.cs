using NexusForever.Network.Message;

namespace NexusForever.Network.World.Message.Model.Shared
{
    public class TargetPlayerIdentity : Game.Migration.Entity.Identity, IReadable, IWritable
    {
        public TargetPlayerIdentity() : base()
        {
        }

        public TargetPlayerIdentity(ushort realmId, ulong characterId)
            : base(realmId, characterId)
        {
        }

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
