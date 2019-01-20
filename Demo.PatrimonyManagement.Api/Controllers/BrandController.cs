using AutoMapper;
using Demo.GestaoPatrimonio.Api.ViewModels;
using Demo.PatrimonyManagement.Domain;
using Demo.PatrimonyManagement.Domain.Common;
using Demo.PatrimonyManagement.Service.Brand;
using Demo.PatrimonyManagement.Service.Patrimony;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Demo.GestaoPatrimonio.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAllHeaders")]
    [ApiController]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        private readonly IPatrimonyService _patrimonyService;

        public BrandController(IBrandService brandService, IPatrimonyService patrimonyService)
        {
            _brandService = brandService;
            _patrimonyService = patrimonyService;
        }


        #region GET
        [HttpGet()]
        [Authorize("Bearer")]
        public PagedList<BrandViewModel> GetAll() => Paged(1, 50);

        [HttpGet("{page}/{items}")]
        [Authorize("Bearer")]
        public PagedList<BrandViewModel> Paged(int page, int items)
        {
            var brands = _brandService.Get<object>(x => x.Name, page, items);
            var response = Mapper.Map<List<BrandViewModel>>(brands.Items);
            return new PagedList<BrandViewModel>()
            {
                Page = page,
                TotalItems = brands.TotalItems,
                ItemsPerPage = items,
                Items = response
            };
        }

        [HttpGet("{id}")]
        [Authorize("Bearer")]
        public Brand GetById(Guid id) => _brandService.Find(id);

        [Authorize("Bearer")]
        [HttpGet("{brandId}/Patrimonies")]
        public PagedList<Patrimony> GetPatrimoniesByBrandId(Guid brandId) => _patrimonyService.GetPatrimoniesByBrandId(brandId, 1, 50);

        #endregion

        [HttpPost]
        [Authorize("Bearer")]
        public Result<Brand> Create([FromBody] BrandViewModel brandViewModel)
        {
            var obj = Mapper.Map<Brand>(brandViewModel);
            return _brandService.Insert(obj);
        }

        [Authorize("Bearer")]
        [HttpPut("{id}")]
        public Result<Brand> Update(Guid id, [FromBody] BrandViewModel brandViewModel)
        {
            brandViewModel.Id = id;
            var obj = Mapper.Map<Brand>(brandViewModel);

            return _brandService.Update(obj);
        }

        [Authorize("Bearer")]
        [HttpDelete("{id}")]
        public Result Delete(Guid id) => _brandService.Delete(id);
    }
}
