using System.ComponentModel.DataAnnotations;

namespace StoresAPI.Domain.Models.Base
{
    public class Entity
    {
        [Key]
        public uint Id { get; set; }
        public DateTime CreatingDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}
