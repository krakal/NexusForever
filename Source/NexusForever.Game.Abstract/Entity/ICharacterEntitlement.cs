using NexusForever.Database.Character;
using NexusForever.Game.Abstract.Entitlement;
using NexusForever.Network.Message;

namespace NexusForever.Game.Abstract.Entity
{
    public interface ICharacterEntitlement : IEntitlement, INetworkBuildable<ServerEntitlement>, IDatabaseCharacter
    {
    }
}