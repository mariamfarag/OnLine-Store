

using System;
using System.Collections.Generic;

namespace DALSevenCodeOnlineStore
{
    public partial class OrderDetails
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PorductId { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Products Porduct { get; set; }
    }
}