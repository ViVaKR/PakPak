using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BootCamp.Models
{
    public class AsciiCode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }


        [Required]
        public int Dec { get; set; }


        [StringLength(4)]
        public required string Oct { get; set; }


        [StringLength(4)]
        public required string Hex { get; set; }


        [StringLength(8)]
        public required string Bin { get; set; }


        [StringLength(10)]
        public required string Symbol { get; set; }


        [StringLength(10)]
        public string? HtmlNumber { get; set; }


        [StringLength(10)]
        public string? HtmlName { get; set; }


        [StringLength(100)]
        public string? Description { get; set; }

    }
}