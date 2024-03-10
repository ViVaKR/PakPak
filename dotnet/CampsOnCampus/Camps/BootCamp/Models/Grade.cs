using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BootCamp.Models
{
    public class Grade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GradId
        {
            get;
            set;
        }

        [StringLength(20)]
        public required string GradName { get; set; }

        [StringLength(50)]
        public required string Section { get; set; }

        [NotMapped]
        public required ICollection<Student> Students { get; set; }
    }
}