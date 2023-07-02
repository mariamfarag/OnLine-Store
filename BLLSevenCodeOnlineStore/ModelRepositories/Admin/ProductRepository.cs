using BLLSevenCodeOnlineStore.BaseRepository;
using DALSevenCodeOnlineStore;
using System;
using System.Collections.Generic;
using System.Text;

using BLLSevenCodeOnlineStore.ViewModels.Customers;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BLLSevenCodeOnlineStore.ModelRepositories.Admin
{
    public class ProductRepository : BaseRepository<Products>, IProductRepository
    {
        SevenCodeOnlineStoreContext sevenCodeOnlineStoreContext;
        BaseRepository<ProductTypes> productTypesRepo;

        public ProductRepository()
        {
            //ILoggerFactory logFactory;
            //_logger = logFactory.CreateLogger<ReRepository>();
            sevenCodeOnlineStoreContext = new SevenCodeOnlineStoreContext();
            productTypesRepo = new BaseRepository<ProductTypes>(sevenCodeOnlineStoreContext);
          
        }

        public int AddproductType(ProductTypes productType)
        {
            //try //catch - stop//finaly
            try
            {
                productTypesRepo.Add(productType);
                productTypesRepo.Save();

                return productType.Id;
            }
            catch (System.Exception ex)
            {
                //LOG IT!!!
             //   _logger.LogInformation("Log Error message in Add  Repo" + ex.Message.ToString());
                return 0;
            }
            //finally
            //{
            //    //
            //}
        }
        public dynamic AutoComplete(string SerchString)
        {
            var results = GetByAllQuery()
                 .Include(s => s.ProductTypes)
                 .Where(i => i.Name.Contains(SerchString))
                 .Select(i => new { label = i.Name })
                 .ToList();
            return results;
        }

        public ProductsWithPagination GetAll(int PageSize, int page = 1)
        {
            var paginatedCards = GetByAllQuery()
                    .Skip((page - 1) * PageSize)
                    .Include(s => s.ProductTypes)
                    .Take(PageSize).ToList();
            var totalPages = (int)Math.Ceiling((double)GetByAll().Count() / PageSize);
            ProductsWithPagination MyModel = new ProductsWithPagination();
            MyModel.CurrentPage = page;
            MyModel.TotalPages = totalPages;
            MyModel.products = paginatedCards.ToList();
            return MyModel;
        }

        public ProductsWithPagination Serch(string SerchString, int PageSize, int page = 1)
        {
            Func<Products, bool> condition = s => (s.Name.Contains(SerchString) ||
                    s.Name.ToLower().Contains(SerchString) ||
                    s.Name.ToLower() == SerchString ||
                     s.ProductTypes.ProductType.Contains(SerchString) ||
                    s.ProductTypes.ProductType.ToLower().Contains(SerchString) ||
                    s.ProductTypes.ProductType.ToLower() == SerchString);

            var paginatedCards = GetByAllQuery()
                 .Include(s => s.ProductTypes)
                 .Where(condition).Skip((page - 1) * PageSize).Take(PageSize).ToList();
            var totalPages = (int)Math.Ceiling((double)GetByAllQuery()
                 .Include(s => s.ProductTypes)
                .Where(condition).Count() / PageSize);
            ProductsWithPagination MyModel = new ProductsWithPagination();
            MyModel.CurrentPage = page;
            MyModel.TotalPages = totalPages;
            MyModel.products = paginatedCards.ToList();
            return MyModel;
        }
    }

    public interface IProductRepository : IBaseRepository<Products>
    {
        #region Custom_Methods
        public int AddproductType(ProductTypes productType);

        public ProductsWithPagination Serch(string SerchString, int PageSize, int page = 1);
        public ProductsWithPagination GetAll(int PageSize, int page = 1);
        public dynamic AutoComplete(string SerchString);

        #endregion
    }
}
