using NexusForever.Network.Message;
using NexusForever.ModelMigration;

namespace NexusForever.Network.World.Message.Model.Shared
{
    public class AccountCurrency : AccountCurrencyModel, IWritable
    {
        public void Write(GamePacketWriter writer)
        {
            writer.Write(AccountCurrencyType, 5u);
            writer.Write(Amount);
        }
    }
}
