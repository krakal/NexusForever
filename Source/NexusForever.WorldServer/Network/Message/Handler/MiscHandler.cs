using System;
using NexusForever.Game;
using NexusForever.Game.Abstract.Character;
using NexusForever.Game.Character;
using NexusForever.Game.Entity;
using NexusForever.Network;
using NexusForever.Network.Message;
using NexusForever.Network.World.Message.Model;
using NexusForever.Network.World.Message.Model.Shared;
using NLog;

namespace NexusForever.WorldServer.Network.Message.Handler
{
    public static class MiscHandler
    {
        [MessageHandler(GameMessageOpcode.ClientOnRealmOrCharacterSelectScreen)]
        public static void HandleOnRealmOrCharacterSelectScreen(IWorldSession session, ClientOnRealmOrCharacterSelectScreen onSelectScreeen)
        {
            ILogger log = LogManager.GetCurrentClassLogger();

            log.Warn("On Character Select Screen");
        }

        /// <summary>
        /// Handled responses to Player Info Requests.
        /// TODO: Put this in the right place, this is used by Mail & Contacts, at minimum. Probably used by Guilds, Circles, etc. too.
        /// </summary>
        [MessageHandler(GameMessageOpcode.ClientPlayerInfoRequest)]
        public static void HandlePlayerInfoRequest(IWorldSession session, ClientPlayerInfoRequest request)
        {
            ICharacter character = CharacterManager.Instance.GetCharacter(request.Identity.CharacterId);
            if (character == null)
                throw new InvalidPacketValueException();

            float? onlineStatus = character.GetOnlineStatus();
            session.EnqueueMessageEncrypted(new ServerPlayerInfoFullResponse
            {
                BaseData = new ServerPlayerInfoFullResponse.Base
                {
                    ResultCode = 0,
                    Identity = new TargetPlayerIdentity
                    {
                        RealmId = RealmContext.Instance.RealmId,
                        CharacterId = character.CharacterId
                    },
                    Name = character.Name,
                    Faction = character.Faction1
                },
                IsClassPathSet = true,
                Path  = character.Path,
                Class = character.Class,
                Level = character.Level,
                IsLastLoggedOnInDaysSet = onlineStatus.HasValue,
                LastLoggedInDays = onlineStatus.GetValueOrDefault(0f)
            });
        }

        [MessageHandler(GameMessageOpcode.ClientToggleWeapons)]
        public static void HandleWeaponToggle(IWorldSession session, ClientToggleWeapons toggleWeapons)
        {
            session.Player.Sheathed = toggleWeapons.ToggleState;
        }

        [MessageHandler(GameMessageOpcode.ClientRandomRollRequest)]
        public static void HandleRandomRoll(IWorldSession session, ClientRandomRollRequest randomRoll)
        {
            if (randomRoll.MinRandom > randomRoll.MaxRandom)
                throw new InvalidPacketValueException();

            if (randomRoll.MaxRandom > 1000000u)
                throw new InvalidPacketValueException();

            session.EnqueueMessageEncrypted(new ServerRandomRollResponse
            {
                TargetPlayerIdentity = new TargetPlayerIdentity
                {
                    RealmId = RealmContext.Instance.RealmId,
                    CharacterId = session.Player.CharacterId
                },
                MinRandom = randomRoll.MinRandom,
                MaxRandom = randomRoll.MaxRandom,
                RandomRollResult = new Random().Next((int)randomRoll.MinRandom, (int)randomRoll.MaxRandom)
            });
        }

        [MessageHandler(GameMessageOpcode.ClientZoneChange)]
        public static void HandleClientZoneChange(IWorldSession session, ClientZoneChange zoneChange)
        {
        }

        /// <summary>
        /// Client sends this when it has received everything it needs to leave the loading screen.
        /// For housing maps, this also includes things such as residences and plots.
        /// See 0x732990 in the client for more information.
        /// </summary>
        [MessageHandler(GameMessageOpcode.ClientEnteredWorld)]
        public static void HandleClientEnteredWorld(IWorldSession session, ClientEnteredWorld enteredWorld)
        {
            if (!session.Player.IsLoading)
                throw new InvalidPacketValueException();

            session.Player.OnEnteredWorld();
        }

