using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace A3C6TV_HFT_2023241.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Customer()
        {

        }

        public Customer(int id, string name, string phone, string email)
        {
            CustomerId = id;
            Name = name;
            Phone = phone;
            Email = email;
        }
    }
}
