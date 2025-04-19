using NexusForever.Game.Abstract.Group;
using NexusForever.Game.Group;
using NexusForever.Game.Static.Group;
using NexusForever.Network.Message;
using NexusForever.Network.World.Message.Model;

namespace NexusForever.WorldServer.Network.Message.Handler.Group
{
    public class ClientGroupInviteResponseHandler : IMessageHandler<IWorldSession, ClientGroupInviteResponse>
    {
        /// <summary>
        /// </summary>
        public void HandleMessage(IWorldSession session, ClientGroupInviteResponse response)
        {
            IGroup joinedGroup = GroupManager.Instance.GetGroupById(response.GroupId);
            if (joinedGroup == null)
            {
                GroupHandler.SendGroupResult(session, GroupResult.GroupNotFound, response.GroupId, session.Player.Name);
                return;
            }

            // Check if the targeted player declined the group invite.
            if (response.Result == GroupInviteResponse.Declined)
            {
                joinedGroup.DeclineInvite(session.Player.GroupInvite);
                return;
            }

            // Check if the Player can join the group
            if (!joinedGroup.CanJoinGroup(out GroupResult result))
            {
                GroupHandler.SendGroupResult(session, result, joinedGroup.Id, session.Player.Name);
                return;
            }

            joinedGroup.AcceptInvite(session.Player.GroupInvite);
        }
    }
}


