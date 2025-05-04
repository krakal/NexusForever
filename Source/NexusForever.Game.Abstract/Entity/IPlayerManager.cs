using NexusForever.Game.Static.Entity;

namespace NexusForever.Game.Abstract.Entity
{
    public interface IPlayerManager : IEnumerable<IPlayer>
    {
        /// <summary>
        /// Add new <see cref="IPlayer"/>.
        /// </summary>
        void AddPlayer(IPlayer player);

        /// <summary>
        /// Remove existing <see cref="IPlayer"/>.
        /// </summary>
        void RemovePlayer(IPlayer player);

        /// <summary>
        /// Returns <see cref="IPlayer"/> with supplied character identity.
        /// </summary>
        IPlayer GetPlayer(PlayerIdentity identity);

        /// <summary>
        /// Returns <see cref="IPlayer"/> with supplied character id, assumes RealmId is this realm.
        /// </summary>
        IPlayer GetPlayer(ulong characterId);

        /// <summary>
        /// Return <see cref="IPlayer"/> with supplied character name.
        /// </summary>
        IPlayer GetPlayer(string name);
    }
}