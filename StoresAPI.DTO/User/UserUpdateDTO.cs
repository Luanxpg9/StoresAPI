namespace StoresAPI.DTO.User
{
    public class UserUpdateDTO
    {
        public uint Id { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? CPF { get; set; }
        public string? Password { get; set; }
        public bool? IsActive { get; set; }
    }
}
