using NexusForever.Network.Message;
using NexusForever.Network.World.Message.Model;

namespace NexusForever.WorldServer.Network.Message.Handler.Quest
{
    public class ClientQuestShareResultHandler : IMessageHandler<IWorldSession, ClientQuestShareResponse>
    {
        public void HandleMessage(IWorldSession session, ClientQuestShareResponse questShareResult)
        {
            session.Player.QuestManager.QuestShareResult(questShareResult.QuestId, questShareResult.Accept);
        }
    }
}
