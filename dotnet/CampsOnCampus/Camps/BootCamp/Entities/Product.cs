using System.ComponentModel.DataAnnotations;

namespace BootCamp.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        
        [StringLength(50)]
        public required string ProductName { get; set; }
        
        [MaxLength]
        public string? ProductDescription { get; set; }
        
        
        public int ProductPrice { get; set; }
        
        public int ProductStock { get; set; }
        
    }
}