using StoresAPI.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace StoresAPI.Domain.Models
{
    public class User : Entity
    {
        [Required(ErrorMessage = "User must have an name", AllowEmptyStrings = false)]
        [MaxLength(450, ErrorMessage = "Max length of {1} exceeded")]
        public string Name { get; set; } = String.Empty;

        [Required(ErrorMessage = "User must have an CPF", AllowEmptyStrings = false)]
        [MaxLength(12, ErrorMessage = "Max length of {1} exceeded")]
        public string CPF { get; set; } = String.Empty;

        [Required(ErrorMessage = "User must have an username", AllowEmptyStrings = false)]
        [MaxLength(30, ErrorMessage = "Max length of {1} exceeded")]
        public string Username { get; set; } = String.Empty;

        // Relationship between User and Store
        public virtual IList<UserStore> UserStores { get; set; } = null!;
    }
}
