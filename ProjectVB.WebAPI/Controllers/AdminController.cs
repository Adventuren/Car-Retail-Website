using Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Dto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectVB.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminBs _adminBs;
        public AdminController()
        {
            _adminBs = new AdminBs();
        }
        [HttpGet]
        [Route("GetAllAdmins")]
        public List<AdminDto> Get()
        {
            return _adminBs.GetAll().Select(x => new AdminDto()
            {
                Email = x.Email,
                FullName = x.FullName,
                Id = x.Id,
                IsActive = x.IsActive
            }).ToList();
        }
        [HttpGet]
        [Route("getByAdminId/{id}")]
        public IActionResult GetById(int id)
        {
            Admin admin = _adminBs.GetById(id);
            if (admin != null)
            {
                AdminDto dto = new AdminDto();
                dto.FullName = admin.FullName;
                dto.Id = admin.Id;
                dto.Email = admin.Email;
                dto.IsActive = admin.IsActive;
                return Ok(dto);
            }
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] AdminInsertDto dto)
        {
            if (ModelState.IsValid)
            {
                Admin admin = new Admin();
                admin.Email = dto.Email;
                admin.FullName = dto.FullName;
                admin.Password = dto.Password;
                admin.IsActive = dto.IsActive;
                _adminBs.Insert(admin);
                return CreatedAtAction("GetById", new { id = admin.Id }, admin);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put([FromBody] AdminUpdateDto dto)
        {
            if (ModelState.IsValid)
            {
                Admin admin = _adminBs.GetById(dto.Id);
                if (admin != null)
                {
                    admin.Email = dto.Email;
                    admin.FullName = dto.FullName;
                    admin.IsActive = dto.IsActive;
                    admin.Password = dto.Password;
                    _adminBs.Update(admin);
                    return Ok(admin);
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Admin admin = _adminBs.GetById(id);
            if (admin != null)
            {
                _adminBs.Delete(id);
                return Ok();
            }
            return NotFound();
        }

        
    }
}
