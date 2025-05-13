using NexusForever.Network.Message;

namespace NexusForever.Network.World.Message.Model.Shared
{
    public class Achievement : Game.Abstract.Achievement.Achievement, IWritable
    {
        public void Write(GamePacketWriter writer)
        {
            writer.Write(AchievementId, 15u);
            writer.Write(Data0);
            writer.Write(Data1);
            writer.Write(DateCompleted);
        }
    }
}
