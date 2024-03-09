using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BootCamp.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [StringLength(20)]
        public required string Name { get; set; }
        
        [Required]
        public int GradeId { get; set; }
        
        [ForeignKey(nameof(GradeId))]
        public required Grade Grade { get; set; }
    }
}