﻿namespace EverythingNet.Interfaces
{
    using System.Collections.Generic;

    public interface IQueryable : IEnumerable<ISearchResult>
    {
        bool IsFast { get; }

        long Count { get; }

        IQuery And { get; }

        IQuery Or { get; }
    }
}