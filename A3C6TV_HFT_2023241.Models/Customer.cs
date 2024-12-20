﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace A3C6TV_HFT_2023241.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public virtual ICollection<Booking> Bookings { get; set; }

        public Customer()
        {

        }

        public Customer(int id, string name, string phone, string email)
        {
            CustomerId = id;
            Name = name;
            Phone = phone;
            Email = email;
            Bookings = new HashSet<Booking>();
        }

        public override string ToString()
        {
            return $"Id: {CustomerId} - {Name} - {Phone} - {Email}";
        }

        public override bool Equals(object obj)
        {
            return obj is Customer customer &&
                   CustomerId == customer.CustomerId &&
                   Name == customer.Name &&
                   Phone == customer.Phone &&
                   Email == customer.Email;
        }
    }
}
