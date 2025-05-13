using NexusForever.Network.Message;

namespace NexusForever.Network.World.Message.Model.Shared
{
    public class Binding : Game.Abstract.General.Binding, IReadable, IWritable
    {
        public void Read(GamePacketReader reader)
        {
            InputActionId   = reader.ReadUShort(14u);
            DeviceEnum00    = reader.ReadUInt();
            DeviceEnum01    = reader.ReadUInt();
            DeviceEnum02    = reader.ReadUInt();
            Code00          = reader.ReadUInt();
            Code01          = reader.ReadUInt();
            Code02          = reader.ReadUInt();
            MetaKeys00      = reader.ReadUInt();
            MetaKeys01      = reader.ReadUInt();
            MetaKeys02      = reader.ReadUInt();
            EventTypeEnum00 = reader.ReadUInt();
            EventTypeEnum01 = reader.ReadUInt();
            EventTypeEnum02 = reader.ReadUInt();
        }

        public void Write(GamePacketWriter writer)
        {
            writer.Write(InputActionId, 14u);
            writer.Write(DeviceEnum00);
            writer.Write(DeviceEnum01);
            writer.Write(DeviceEnum02);
            writer.Write(Code00);
            writer.Write(Code01);
            writer.Write(Code02);
            writer.Write(MetaKeys00);
            writer.Write(MetaKeys01);
            writer.Write(MetaKeys02);
            writer.Write(EventTypeEnum00);
            writer.Write(EventTypeEnum01);
            writer.Write(EventTypeEnum02);
        }
    }
}
