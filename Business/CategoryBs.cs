using DAL.Repositories;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
   public class CategoryBs
    {
        private readonly CategoryRepository _categoryBs;

        public CategoryBs()
        {
            _categoryBs = new CategoryRepository();
        }
        public List<Category> GetAll(params string[] includeList)
        {
            return _categoryBs.GetAll(filter:null,includeList:includeList);
        }
        public Category GetById(int id)
        {
            return _categoryBs.GetById(id);
        }
    }
}
