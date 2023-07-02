﻿

using System;
using System.Collections.Generic;

namespace DALSevenCodeOnlineStore
{
    public partial class SpecialTags
    {
        public SpecialTags()
        {
            Products = new HashSet<Products>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}