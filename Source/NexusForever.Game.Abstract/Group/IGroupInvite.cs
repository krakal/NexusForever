using NexusForever.Game.Static.Group;
using NexusForever.Network.World.Message.Model.Shared;

namespace NexusForever.Game.Abstract.Group
{
    public interface IGroupInvite
    {
        double ExpirationTime { get; set; }
        IGroup Group { get; }
        PlayerIdentity InviteeIdentity { get; }
        string InviteeName { get; }
        ulong InviteId { get; }
        IGroupMember Inviter { get; }
        GroupInviteType Type { get; }
    }
}