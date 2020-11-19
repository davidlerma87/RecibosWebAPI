using Recibos.Core.QueryFilters;
using System;

namespace Recibos.Infrastructure.Interfaces
{
    public interface IUriService
    {
        Uri GetPostPaginationUri(PostQueryFilter filter, string actionUrl);
    }
}
