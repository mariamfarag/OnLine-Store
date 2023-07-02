using System;
using System.Collections.Generic;
using System.Text;

namespace DALSevenCodeOnlineStore
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Products>();
        }

        public int CategoryId { get; set; }
        public int? ParentCategoryId { get; set; }
        public int? CategoryType { get; set; }
        public string NameArabic { get; set; }
        public string NameEnglish { get; set; }
        public string MainImage { get; set; }
        public bool? IsOpeninNewTab { get; set; }
        public string Description { get; set; }
        public int? OrderMenu { get; set; }
        public bool? IsAppearOnMenu { get; set; }
        public string PageUrl { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
