using System;
using System.Collections.Generic;

namespace Resturants.API.Models
{
    public partial class Resturant
    {
        public Resturant()
        {
            Meals = new HashSet<Meal>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool IsDelete { get; set; }

        public virtual ICollection<Meal> Meals { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
