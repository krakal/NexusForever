using NexusForever.Network.Message;

namespace NexusForever.Network.World.Message.Model
{
    [Message(GameMessageOpcode.ClientGroupMentoringCancel)]
    public class ClientGroupMentoringCancel : IReadable
    {
        public ulong GroupId { get; private set; }

        public void Read(GamePacketReader reader)
        {
            GroupId = reader.ReadULong();
        }
    }
}
