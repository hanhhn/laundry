﻿using System.Collections.Generic;

namespace Cf.Libs.Core.Infrastructure.Paging
{
    public interface IPagedList<T>
    {
        int PageIndex { get; }
        int PageSize { get; }
        int TotalRecord { get; }
        int TotalPage { get; }
        IEnumerable<T> DataSource { get;}
    }
}