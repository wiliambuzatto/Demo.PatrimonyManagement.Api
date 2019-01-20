using AutoMapper;
using Demo.GestaoPatrimonio.Api.ViewModels;
using Demo.PatrimonyManagement.Domain;
using Demo.PatrimonyManagement.Domain.Common;
using Demo.PatrimonyManagement.Service.Patrimony;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Demo.GestaoPatrimonio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatrimonyController : Controller
    {
        private readonly IPatrimonyService _patrimonyService;

        public PatrimonyController(IPatrimonyService patrimonyService)
        {
            _patrimonyService = patrimonyService;
        }

        #region GET
        [HttpGet()]
        [Authorize("Bearer")]
        public PagedList<PatrimonyViewModel> GetAll() => Paged(1, 50);

        [HttpGet("{page}/{items}")]
        [Authorize("Bearer")]
        public PagedList<PatrimonyViewModel> Paged(int page, int items)
        {
            var patrimonies  = _patrimonyService.Get<object>(x => x.Name, page, items);
            var response = Mapper.Map<List<PatrimonyViewModel>>(patrimonies.Items);
            return new PagedList<PatrimonyViewModel>()
            {
                Page = page,
                TotalItems = patrimonies.TotalItems,
                ItemsPerPage = items,
                Items = response
            };
        }

        [HttpGet("{id}")]
        [Authorize("Bearer")]
        public Patrimony GetById(Guid id) => _patrimonyService.Find(id);

        #endregion

        [HttpPost]
        [Authorize("Bearer")]
        public Result<Patrimony> Create([FromBody] CreatePatrimonyViewModel patrimonyViewModel)
        {
            var obj = Mapper.Map<Patrimony>(patrimonyViewModel);
            return _patrimonyService.Insert(obj);
        }

        [Authorize("Bearer")]
        [HttpPut("{id}")]
        public Result<Patrimony> Update(Guid id, [FromBody] CreatePatrimonyViewModel patrimonyViewModel)
        {
            patrimonyViewModel.Id = id;
            var obj = Mapper.Map<Patrimony>(patrimonyViewModel);

            return _patrimonyService.Update(obj);
        }

        [Authorize("Bearer")]
        [HttpDelete("{id}")]
        public Result Delete(Guid id) => _patrimonyService.Delete(id);
    }
}
