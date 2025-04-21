namespace NexusForever.ModelMigration
{
    public class AccountCurrencyModel : IMessageModel
    {
        public byte AccountCurrencyType { get; set; }
        public ulong Amount { get; set; }
    }
}
