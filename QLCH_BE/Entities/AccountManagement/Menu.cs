using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLCH_BE.Entities.AccountManagement
{
    //public class Menu
    //{
    //    [Key]
    //    public string Code { get; set; } = null!;
    //    public string Name { get; set; } = null!;
    //    public bool? Status { get; set; }
    //}
    public class Menu
    {
        [Key]
        public Guid MenuId { get; set; } 

        [Required]
        [MaxLength(100)] 
        public string Name { get; set; } = null!;

        public bool? Status { get; set; }
    }
}
