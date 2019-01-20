using System;
using System.ComponentModel.DataAnnotations;

namespace Demo.GestaoPatrimonio.Api.ViewModels
{
    public class PatrimonyViewModel : BaseViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid BrandId { get; set; }

        public string Description { get; set; }
        public Guid TippingNumber { get; set; }
    }
}
