﻿
using BlazorEcomm.Shared;
using BlazorEcomm.Shared.Dtos;

namespace BlazorEcomm.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context; 
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<Product>> CreateProduct(Product product)
        {
            foreach (var variant in product.Variants)
            {
                variant.ProductType = null;
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return new ServiceResponse<Product> { Data = product };
        }

        public async Task<ServiceResponse<bool>> DeleteProduct(int productId)
        {

            var dbProduct = await _context.Products.FindAsync(productId);
            if(dbProduct == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Product not found."
                };
            }

            dbProduct.Deleted = true;
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool>
            {
                Success = true,
                Data = true,
                Message = "Product deleted successfully."
            };
        }

        public async Task<ServiceResponse<List<Product>>> GetAdminProducts()
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products
                   .Where(p => !p.Deleted)
                   .Include(p => p.Variants.Where(v => !v.Deleted))
                   .ThenInclude(v => v.ProductType)
                   .ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetFeaturedProducts()
        {

            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products
                    .Where(p => p.Featured && p.Visibility && !p.Deleted)
                    .Include(p => p.Variants.Where(v => v.Visibility && !v.Deleted))
                    .ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
        {
            var response = new ServiceResponse<Product>();
            Product product = null;

            if (_httpContextAccessor.HttpContext.User.IsInRole("Admin"))
            {
                 product = await _context.Products
                           .Include(p => p.Variants.Where(v => !v.Deleted))
                           .ThenInclude(v => v.ProductType)
                           .FirstOrDefaultAsync(p => p.Id == productId && !p.Deleted);

            }
            else
            {

                product = await _context.Products
                           .Include(p => p.Variants.Where(v => v.Visibility && !v.Deleted))
                           .ThenInclude(v => v.ProductType)
                           .FirstOrDefaultAsync(p => p.Id == productId && !p.Deleted && p.Visibility);

            }


            if (product == null)
            {
                response.Success = false;
                response.Message = "Product doesn't exist";
            }
            else
            {
                response.Success = true;
                response.Data = product;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products
                .Where(p => p.Visibility && !p.Deleted)
                .Include(p => p.Variants.Where(v => v.Visibility && !v.Deleted)).ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(string categoryUrl)
        {
            var response = new ServiceResponse<List<Product>>
            {
                Data = await _context.Products
                        .Where(p => p.Category.Url.ToLower() == categoryUrl.ToLower() && p.Visibility && !p.Deleted)
                        .Include(p=> p.Variants)
                        .ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText)
        {
            var products = await FindProductsBySearchText(searchText);
            
            List<string> result = new List<string>();

            foreach (var product in products)
            {
                if (product.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(product.Title);
                }

                if (product.Description !=null )
                {
                    var punctuations = product.Description.Where(char.IsPunctuation).Distinct().ToArray();
                    var words = product.Description.Split().Select(s=>s.Trim(punctuations));

                    foreach (var word in words)
                    {
                        if (word.Contains(searchText, StringComparison.OrdinalIgnoreCase) && 
                            !result.Contains(word))
                        {
                            result.Add(word);
                        }
                    }
                     
                }
            }
            return new ServiceResponse<List<string>> { Data = result };
        }

        public async Task<ServiceResponse<ProductSearchResult>> SearchProducts(string searchText, int page)
        {
            var pageResults = 2f;
            var pageCount = Math.Ceiling((await FindProductsBySearchText(searchText)).Count / pageResults);



            var products = await _context.Products
                                    .Where(p => p.Title.ToLower().Contains(searchText.ToLower()) 
                                    || p.Description.ToLower().Contains(searchText.ToLower()) 
                                    && p.Visibility && !p.Deleted)
                                    .Include(p => p.Variants)
                                    .Skip((page - 1) * (int)pageResults)
                                    .Take((int)pageResults)
                                    .ToListAsync();

            var response = new ServiceResponse<ProductSearchResult>
            {
                Data = new ProductSearchResult
                        {
                            Products = products,
                            CurrentPage = page,
                            Pages = (int) pageCount
                }
            };
                
             
            return response;
        }

        public async Task<ServiceResponse<Product>> UpdateProduct(Product product)
        {
            var dbProduct = await _context.Products.FindAsync(product.Id);
            if (dbProduct == null)
            {
                return new ServiceResponse<Product>
                {
                    Success = false,
                    Message = "Product not found."
                };
            }

            dbProduct.Title = product.Title;
            dbProduct.Description = product.Description;
            dbProduct.ImageUrl = product.ImageUrl;
            dbProduct.CategoryId = product.CategoryId;
            dbProduct.Visibility = product.Visibility;
            dbProduct.Featured = product.Featured;

            foreach (var variant in product.Variants)
            {
                var dbVariant = await _context.ProductVariants
                                .SingleOrDefaultAsync(v => v.ProductId == variant.ProductId &&
                                v.ProductTypeId == variant.ProductTypeId);
                if(dbVariant == null)
                {
                    variant.ProductType = null;
                    _context.ProductVariants.Add(variant);
                }
                else
                {
                    dbVariant.ProductTypeId = variant.ProductTypeId;
                    dbVariant.Price = variant.Price;
                    dbVariant.OriginalPrice = variant.OriginalPrice;
                    dbVariant.Visibility = variant.Visibility;
                    dbVariant.Deleted = variant.Deleted;
                }
            }

            await _context.SaveChangesAsync();

            return new ServiceResponse<Product> { Data = product };
        }

        private async Task<List<Product>> FindProductsBySearchText(string searchText)
        {
            return await _context.Products
                                    .Where(p => p.Title.ToLower().Contains(searchText.ToLower()) 
                                    || p.Description.ToLower().Contains(searchText.ToLower()) 
                                    && p.Visibility && !p.Deleted)
                                    .Include(p => p.Variants)
                                    .ToListAsync();
        }
    }
}
