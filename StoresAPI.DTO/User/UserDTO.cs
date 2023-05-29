namespace StoresAPI.DTO.User
{
    public class UserDTO
    {
        public uint Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Username { get; set; } = String.Empty;
        public string CPF { get; set; } = String.Empty;
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
    }
}
