using NexusForever.Game.Abstract.Entity;
using NexusForever.Game.Abstract.Group;
using NexusForever.Game.Entity;
using NexusForever.Game.Group;
using NexusForever.Network.Message;
using NexusForever.Network.World.Message.Model;
using NLog;

namespace NexusForever.WorldServer.Network.Message.Handler.Group
{
    public class ClientGroupMentoringAcceptHandler : IMessageHandler<IWorldSession, ClientGroupMentoringAccept>
    {
        public void HandleMessage(IWorldSession session, ClientGroupMentoringAccept mentoringAccept)
        {
            NLog.ILogger log = LogManager.GetCurrentClassLogger();
            log.Info($"MentoringAccept: {mentoringAccept.GroupId} {mentoringAccept.MentorIdentity.CharacterId}");

            IPlayer mentor = session.Player;
            IPlayer mentee = PlayerManager.Instance.GetPlayer(mentoringAccept.MentorIdentity);
            if(mentee != null)
            {
                session.EnqueueMessageEncrypted(new ServerGroupMentoringResult
                {
                    Cancelled = false,
                    GroupId = mentoringAccept.GroupId,
                    Mentee = mentoringAccept.MentorIdentity,
                    Mentor = mentor.Identity
                });
                return;
            }    
        }
    }
}