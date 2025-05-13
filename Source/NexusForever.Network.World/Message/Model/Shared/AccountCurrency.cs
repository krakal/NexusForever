using NexusForever.Network.Message;

namespace NexusForever.Network.World.Message.Model.Shared
{
    public class AccountCurrency : Game.Abstract.Account.Currency.AccountCurrency, IWritable
    {
        public void Write(GamePacketWriter writer)
        {
            writer.Write(AccountCurrencyType, 5u);
            writer.Write(Amount);
        }
    }
}
