

using System;
using System.Collections.Generic;

namespace DALSevenCodeOnlineStore
{
    public partial class Orders
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public string OrderNo { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}