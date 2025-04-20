using NexusForever.Game.Abstract.Entity;
using NexusForever.Game.Abstract.Group;
using NexusForever.Game.Entity;
using NexusForever.Game.Group;
using NexusForever.Game.Static.Group;
using NexusForever.Network.Message;
using NexusForever.Network.World.Message.Model;

namespace NexusForever.WorldServer.Network.Message.Handler.Group
{
    public class ClientGroupInviteHandler : IMessageHandler<IWorldSession, ClientGroupInvite>
    {
        /// <summary>
        /// </summary>
        public void HandleMessage(IWorldSession session, ClientGroupInvite groupInvite)
        {
            IPlayer targetedPlayer = PlayerManager.Instance.GetPlayer(groupInvite.InviteeName);
            if (targetedPlayer == null)
            {
                GroupHandler.SendGroupResult(session, GroupResult.PlayerNotFound, targetPlayerName: groupInvite.InviteeName);
                return;
            }

            // Check if targeted player is already grouped in a Group1 they cannot be re-invited, only instance finder can create an instance group.
            if (targetedPlayer.GroupMembership1 != null)
            {
                GroupHandler.SendGroupResult(session, GroupResult.Grouped, targetPlayerName: groupInvite.InviteeName);
                return;
            }

            // Check if inviter faction is same as invited faction.
            if (targetedPlayer.Faction1 != session.Player.Faction1)
            {
                GroupHandler.SendGroupResult(session, GroupResult.WrongFaction, targetPlayerName: groupInvite.InviteeName);
                return;
            }

            // Player is already being invited by another group/player
            if (targetedPlayer.GroupInvite != null)
            {
                GroupHandler.SendGroupResult(session, GroupResult.Pending, targetPlayerName: groupInvite.InviteeName);
                return;
            }

            // Check if the inviter is not inviting himself (pleb)
            if (targetedPlayer.Session == session)
            {
                GroupHandler.SendGroupResult(session, GroupResult.NotInvitingSelf, targetPlayerName: groupInvite.InviteeName);
                return;
            }

            // TODO(krakal): Add function that finds player amongst all groups. Just because player.GroupMembership is null does not mean they are not in a group.
            if (session.Player.GroupMembership1 == null)
            {
                // Player is not part of a group - lets create a new one and invite the new guy.
                IGroup newGroup = GroupManager.Instance.CreateGroup(session.Player);
                newGroup.Invite(session.Player, targetedPlayer);
                return;
            }

            // At this point, the player must be part of a group
            IGroup group = session.Player.GroupMembership1.Group;
            IGroupMember membership = session.Player.GroupMembership1;

            if (group.IsFull)
            {
                GroupHandler.SendGroupResult(session, GroupResult.Full, group.Id, groupInvite.InviteeName);
                return;
            }

            // The inviter is the Leader or has Invite permissions, so just do an invite.
            if (group.Leader.Id == membership.Id || membership.Flags.HasFlag(GroupMemberInfoFlags.CanInvite))
                group.Invite(session.Player, targetedPlayer);
            else // inviter is another group memeber w/o invite permissions, so we create a referal.
                group.ReferMember(membership, targetedPlayer);
        }
    }
}


