//create ICatalogService interface with a method that returns a list of projects

using EshopOnAI.ProductGenerator.Models;

namespace EshopOnAI.ProductGenerator.Services
{
    public interface ICatalogService
    {
        Task<List<CatalogBrand>> GetProjectsAsync(List<Root> data);
        Task<List<CatalogType>> GetCatalogTypesAsync(List<Root> data);
        Task<List<CatalogItem>> GetCatalogItemsAsync(List<Root> data);
    }
}