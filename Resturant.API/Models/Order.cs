using System;
using System.Collections.Generic;

namespace Resturants.API.Models
{
    public partial class Order
    {
        public Order()
        {
            Meals = new HashSet<Meal>();
        }

        public int Id { get; set; }
        public int Quantity { get; set; }
        public int CustomerId1 { get; set; }
        public int ResturantId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool IsDelete { get; set; }

        public virtual Customer CustomerId1Navigation { get; set; } = null!;
        public virtual Resturant Resturant { get; set; } = null!;

        public virtual ICollection<Meal> Meals { get; set; }
    }
}
