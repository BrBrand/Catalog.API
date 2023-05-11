using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ardalis.Specification;
using Onis.Domain.Entities;

namespace Onis.Domain.Specifications
{
    public class CatalogItemNameSpecification : Specification<CatalogItem>
    {
        public CatalogItemNameSpecification(string catalogItemName)
        {
            Query.Where(item => catalogItemName == item.Name);
        }
    }

}

