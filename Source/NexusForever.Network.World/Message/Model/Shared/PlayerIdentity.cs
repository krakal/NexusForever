using NexusForever.Network.Message;

namespace NexusForever.Network.World.Message.Model.Shared
{
    public class PlayerIdentity : IReadable, IWritable
    {
        public ushort RealmId { get; private set; }
        public ulong CharacterId { get; private set; }

        public PlayerIdentity()
        {
            RealmId = 0;
            CharacterId = 0;
        }

        public PlayerIdentity(ushort realmId, ulong characterId)
        {
            RealmId = realmId;
            CharacterId = characterId;
        }

        public bool Equals(PlayerIdentity other)
        {
            if (other is null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return RealmId == other.RealmId && CharacterId == other.CharacterId;
        }

        public void Read(GamePacketReader reader)
        {
            RealmId = reader.ReadUShort(14u);
            CharacterId = reader.ReadULong();
        }

        public void Write(GamePacketWriter writer)
        {
            writer.Write(RealmId, 14u);
            writer.Write(CharacterId);
        }
    }
}
