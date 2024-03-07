using DAL.Repositories;

using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
   public class AdminBs
    {
      private readonly  AdminRepository _repo;
        
        public AdminBs()
        {
            _repo = new AdminRepository();

        }

        public List<Admin> GetAll(params string[] includeList)
        {
            return _repo.GetAll(filter:null,includeList:includeList); 
        }
        public Admin LogIn(string email,string password,params string[] includeList)
        {
            return _repo.LogIn(email, password,includeList);

        }

        public void Insert(Admin admin)
        {
            _repo.Add(admin);
        }

        public void Delete(int id)
        {
            _repo.DeleteById(id);
        }
        public Admin GetByEmail(string email)
        {
            return _repo.Get(x => x.Email == email);
        }
        public void Update(Admin admin)
        {
            _repo.Update(admin);
        }

        public Admin GetAllEmail(string email)
        {
            return _repo.Get(x => x.Email == email);
        }

        public Admin GetById(int id)
        {
            return _repo.GetById(id);
        }
    }
}
