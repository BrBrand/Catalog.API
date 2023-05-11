using Onis.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onis.Domain.Entities
{
    public class CatalogItem : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string PictureUri { get; private set; }
        public int CatalogTypeId { get; private set; }
        public CatalogType? CatalogType { get; private set; }
        public int CatalogBrandId { get; private set; }
        public CatalogBrand? CatalogBrand { get; private set; }

        public CatalogItem(int catalogTypeId,
            int catalogBrandId,
            string description,
            string name,
            decimal price,
            string pictureUri)
        {
            CatalogTypeId = catalogTypeId;
            CatalogBrandId = catalogBrandId;
            Description = description;
            Name = name;
            Price = price;
            PictureUri = pictureUri;
        }

        public void UpdateDetails(CatalogItemDetails details)
        {
            Name = details.Name;
            Description = details.Description;
            Price = details.Price;
        }
    }
    /// <summary>
    /// Immutable object to modify the entity
    /// </summary>
    public readonly record struct CatalogItemDetails
    {
        public string? Name { get; }
        public string? Description { get; }
        public decimal Price { get; }

        public CatalogItemDetails(string? name, string? description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }
    }
}