        [MessageHandler(GameMessageOpcode.ClientCinematicState)]
        public static void HandleCinematicState(IWorldSession session, ClientCinematicState cinematicState)
        {
            session.Player.CinematicManager.HandleClientCinematicState(cinematicState.State);
        }

        /// <summary>
        /// Client sends this when the user has filled out any customer surver. 
        /// The response object contains the type of the survey, additional parmeters and the answers of the user.
        /// </summary>
        [MessageHandler(GameMessageOpcode.ClientCustomerSurveySubmit)]
        public static void HandleClientCustomerSurvey(WorldSession session, ClientCustomerSurveySubmit surveyResponse)
        {
        }

        /// <summary>
        /// Client sends this first when joining the world server, before the player's character has been selected, and
        /// then randomly every 1-10 seconds once their character is loaded in the client.
        /// Contains statistics about the watchdog run times on the client, a random value generated by the client and its seed value.
        /// Currently no known use for this data in NF but it is useful to have a handler receive the packet.
        /// </summary>
        [MessageHandler(GameMessageOpcode.ClientWatchdogStatistics)]
        public static void HandleClientWatchdogStatistics(WorldSession session, ClientWatchdogStatistics watchdogStatistics)
        {
        }

        [MessageHandler(GameMessageOpcode.ClientAbilityAndLogOptions)]
        public static void HandleClientAbilityAndLogOptions(WorldSession session, ClientAbilityAndLogOptions abilityAndLogOptions)
        {
            ILogger log = LogManager.GetCurrentClassLogger();

            log.Warn($"LogOptionFlags:{abilityAndLogOptions.LogOptionFlags:X}, " +
                $"AbilityFlags:{abilityAndLogOptions.TargettingAndAbilityFlags:X}, " +
                $"DisableLogOtherPlayers:{abilityAndLogOptions.LogOtherPlayers}");
            
        }

        [MessageHandler(GameMessageOpcode.ClientAbilityOptions)]
        public static void HandleClientAbilityOptions(WorldSession session, ClientAbilityOptions abilityOptions)
        {
            ILogger log = LogManager.GetCurrentClassLogger();

            log.Warn($"AbilityFlags:{abilityOptions.TargettingAndAbilityFlags:X}, " +
                $"ShareChallengePreference:{abilityOptions.SharedChallengePreference:X}");
        }

        [MessageHandler(GameMessageOpcode.ClientLogOtherPlayers)]
        public static void HandleClientLogOtherPlayers(WorldSession session, ClientLogOtherPlayers logOtherPlayers)
        {
            ILogger log = LogManager.GetCurrentClassLogger();

            log.Warn($"DisableLogOtherPlayers:{logOtherPlayers.LogOtherPlayersDisabled}");
        }

        [MessageHandler(GameMessageOpcode.ClientLogOptions)]
        public static void HandleClientLogOptions(WorldSession session, ClientLogOptions logOptions)
        {
            ILogger log = LogManager.GetCurrentClassLogger();

            log.Warn($"LogOptionFlags:{logOptions.LogOptionFlags:X}");
        }

        [MessageHandler(GameMessageOpcode.ClientRewardRotation)]
        public static void HandleClientRewardRotation(WorldSession session, ClientRewardRotation rewardRotation)
        {
            ILogger log = LogManager.GetCurrentClassLogger();

            log.Warn($"RewardContentType:{rewardRotation.ContentTypeEnum}");
        }

        [MessageHandler(GameMessageOpcode.ClientWindowOpenStatistics)]
        public static void HandleClientWindowOpenStatistics(WorldSession session, ClientWindowOpenStatistics windowStatistics)
        {
            ILogger log = LogManager.GetCurrentClassLogger();

            log.Warn($"CharacterId:{windowStatistics.CharacterId}, TimeSpentOpen:{windowStatistics.TimeSpentOpen}, Windowname:{windowStatistics.WindowName}");
        }

