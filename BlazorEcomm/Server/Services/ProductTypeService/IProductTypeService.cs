namespace BlazorEcomm.Server.Services.ProductTypeService
{
    public interface IProductTypeService
    {
        Task<ServiceResponse<List<ProductType>>> GetProductTypes();
        Task<ServiceResponse<List<ProductType>>> AddProductType(ProductType request);
        Task<ServiceResponse<List<ProductType>>> UpdateProductType(ProductType request);
    }
}
