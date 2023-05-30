namespace StoresAPI.DTO.Store
{
    public class NewStoreDTO
    {
        public string Name { get; set; } = String.Empty;
        public string? TradingName { get; set; }
        public string CNPJ { get; set; } = String.Empty;
    }
}
