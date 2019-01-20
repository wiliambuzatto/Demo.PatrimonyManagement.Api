using Demo.PatrimonyManagement.Domain.Common;
using System;

namespace Demo.PatrimonyManagement.Domain
{
    public class Patrimony: BaseEntity
    {
        public string Name { get; set; }
        public Brand Brand { get; set; }
        public Guid BrandId { get; set; }
        public string Description { get; set; }
        public Guid TippingNumber { get; set; }
    }
}
