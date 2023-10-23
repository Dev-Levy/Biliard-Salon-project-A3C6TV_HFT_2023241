using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace A3C6TV_HFT_2023241.Models
{
    public class Consumable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConsumableId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(0, 20000)]
        public int Price { get; set; }


        public Consumable()
        {

        }

        public Consumable(string line)
        {
            string[] data = line.Split('#');
            ConsumableId = int.Parse(data[0]);
            Name = data[1];
            Price = int.Parse(data[2]);
        }
    }
}
