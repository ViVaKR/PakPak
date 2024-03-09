using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BootCamp.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        [StringLength(20)]
        public required string Name { get; set; }


        [Required]
        public bool IsActive { get; set; }


        [StringLength(200)]
        public string Memo { get; set; } = string.Empty;
    }
}