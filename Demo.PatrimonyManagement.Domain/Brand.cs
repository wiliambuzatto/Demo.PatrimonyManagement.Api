using Demo.PatrimonyManagement.Domain.Common;
using System.Collections.Generic;

namespace Demo.PatrimonyManagement.Domain
{
    public class Brand: BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Patrimony> Patrimonies { get; set; }
    }
}
