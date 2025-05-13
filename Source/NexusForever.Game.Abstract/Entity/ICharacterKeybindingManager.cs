using NexusForever.Database.Character;
using NexusForever.Game.Abstract.General;
using NexusForever.Network.Message;

namespace NexusForever.Game.Abstract.Entity
{
    public interface ICharacterKeybindingManager : IDatabaseCharacter, INetworkBuildable<BiInputKeySet>
    {
        void Update(BiInputKeySet inputKeySet);
    }
}