        [MessageHandler(GameMessageOpcode.ClientGfxStatistics)]
        public static void HandleClientGfxStatistics(WorldSession session, ClientGfxStatistics gfxStatistics)
        {
            ILogger log = LogManager.GetCurrentClassLogger();

            log.Warn($"GfxStat1:{gfxStatistics.GfxStat1}, GfxStat2:{gfxStatistics.GfxStat2}, GfxStat2:{gfxStatistics.GfxStat3}, GfxStat4:{gfxStatistics.GfxStat4}");
            log.Warn($"GfxStat5:{gfxStatistics.GfxStat5}, GfxStat6:{gfxStatistics.GfxStat6}, GfxStat7:{gfxStatistics.GfxStat7}, GfxStat8:{gfxStatistics.GfxStat8}");
        }

        [MessageHandler(GameMessageOpcode.ClientConnectionStatistics)]
        public static void HandleClientConnectionStatistics(WorldSession session, ClientConnectionStatistics connectionStatistics)
        {
            ILogger log = LogManager.GetCurrentClassLogger();

            log.Warn($"TimePerMessage0x1:{connectionStatistics.NetworkStat1}, Received:{connectionStatistics.NetworkStat2}, " +
                $"Sent:{connectionStatistics.NetworkStat3}, UnitTableSize:{(connectionStatistics.NetworkStat4 - 1)/2}");
        }

        [MessageHandler(GameMessageOpcode.ClientFramerateStatistics)]
        public static void HandleClientModelStatistics(WorldSession session, ClientFramerateStatistics statistics)
        {
            ILogger log = LogManager.GetCurrentClassLogger();

            log.Warn($"AverageTimePerFrame:{statistics.AverageTimePerFrame>>1}, HighestTimeFrame:{statistics.HighestTimeFrame>>1}, " +
                $"HighestTimeMS:{statistics.HighestFrameTimeMilliseconds}, msPerFrame:{statistics.MillisecondsPerFrame>>1}");
            log.Warn($"X@SlowestFrame:{statistics.Float1}, Y@SlowestFrame:{statistics.Float2}, Z@SlowestFrame:{statistics.Float3}");
        }

        [MessageHandler(GameMessageOpcode.ClientPlayerMovementSpeedUpdate)]
        public static void HandleClientPlayerMovementSpeedUpdate(WorldSession session, ClientPlayerMovementSpeedUpdate update)
        {
            ILogger log = LogManager.GetCurrentClassLogger();

            log.Warn($"Speed:{update.Speed}");
        }

        [MessageHandler(GameMessageOpcode.ClientSprint)]
        public static void HandleClientSprint(WorldSession session, ClientSprint update)
        {
            ILogger log = LogManager.GetCurrentClassLogger();

            log.Warn($"Sprinting:{update.Sprinting}");
        }

        [MessageHandler(GameMessageOpcode.ClientDash)]
        public static void HandleClientDash(WorldSession session, ClientDash message)
        {
            ILogger log = LogManager.GetCurrentClassLogger();

            log.Warn($"DashDirection:{message.DashDirection}");
        }

        [MessageHandler(GameMessageOpcode.ClientMarketplaceRequestOwnedCommodityOrders)]
        public static void HandleClientMarketplaceRequestOwnedCommodityOrders(WorldSession session, ClientMarketplaceRequestOwnedCommodityOrders request)
        {
        }

        [MessageHandler(GameMessageOpcode.ClientMarketplaceRequestOwnedItemAuctions)]
        public static void HandleClientMarketplaceRequestOwnedItemAuctions(WorldSession session, ClientMarketplaceRequestOwnedItemAuctions request)
        {
        }

        [MessageHandler(GameMessageOpcode.Client0635)]
        public static void HandleClient0635(WorldSession session, Client0635 message)
        {
            ILogger log = LogManager.GetCurrentClassLogger();

            log.Warn($"ServerControlled Id:{message.Id}");
        }

        [MessageHandler(GameMessageOpcode.ClientCancelTrade)]
        public static void HandleClientCancelTrade(WorldSession session, ClientCancelTrade message)
        {
        }
    }
}
