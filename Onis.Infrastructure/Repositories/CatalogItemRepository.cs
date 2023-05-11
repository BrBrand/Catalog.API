using Microsoft.EntityFrameworkCore;
using Onis.Domain.Contracts;
using Onis.Domain.Entities;
using Onis.Infrastructure.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onis.Infrastructure.Repositories
{
    public class CatalogItemRepository : Repository<CatalogItem>, ICatalogItemRepository
    {
        public CatalogItemRepository(CatalogDBContext context) : base(context) {
                
                

        }
        

        public async Task<IEnumerable<CatalogItem>> GetAllItems()
        {
            var products = await _context.CatalogItems.ToListAsync();
            return products;
        }

        public async Task<IEnumerable<CatalogItem>> GetById()
        {
            var products = await _context.CatalogItems.ToListAsync();
            return products;
        }
    }
}
