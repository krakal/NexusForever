using NexusForever.Database.Auth;
using NexusForever.Game.Abstract.General;
using NexusForever.Network.Message;

namespace NexusForever.Game.Abstract.Account.Setting
{
    public interface IAccountKeybindingManager : IDatabaseAuth, INetworkBuildable<BiInputKeySet>
    {
        void Update(BiInputKeySet inputKeySet);
    }
}
