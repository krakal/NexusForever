using NexusForever.Game.Static.Social;
using NexusForever.Network.Message;

namespace NexusForever.Network.World.Message.Model
{
    [Message(GameMessageOpcode.ClientAbilityAndLogOptions)]
    public class ClientAbilityAndLogOptions : IReadable
    {
        public uint TargettingAndAbilityFlags { get; private set; }
        public bool LogOtherPlayers { get; private set; }
        public uint LogOptionFlags { get; private set; }

        public void Read(GamePacketReader reader)
        {
            TargettingAndAbilityFlags = reader.ReadUInt(4);
            LogOtherPlayers = reader.ReadBit();
            LogOptionFlags = reader.ReadUInt(0xE);
        }
    }

    [Message(GameMessageOpcode.ClientAbilityOptions)]
    public class ClientAbilityOptions : IReadable
    {
        public uint TargettingAndAbilityFlags { get; private set; }
        public uint SharedChallengePreference { get; private set; }

        public void Read(GamePacketReader reader)
        {
            /*            ulong messageValue = reader.ReadULong();
                        if (messageValue > 0)
                        {
                            SharedChallengePreference = true;
                        }SharedChallengePreference
                        else
                        {
                            SharedChallengePreference = false;
                        }*/
            SharedChallengePreference = reader.ReadUInt();

            TargettingAndAbilityFlags = reader.ReadUInt();
        }
    }

    [Message(GameMessageOpcode.ClientLogOtherPlayers)]
    public class ClientLogOtherPlayers : IReadable
    {
        public bool LogOtherPlayersDisabled { get; private set; }

        public void Read(GamePacketReader reader)
        {
            uint messageValue = reader.ReadUInt();

            if(messageValue > 0)
            {
                LogOtherPlayersDisabled = true;
            } else
            {
                LogOtherPlayersDisabled = false;
            }
        }
    }

    [Message(GameMessageOpcode.ClientLogOptions)]
    public class ClientLogOptions : IReadable
    {
        // TODO: Something more clever with enum to make querying flag state easy
        // See CombatLogOptionFlags enum
        public uint LogOptionFlags { get; private set; }

        public void Read(GamePacketReader reader)
        {
            LogOptionFlags = reader.ReadUInt();
        }
    }

    [Message(GameMessageOpcode.ClientRewardRotation)]
    public class ClientRewardRotation : IReadable
    {
        public uint ContentTypeEnum { get; private set; }

        public void Read(GamePacketReader reader)
        {
            ContentTypeEnum = reader.ReadUInt();
        }
    }

    [Message(GameMessageOpcode.ClientWindowOpenStatistics)]
    public class ClientWindowOpenStatistics : IReadable
    {
        public uint Always35 { get; private set; }
        public uint Always512 { get; private set; }
        public ulong CharacterId { get; private set; }
        public ulong Always0_1 { get; private set; }
        public ulong TimeSpentOpen { get; private set; }
        public ulong Always0_2 { get; private set; }
        public ulong Always0_3 { get; private set; }
        public ulong Always0_4 { get; private set; }
        public string WindowName { get; private set; }

        public void Read(GamePacketReader reader)
        {
            Always35 = reader.ReadUInt(6);
            Always512 = reader.ReadUInt(0xA);
            CharacterId = reader.ReadULong();
            Always0_1 = reader.ReadULong();
            TimeSpentOpen = reader.ReadULong();
            Always0_2 = reader.ReadULong();
            Always0_3 = reader.ReadULong();
            Always0_4 = reader.ReadULong();
            WindowName = reader.ReadWideString();
        }
    }

    [Message(GameMessageOpcode.ClientGfxStatistics)]
    public class ClientGfxStatistics : IReadable
    {
        public float GfxStat1 { get; private set; }
        public float GfxStat2 { get; private set; }
        public float GfxStat3 { get; private set; }
        public float GfxStat4 { get; private set; }
        public float GfxStat5 { get; private set; }
        public float GfxStat6 { get; private set; }
        public float GfxStat7 { get; private set; }
        public float GfxStat8 { get; private set; }


        public void Read(GamePacketReader reader)
        {
            GfxStat1 = reader.ReadSingle();
            GfxStat2 = reader.ReadSingle();
            GfxStat3 = reader.ReadSingle();
            GfxStat4 = reader.ReadSingle();
            GfxStat5 = reader.ReadSingle();
            GfxStat6 = reader.ReadSingle();
            GfxStat7 = reader.ReadSingle();
            GfxStat8 = reader.ReadSingle();
        }
    }

    [Message(GameMessageOpcode.ClientConnectionStatistics)]
    public class ClientConnectionStatistics : IReadable
    {
        public uint NetworkStat1 { get; private set; }
        public uint NetworkStat2 { get; private set; }
        public uint NetworkStat3 { get; private set; }
        public uint NetworkStat4 { get; private set; }

