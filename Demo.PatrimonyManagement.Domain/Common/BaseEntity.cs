﻿using System;

namespace Demo.PatrimonyManagement.Domain.Common
{
    public abstract class BaseEntity: IIdProperty
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime? CreationDate { get; set; }
    }
}
