
namespace NexusForever.Game.Migration.Entity
{
    public class Identity
    {
        public ushort RealmId { get; set; }
        public ulong CharacterId { get; set; }

        public Identity()
        {
        }

        public Identity(ushort realmId, ulong characterId)
        {
            RealmId = realmId;
            CharacterId = characterId;
        }
    }
}
