using DALSevenCodeOnlineStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLLSevenCodeOnlineStore.ViewModels.Customers
{
    public class ProductsWithPagination
    {
        public List<Products> products { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
