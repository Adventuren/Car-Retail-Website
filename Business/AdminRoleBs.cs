using DAL.Repositories;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class AdminRoleBs
    {
        private readonly AdminRoleRepository _adminRolebs;
        public AdminRoleBs()
        {
            _adminRolebs = new AdminRoleRepository();
        }

        public List<AdminRole> GetAll()
        {
            return _adminRolebs.GetAll();
        }

        public AdminRole GetById(int id)
        {
            return _adminRolebs.GetById(id);
        }

        public void Insert(AdminRole nRole)
        {
            _adminRolebs.Add(nRole);
        }

        public void Delete(AdminRole adminRole)
        {
            _adminRolebs.Delete(adminRole);
        }
        public List<AdminRole> GetAllAdminById(int adminId)
        {
            return _adminRolebs.GetAll(x => x.AdminId == adminId);
        }
    }
}
