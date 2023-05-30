namespace StoresAPI.DTO.Store
{
    public class StoreDTO
    {
        public uint Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string? TradingName { get; set; } = String.Empty;
        public string CNPJ { get; set; } = String.Empty;
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }

    }
}
