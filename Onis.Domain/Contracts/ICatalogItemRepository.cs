using Onis.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onis.Domain.Contracts
{
    public interface ICatalogItemRepository : IRepository<CatalogItem>
    {
        object CatalogItems { get; }

        Task<IEnumerable<CatalogItem>> GetAllItems();
        Task<IEnumerable<CatalogItem>> GetById();
    }
}
