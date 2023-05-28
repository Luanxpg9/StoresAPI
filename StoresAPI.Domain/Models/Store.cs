using StoresAPI.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace StoresAPI.Domain.Models
{
    public class Store : Entity
    {
        [Required(ErrorMessage = "Store must have an name", AllowEmptyStrings = false)]
        [MaxLength(450, ErrorMessage = "Max length of {1} exceeded")]
        public string Name { get; set; } = String.Empty;
        [MaxLength(450, ErrorMessage = "Max length of {1} exceeded")]
        public string? TradingName { get; set; }

        [Required(ErrorMessage = "Store must have an CNPJ", AllowEmptyStrings = false)]
        [MaxLength(15, ErrorMessage = "Max length of {1} exceeded")]
        public string CNPJ { get; set; } = String.Empty;

        // Relationship between Store and User
        public virtual IList<UserStore> UserStores { get; } = null!;
    }
}
