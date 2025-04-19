using NexusForever.Network.Message;

namespace NexusForever.Network.World.Message.Model
{
    [Message(GameMessageOpcode.ClientGroupJoinResponse)]
    public class ClientGroupJoinResponse : IReadable
    {
        public enum RequestType
        {
            Referred = 0,
            Invited = 1
        }

        public ulong GroupId { get; private set; }
        public bool AcceptedRequest { get; private set; }
        public string InviteeName { get; private set; }
        public RequestType Type { get; private set; }

        public void Read(GamePacketReader reader)
        {
            GroupId = reader.ReadULong();
            AcceptedRequest = reader.ReadBit();
            InviteeName = reader.ReadWideString();
            Type = (RequestType)reader.ReadByte(1);
        }
    }
}
