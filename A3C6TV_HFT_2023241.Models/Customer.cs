using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace A3C6TV_HFT_2023241.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Customer_ID { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
    }
}
