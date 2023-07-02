

using System;
using System.Collections.Generic;

namespace DALSevenCodeOnlineStore
{
    public partial class Products
    {
        public Products()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string ProductColor { get; set; }
        public bool IsAvailable { get; set; }
        public int ProductTypeId { get; set; }
        public int SpecialTagId { get; set; }
        public int? CategoryId { get; set; }
        public string Description { get; set; }

        public virtual Category Category { get; set; }
        public virtual ProductTypes ProductTypes { get; set; }
        public virtual SpecialTags SpecialTags { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}