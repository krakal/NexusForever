using NexusForever.Game.Abstract.Entity;
using NexusForever.Game.Abstract.Group;
using NexusForever.Game.Entity;
using NexusForever.Game.Static.Group;
using NexusForever.Network.World.Message.Model;
using NexusForever.Network.World.Message.Model.Shared;
using System.ComponentModel;
using NetworkGroupMember = NexusForever.Network.World.Message.Model.Shared.GroupMember;

namespace NexusForever.Game.Group
{
    public class GroupMember : IGroupMember
    {
        public ulong Id { get; }
        public IGroup Group { get; }
        public PlayerIdentity Identity { get; }
        public PlayerIdentity Mentee { get; private set; }
        public List<PlayerIdentity> Mentors { get; private set; }
        public ushort ZoneId { get; set; }
        public uint GroupIndex { get { return Group.GetMemberIndex(this); } }

        private GroupMemberInfoFlags flags;

        public bool IsPartyLeader => Group.Leader?.Identity == Identity;
        public bool CanKick => (Flags & GroupMemberInfoFlags.CanKick) != 0;
        public bool CanInvite => (Flags & GroupMemberInfoFlags.CanInvite) != 0;
        public bool CanMark => (Flags & GroupMemberInfoFlags.CanMark) != 0;
        public bool CanReadyCheck => (Flags & GroupMemberInfoFlags.CanReadyCheck) != 0;

        private bool AreFlagsSet;

        public GroupMember(ulong id, IGroup group, IPlayer player)
        {
            Id = id;
            Group = group;
            Identity = player.Identity;
            ZoneId = (ushort)player.Zone.Id;
            AreFlagsSet = false;
        }

        /// <summary>
        /// Generate Info flags that can be sent to the client.
        /// </summary>
        public GroupMemberInfoFlags Flags
        {
            get
            {
                if (!AreFlagsSet)
                    SetInitialFlags();

                return flags;
            }
            set { flags = value; }
        }

        /// <summary>
        /// Can this member update given flags for the given member?
        /// </summary>
        public bool CanUpdateFlags(GroupMemberInfoFlags updateFlags, IGroupMember other)
        {
            if (IsPartyLeader)
                return true;

            // If we are role locked and we are not the leader, we cannot update the flags.
            if (flags.HasFlag(GroupMemberInfoFlags.RoleLocked))
                return false;

            if ((flags & GroupMemberInfoFlags.RaidAssistant) != 0)
                return true;

            if (other.Id != Id)
                return false;

            GroupMemberInfoFlags allowedFlags = GroupMemberInfoFlags.RoleFlags
                             | GroupMemberInfoFlags.HasSetReady
                             | GroupMemberInfoFlags.Ready;
            return (updateFlags & allowedFlags) == updateFlags;
        }

        /// <summary>
        /// Clear ready check related flags
        /// </summary>
        public void PrepareForReadyCheck()
        {
            GroupMemberInfoFlags unset = GroupMemberInfoFlags.HasSetReady
                      | GroupMemberInfoFlags.Ready;
            flags &= ~unset;
            flags |= GroupMemberInfoFlags.Pending;
        }

        /// <summary>
        /// Toggle flags on/off.
        /// </summary>
        public void SetFlags(GroupMemberInfoFlags flags, bool value)
        {
            if (value && (flags & GroupMemberInfoFlags.RoleFlags) != 0)
                this.flags &= ~GroupMemberInfoFlags.RoleFlags;

            if (value && (flags & GroupMemberInfoFlags.HasSetReady) != 0)
                this.flags &= ~GroupMemberInfoFlags.Pending;

            if (value)
                this.flags |= flags;
            else
                this.flags &= ~flags;
        }

        private void SetInitialFlags()
        {
            AreFlagsSet = true;
            if (IsPartyLeader)
                flags |= GroupMemberInfoFlags.GroupAdminFlags;
            else
                flags |= GroupMemberInfoFlags.GroupMemberFlags;
        }

        /// <summary>
        /// Build the <see cref="NetworkGroupMember"/>.
        /// </summary>
        public NetworkGroupMember Build()
        {
            IPlayer targetPlayer = PlayerManager.Instance.GetPlayer(Identity);
            if (targetPlayer == null)
                return null;

            return targetPlayer.BuildGroupMember();
        }

        /// <summary>
        /// Build the <see cref="GroupMemberInfo"/> model.
        /// </summary>
        public GroupMemberInfo BuildMemberInfo()
        {
            return new GroupMemberInfo
            {
                MemberIdentity = Identity,
                Flags = Flags,
                GroupIndex = GroupIndex,
                Member = Build()
            };
        }

        /// <summary>
        /// Build <see cref="ServerEntityGroupAssociation"/>
        /// </summary>
        public ServerEntityGroupAssociation BuildGroupAssociation()
        {
            IPlayer targetPlayer = PlayerManager.Instance.GetPlayer(Identity);
            if (targetPlayer == null)
                return null;

            return new ServerEntityGroupAssociation
            {
                UnitId = targetPlayer.Guid,
                GroupId = Group.Id
            };
        }

        /// <summary>
        /// Build <see cref="ServerGroupMemberStatUpdate"/>
        /// </summary>
        public ServerGroupMemberStatUpdate BuildGroupStatUpdate()
        {
            IPlayer player = PlayerManager.Instance.GetPlayer(Identity);
            if (player == null)
                return null;

            return new ServerGroupMemberStatUpdate
            {
                GroupId = Group.Id,
                GroupMemberId = (ushort)Id,
                TargetPlayer = Identity,
                Level = (byte)player.Level,
                EffectiveLevel = (byte)player.Level,
                Health = (ushort)player.Health,
                HealthMax = (ushort)player.HealthMax,
                ShieldCapacity = (ushort)player.Shield,
                ShieldCapacityMax = (ushort)player.ShieldCapacityMax,
                InterruptArmor = (ushort)player.InterruptArmor,
                InterruptArmorMax = (ushort)player.InterruptArmorMax,
                Path = player.Path
            };
        }

        public bool SetMentee(PlayerIdentity mentee)
        {
            if (Mentee != null)
            {

                return false;
            }

            return true;
        }
    }
}
