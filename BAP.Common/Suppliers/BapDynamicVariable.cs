namespace BAP.Common.Suppliers
{
    public class BapDynamicVariable
    {
        /// <summary>
        /// Key to determine what it is variable
        /// </summary>
        public string Key { get; }
        
        public dynamic Value { get; set; }

        public BapDynamicVariable(string key, dynamic value)
        {
            Key = key;
            Value = value;
        }
    }
}