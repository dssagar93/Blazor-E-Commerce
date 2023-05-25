﻿
using BlazorEcomm.Shared;
using BlazorEcomm.Shared.Dtos;

namespace BlazorEcomm.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Product> Products { get; set; } = new List<Product>();
        public string Message { get; set; } = "Loading Products";
        public int CurrentPage { get; set; } = 0;
        public int PageCount { get; set; } = 0;
        public string LastSearchText { get; set; } = string.Empty;
        public List<Product> AdminProducts { get; set; }

        public event Action ProductsChanged;

        public async Task<Product> CreateProduct(Product product)
        {
            var result = await _httpClient.PostAsJsonAsync("api/product", product);

            var newProduct = (await result.Content.ReadFromJsonAsync<ServiceResponse<Product>>()).Data;
            return newProduct;
        }

        public async Task DeleteProduct(Product product)
        {
            Console.WriteLine("Deleting.....", product);
            var result = await _httpClient.DeleteAsync($"api/product/{product.Id}");
        }

        public async Task GetAdminProducts()
        {
            var result = await _httpClient
                .GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/admin");

            AdminProducts = result.Data;
            CurrentPage = 1;
            PageCount = 0;
            if(AdminProducts.Count == 0)
            {
                Message = "No products found.";
            }
        }

        public async Task<ServiceResponse<Product>> GetProduct(int productId)
        {
            var result =
               await _httpClient.GetFromJsonAsync<ServiceResponse<Product>>($"api/Product/{productId}");
            return result;
        }

        public async Task GetProducts(string? categoryUrl = null)
        {

            var result = categoryUrl == null ?
                await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product/featured"):
                await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/category/{categoryUrl}");

            if (result.Data != null && result != null)
                Products = result.Data;

            CurrentPage = 1;
            PageCount = 0;
            if(Products.Count == 0)
            {
                Message = "No products found";
            }
            ProductsChanged.Invoke();
        }

        public async Task<List<string>> GetProductSearchSuggestions(string searchText)
        {
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/product/searchSuggestions/{searchText}");
            return result.Data;
        }

        public async Task SearchProduct(string searchText, int page)
        {
            LastSearchText = searchText;

            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<ProductSearchResult>>($"api/product/search/{searchText}/{page}");

            if (result!=null && result.Data!=null)
            {
                Products = result.Data.Products;
                PageCount = result.Data.Pages;
            }
            if (Products.Count == 0)
            {
                Message = "No Products Found";
            }
            ProductsChanged.Invoke();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/product", product);
            return (await result.Content.ReadFromJsonAsync<ServiceResponse<Product>>()).Data;

        }
    }
}
