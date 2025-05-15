using NexusForever.Game.Static;
using NexusForever.Network.Message;

namespace NexusForever.Network.World.Message.Model
{

    [Message(GameMessageOpcode.ServerPathChangeResult)]
    public class ServerPathChangeResult : IWritable
    {
        public GenericError Result { get; set; }

        public void Write(GamePacketWriter writer)
        {
            writer.Write(Result, 8);
        }
    }
}
