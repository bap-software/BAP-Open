namespace BAP.eCommerce.Suppliers.BrainDropShipping.ApiModels
{
    public static class BrainDeliveryType
    {
        public const string Self = "self";
        public const string Home = "home";
    }

    public static class BrainRecipientType
    {
        public const int Person = 0;
        public const int Organization = 1;
    }

    /// <summary>
    /// Detailed info: http://api.brain.com.ua/help/ship_order_to_drop
    /// </summary>
    public static class BrainPaymentMethodType
    {
        /// <summary>
        /// By bank transfer (invoice)
        /// </summary>
        public const int BankTransfer = 1;
        
        /// <summary>
        /// Cash on delivery
        /// </summary>
        public const int Cash = 5;
    }

    public static class BrainStatusResponse
    {
        public const string Success = "1";
    }

    public static class BrainCurrency
    {
        public const string Uah = "UAH";
        public const string Usd = "USD";
    }

    /// <summary>
    /// Specify particular region names for Brain Targets
    /// </summary>
    public static class TargetRegion
    {
        public const string NovaPoshta = "Україна Нова Пошта";
    }
}