        public void Read(GamePacketReader reader)
        {
            NetworkStat1 = reader.ReadUInt();
            NetworkStat2 = reader.ReadUInt();
            NetworkStat3 = reader.ReadUInt();
            NetworkStat4 = reader.ReadUInt();
        }
    }

    [Message(GameMessageOpcode.ClientFramerateStatistics)]
    public class ClientFramerateStatistics : IReadable
    {
        public uint AverageTimePerFrame { get; private set; }
        public uint HighestTimeFrame { get; private set; }
        public float Float1 { get; private set; }
        public float Float2 { get; private set; }
        public float Float3 { get; private set; }
        public float HighestFrameTimeMilliseconds { get; private set; }
        public uint MillisecondsPerFrame { get; private set; }

        public void Read(GamePacketReader reader)
        {
            AverageTimePerFrame = reader.ReadUInt();
            HighestTimeFrame = reader.ReadUInt();
            Float1 = reader.ReadSingle();
            Float2 = reader.ReadSingle();
            Float3 = reader.ReadSingle();
            HighestFrameTimeMilliseconds = reader.ReadSingle();
            MillisecondsPerFrame = reader.ReadUInt();
        }
    }

    [Message(GameMessageOpcode.ClientPlayerMovementSpeedUpdate)]
    public class ClientPlayerMovementSpeedUpdate : IReadable
    {
        // 0 = walking, 1 = running, 2 = sprinting
        public uint Speed { get; private set; }

        public void Read(GamePacketReader reader)
        {
            Speed = reader.ReadUInt();
        }
    }

    [Message(GameMessageOpcode.ClientSprint)]
    public class ClientSprint : IReadable
    {
        public bool Sprinting { get; private set; }

        public void Read(GamePacketReader reader)
        {
            Sprinting = reader.ReadBit();
        }
    }

    [Message(GameMessageOpcode.ClientDash)]
    public class ClientDash : IReadable
    {
        // forward = 1
        // back = 2
        // left = 3
        // right = 4
        public ulong DashDirection { get; private set; }

        public void Read(GamePacketReader reader)
        {
            DashDirection = reader.ReadULong(3);
        }
    }

    [Message(GameMessageOpcode.ClientMarketplaceRequestOwnedCommodityOrders)]
    public class ClientMarketplaceRequestOwnedCommodityOrders : IReadable
    {
        // Message itself is the trigger for the request. Payload is 0 bytes.
        public void Read(GamePacketReader reader)
        {
        }
    }

    [Message(GameMessageOpcode.ClientMarketplaceRequestOwnedItemAuctions)]
    public class ClientMarketplaceRequestOwnedItemAuctions : IReadable
    {
        // Message itself is the trigger for the request. Payload is 0 bytes.
        public void Read(GamePacketReader reader)
        {
        }
    }

    [Message(GameMessageOpcode.ClientMarketplaceRequestCommodityInfo)]
    public class ClientMarketplaceRequestCommodityInfo : IReadable
    {
        public uint RequestedCommodityId { get; private set; }
        public void Read(GamePacketReader reader)
        {
            RequestedCommodityId = reader.ReadUInt(18);
        }
    }

    [Message(GameMessageOpcode.Client0635)]
    public class Client0635 : IReadable
    {
        public uint Id { get; private set; }
        public void Read(GamePacketReader reader)
        {
            Id = reader.ReadUInt();
        }
    }

    [Message(GameMessageOpcode.ClientCREDDExchangeRequestExchangeInfo)]
    public class ClientCREDDExchangeRequestExchangeInfo : IReadable
    {
        // Message itself is the trigger for the request. Payload is 0 bytes.
        public void Read(GamePacketReader reader)
        {
        }
    }

    [Message(GameMessageOpcode.ClientCancelTrade)]
    public class ClientCancelTrade : IReadable
    {
        // Message itself is the trigger for the request. Payload is 0 bytes.
        public void Read(GamePacketReader reader)
        {
        }
    }

    enum CombatLogOptionFlags
    {
        DisableAbsorption           = 0x1,
        DisableCCState              = 0x2,
        DisableDamage               = 0x4,
        DisableDeflect              = 0x8,
        DisableDelayDeath           = 0x10,
        DisableDispel               = 0x20,
        DisableFallingDamage        = 0x40,
        DisableHeal                 = 0x80,
        DisableImmunity             = 0x100,
        DisableInterrupted          = 0x200,
        DisableModifyInterruptArmor = 0x400,
        DisableTransference         = 0x800,
        DisableVitalModifier        = 0x1000,
        DisableDeath                = 0x2000
    }

    enum OptionFlags
    {
        UseButtonDownForAbilities   = 0x2,
        AutoTargetting              = 0x4,
        HoldToContinueCasting       = 0x8
    }
}