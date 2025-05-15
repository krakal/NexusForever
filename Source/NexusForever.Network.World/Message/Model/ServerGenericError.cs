using NexusForever.Game.Static;
using NexusForever.Network.Message;

namespace NexusForever.Network.World.Message.Model
{
    [Message(GameMessageOpcode.ServerGenericError)]
    public class ServerGenericError : IWritable
    {
        public GenericError Error { get; set; }

        public void Write(GamePacketWriter writer)
        {
            writer.Write(Error, 8u);
        }
    }
}
