using System;
using System.ComponentModel.DataAnnotations;

namespace Demo.GestaoPatrimonio.Api.ViewModels
{
    public class CreatePatrimonyViewModel: BaseViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid BrandId { get; set; }
        public string Description { get; set; }
    }
}
