

using System;
using System.Collections.Generic;

namespace DALSevenCodeOnlineStore
{
    public partial class ProductTypes
    {
        public ProductTypes()
        {
            Products = new HashSet<Products>();
        }

        public int Id { get; set; }
        public string ProductType { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}