using System;
using System.Collections.Generic;

namespace Resturants.API.Models
{
    public partial class Meal
    {
        public Meal()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public float PriceInNis { get; set; }
        public float PriceInUsd { get; set; }
        public int CategoryId { get; set; }
        public int ResturantId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool IsDelete { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual Resturant Resturant { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
