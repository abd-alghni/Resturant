using System;
using System.Collections.Generic;

namespace Resturants.API.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public bool IsDelete { get; set; }
        public string Address { get; set; } = null!;
        public string? CreatedBy { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
