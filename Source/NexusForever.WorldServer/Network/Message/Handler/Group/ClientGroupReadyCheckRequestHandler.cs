using NexusForever.Game.Abstract.Group;
using NexusForever.Game.Group;
using NexusForever.Game.Static.Group;
using NexusForever.Network.Message;
using NexusForever.Network.World.Message.Model;

namespace NexusForever.WorldServer.Network.Message.Handler.Group
{
    public class ClientGroupReadyCheckRequestHandler : IMessageHandler<IWorldSession, ClientGroupReadyCheckRequest>
    {
        /// <summary>
        /// </summary>
        public void HandleMessage(IWorldSession session, ClientGroupReadyCheckRequest readyCheckRequest)
        {
            GroupHandler.AssertGroupId(session, readyCheckRequest.GroupId);

            IGroup group = GroupManager.Instance.GetGroupById(readyCheckRequest.GroupId);
            if (group == null)
            {
                GroupHandler.SendGroupResult(session, GroupResult.GroupNotFound, readyCheckRequest.GroupId, session.Player.Name);
                return;
            }

            if (group.IsRaid && !session.Player.GroupMembership1.IsPartyLeader)
                GroupHandler.AssertPermission(session, group.Id, GroupMemberInfoFlags.CanReadyCheck);
            else
                GroupHandler.AssertGroupLeader(session, group.Id);

            group.PrepareForReadyCheck();
            group.PerformReadyCheck(session.Player, readyCheckRequest.Message);
        }
    }
}