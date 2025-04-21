using NexusForever.Game.Abstract.Entity;
using NexusForever.ModelMigration;
using NexusForever.Network;
using NexusForever.Network.Message;

namespace NexusForever.WorldServer.Network.Message.Handler.Entity
{
    public class ClientActivateUnitHandler : IMessageHandler<IWorldSession, ClientActivateUnitModel>
    {
        public void HandleMessage(IWorldSession session, ClientActivateUnitModel activateUnit)
        {
            IWorldEntity entity = session.Player.GetVisible<IWorldEntity>(activateUnit.UnitId);
            if (entity == null)
                throw new InvalidPacketValueException();

            // TODO: sanity check for range etc.

            entity.OnActivate(session.Player);
        }
    }
}
