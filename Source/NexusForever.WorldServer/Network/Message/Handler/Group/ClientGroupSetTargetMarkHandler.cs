using NexusForever.Game.Abstract.Group;
using NexusForever.Game.Group;
using NexusForever.Game.Static.Group;
using NexusForever.Network.Message;
using NexusForever.Network.World.Message.Model;

namespace NexusForever.WorldServer.Network.Message.Handler.Group
{
    public class ClientGroupSetTargetMarkHandler : IMessageHandler<IWorldSession, ClientGroupSetTargetMark>
    {
        /// <summary>
        /// </summary>
        public void HandleMessage(IWorldSession session, ClientGroupSetTargetMark clientMark)
        {
            // Players can only mark for their Active group.
            ulong groupId = session.Player.GroupMembership1.Group.Id;
            IGroup group = GroupManager.Instance.GetGroupById(groupId);
            if (group == null)
            {
                GroupHandler.SendGroupResult(session, GroupResult.GroupNotFound, groupId, session.Player.Name);
                return;
            }

            GroupHandler.AssertPermission(session, groupId, GroupMemberInfoFlags.CanMark);
            group.MarkUnit(clientMark.UnitId, clientMark.TargetMarkerId);
        }
    }
}