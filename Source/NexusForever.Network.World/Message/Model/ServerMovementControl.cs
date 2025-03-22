using NexusForever.Network.Message;

namespace NexusForever.Network.World.Message.Model
{
    [Message(GameMessageOpcode.ServerMovementControl)]
    public class ServerMovementControl : IWritable
    {
        public uint Ticket { get; set; }
        public bool ExecuteUnitCommands { get; set; }
        public uint UnitId { get; set; }

        public void Write(GamePacketWriter writer)
        {
            writer.Write(Ticket);
            writer.Write(ExecuteUnitCommands);
            writer.Write(UnitId);
        }
    }
}
