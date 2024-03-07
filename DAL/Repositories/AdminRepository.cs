using DAL.Context;
using Infrastructure.DataAcses;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class AdminRepository:RepositoryBase<Admin,ProjectVBContext>
    {
        public Admin LogIn(string email,string password,params string[] includeList)
        {
            return Get(x => x.Email == email && x.Password == password,includeList);
        }
    }
}
