using NexusForever.Network.Message;

namespace NexusForever.Network.World.Message.Model.Shared
{
    public class Costume : Game.Abstract.Entity.Costume, IWritable
    {
        public void Write(GamePacketWriter writer)
        {
            writer.Write(Index);
            writer.Write(Mask);
            writer.Write(MannequinIndex, 2u);

            for (int i = 0; i < 7; i++)
                writer.Write(ItemIds[i]);
            for (int i = 0; i < 7; i++)
                writer.Write(DyeData[i]);
        }
    }
}
