using NexusForever.Game.Abstract.Group;
using NexusForever.Game.Static.Group;
using NexusForever.Network.World.Message.Model.Shared;

namespace NexusForever.Game.Group
{
    public class GroupInvite : IGroupInvite
    {
        public const double InviteTimeout = 30d;

        public ulong InviteId { get; }
        public IGroup Group { get; }
        public PlayerIdentity InviteeIdentity { get; }
        public string InviteeName { get; }
        public IGroupMember Inviter { get; }
        public GroupInviteType Type { get; }
        public double ExpirationTime { get; set; } = InviteTimeout;

        /// <summary>
        /// Creates an instance of <see cref="GroupInvite"/>
        /// </summary>
        public GroupInvite(ulong id, IGroup group, PlayerIdentity inviteeIdentity, string inviteeName, IGroupMember inviter, GroupInviteType type)
        {
            InviteId = id;
            Group = group;
            InviteeIdentity = inviteeIdentity;
            InviteeName = inviteeName;
            Inviter = inviter;
            Type = type;
        }
    }
}
