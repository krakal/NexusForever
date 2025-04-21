using NexusForever.Game.Abstract.Entity;
using NexusForever.Game.Abstract.Group;
using NexusForever.Network.Message;
using NexusForever.Network.World.Message.Model;

namespace NexusForever.WorldServer.Network.Message.Handler.Group
{
    public class ClientZoneMapPingHandler : IMessageHandler<IWorldSession, ClientZoneMapPing>
    {
        public void HandleMessage(IWorldSession session, ClientZoneMapPing clientPing)
        {
            IPlayer pingMaker = session.Player;
            IGroup group = null;
            
            if (pingMaker.GroupMembershipForeground != null)
            {
                group = pingMaker.GroupMembershipForeground.Group;
            }
            else if (pingMaker.GroupMembershipBackground != null)
            {
                group = pingMaker.GroupMembershipBackground.Group;
            }
            else
            {
                return;
            }

            group.BroadcastPacket(new ServerZoneMapPing
            {
                Invoker = clientPing.Invoker,
                PingLocation = clientPing.PingLocation
            });
        }
    }
}