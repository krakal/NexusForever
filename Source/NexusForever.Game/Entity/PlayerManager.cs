using System.Collections;
using System.Collections.Concurrent;
using NexusForever.Game.Abstract.Character;
using NexusForever.Game.Abstract.Entity;
using NexusForever.Game.Character;
using NexusForever.Game.Static.Entity;
using NexusForever.Shared;
using NLog;

namespace NexusForever.Game.Entity
{
    public sealed class PlayerManager : Singleton<PlayerManager>, IPlayerManager
    {
        private static readonly ILogger log = LogManager.GetCurrentClassLogger();

        private readonly ConcurrentDictionary<PlayerIdentity, IPlayer> players = new();

        /// <summary>
        /// Add new <see cref="IPlayer"/>.
        /// </summary>
        public void AddPlayer(IPlayer player)
        {
            players.TryAdd(player.Identity, player);
            log.Trace($"Added player {player.CharacterId}.");
        }

        /// <summary>
        /// Remove existing <see cref="IPlayer"/>.
        /// </summary>
        public void RemovePlayer(IPlayer player)
        {
            players.TryRemove(player.Identity, out _);
            log.Trace($"Removed player {player.CharacterId}.");
        }

        /// <summary>
        /// Returns <see cref="IPlayer"/> with supplied characterId.
        /// </summary>
        public IPlayer GetPlayer(ulong characterId)
        {
            PlayerIdentity identity = new PlayerIdentity
            {
                RealmId = RealmContext.Instance.RealmId, 
                CharacterId = characterId
            };
            return players.TryGetValue(identity, out IPlayer player) ? player : null;
        }

        /// <summary>
        /// Returns <see cref="IPlayer"/> with supplied character identity.
        /// </summary>
        public IPlayer GetPlayer(PlayerIdentity identity)
        {
            return players.TryGetValue(identity, out IPlayer player) ? player : null;
        }

        /// <summary>
        /// Return <see cref="IPlayer"/> with supplied character name.
        /// </summary>
        public IPlayer GetPlayer(string name)
        {
            ICharacter character = CharacterManager.Instance.GetCharacter(name);
            if (character == null)
                return null;

            return GetPlayer(character.Identity);
        }

        public IEnumerator<IPlayer> GetEnumerator()
        {
            return players.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
