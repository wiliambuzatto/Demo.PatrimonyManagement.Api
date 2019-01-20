using System.ComponentModel.DataAnnotations;

namespace Demo.GestaoPatrimonio.Api.ViewModels
{
    public class BrandViewModel : BaseViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
