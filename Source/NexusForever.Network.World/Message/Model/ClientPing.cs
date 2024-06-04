using NexusForever.Network.Message;

namespace NexusForever.Network.World.Message.Model
{
    [Message(GameMessageOpcode.ClientOnRealmOrCharacterSelectScreen)]
    public class ClientOnRealmOrCharacterSelectScreen : IReadable 
    {
        public void Read(GamePacketReader reader)
        {
        }
    }
}
