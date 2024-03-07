using Business;
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
    public class ProductController : Controller
    {
        private readonly ProductBs _productBs;

        public ProductController()
        {
            _productBs = new ProductBs();
        }
        [HttpGet]
        [Route("GetAllProducts")]
        public List<ProductDto> Get()
        {
            return _productBs.GetAll().Select(x => new ProductDto()
            {
                Id = x.Id,
                IsActive = x.IsActive,
                Marka = x.Marka,
                Seri = x.Seri,
                Yil = x.Yil,
                Fiyat = x.Fiyat,
                AracDurumu = x.AracDurumu,
                Yakit = x.Yakit,
                KM = x.KM,
                Renk = x.Renk,
                Vites = x.Vites,
                CategoryId = x.CategoryId,
            }).ToList();
        }

        [HttpGet]
        [Route("getByProductId/{id}")]
        public IActionResult GetById(int id)
        {
            Product product = _productBs.GetById(id);
            if (product != null)
            {
                ProductDto dto = new ProductDto();
                dto.Id = product.Id;
                dto.IsActive = product.IsActive;
                dto.Marka = product.Marka;
                dto.Seri = product.Seri;
                dto.Yil = product.Yil;
                dto.Fiyat = product.Fiyat;
                dto.AracDurumu = product.AracDurumu;
                dto.Yakit = product.Yakit;
                dto.KM = product.KM;
                dto.Renk = product.Renk;
                dto.Vites = product.Vites;
                dto.CategoryId = product.CategoryId;
                return Ok(dto);
            }
            else
                return NotFound();


        }

    }
}