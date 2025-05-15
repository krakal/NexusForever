using NexusForever.Game.Static;
using NexusForever.Network.Message;

namespace NexusForever.Network.World.Message.Model
{
    [Message(GameMessageOpcode.ServerMailTakeAttachment)]
    public class ServerMailTakeAttachment : IWritable
    {
        public ulong MailId { get; set; }
        public GenericError Result { get; set; }
        public uint Index { get; set; }

        public void Write(GamePacketWriter writer)
        {
            writer.Write(MailId);
            writer.Write(Result, 8u);
            writer.Write(Index);
        }
    }
}
