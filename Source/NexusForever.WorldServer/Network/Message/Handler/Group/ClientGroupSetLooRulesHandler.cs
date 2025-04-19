using NexusForever.Game.Abstract.Group;
using NexusForever.Game.Group;
using NexusForever.Game.Static.Group;
using NexusForever.Network.Message;
using NexusForever.Network.World.Message.Model;

namespace NexusForever.WorldServer.Network.Message.Handler.Group
{
    public class ClientGroupSetLootRulesHandler : IMessageHandler<IWorldSession, ClientGroupSetLootRules>
    {
        /// <summary>
        /// </summary>
        public void HandleMessage(IWorldSession session, ClientGroupSetLootRules clientGroupSetLootRules)
        {
            GroupHandler.AssertGroupId(session, clientGroupSetLootRules.GroupId);
            GroupHandler.AssertGroupLeader(session, clientGroupSetLootRules.GroupId);

            IGroup group = GroupManager.Instance.GetGroupById(clientGroupSetLootRules.GroupId);
            group.UpdateLootRules(clientGroupSetLootRules.LootRulesUnderThreshold, clientGroupSetLootRules.LootRulesThresholdAndOver, clientGroupSetLootRules.Threshold, clientGroupSetLootRules.HarvestingRule);
        }
    }
}