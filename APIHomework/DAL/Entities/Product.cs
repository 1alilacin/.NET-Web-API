using System.ComponentModel.DataAnnotations;

namespace APIHomework.DAL.Entities
{
    public class Product
    {
        
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int stock { get; set; }
    }
}
