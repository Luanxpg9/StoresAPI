using StoresAPI.Domain.Enumerators;
using StoresAPI.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoresAPI.Domain.Models
{
    public class UserStore : Entity
    {
        [ForeignKey("User")]
        public uint UserId { get; set; }
        public virtual User User { get; set; } = null!;

        [ForeignKey("Store")]
        public uint StoreId { get; set; }
        public virtual Store Store { get; set; } = null!;

        public RoleEnumerator Role { get; set; }
    }
}
