using DAL.Repositories;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class ProductBs
    {
        private readonly ProductRepository _productBs;

        public ProductBs()
        {
            _productBs = new ProductRepository();
        }
        public List<Product> GetAll(params string[] includeList)
        {
            return _productBs.GetAll(filter: null, includeList: includeList);
        }

        public Product GetById(int id)
        {
            return _productBs.GetById(id);
        }
        public void Insert(Product product
            )
        {
            _productBs.Add(product);
        }
        public void Update(Product product)
        {
            _productBs.Update(product);
        }
        public void Delete(int id)
        {
            _productBs.DeleteById(id);
        }
        
    }
}
