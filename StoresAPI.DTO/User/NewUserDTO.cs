namespace StoresAPI.DTO.User
{
    public class NewUserDTO
    {
        public string Name { get; set; } = String.Empty;
        public string Username { get; set; } = String.Empty;
        public string CPF { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public bool IsActive { get; set; } = true;
    }
}
