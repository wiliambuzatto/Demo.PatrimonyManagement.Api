using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Demo.PatrimonyManagement.Data.Repository.Pattern
{
    public class IncludeList<T> : List<Expression<Func<T, object>>>
    {
        public IncludeList(params Expression<Func<T, object>>[] expressions)
        {
            AddRange(expressions);
        }
    }
}
