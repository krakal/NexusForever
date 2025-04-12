using NexusForever.Network.Message;

namespace NexusForever.Network.World.Message.Model
{
    [Message(GameMessageOpcode.ServerTriggerSoundTaxiLanding)]
    public class ServerTriggerSoundTaxiLanding : IWritable
    {
        // Zero length message. Only triggers sound when player Unit is on a taxi.
        public void Write(GamePacketWriter writer)
        {
        }
    }
}