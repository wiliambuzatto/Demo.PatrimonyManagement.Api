using Demo.PatrimonyManagement.Domain.Common;
using Newtonsoft.Json;
using System;

namespace Demo.GestaoPatrimonio.Api.ViewModels
{
    public abstract class BaseViewModel : IIdProperty
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
