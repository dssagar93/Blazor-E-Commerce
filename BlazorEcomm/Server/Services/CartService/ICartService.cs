using BlazorEcomm.Shared.Dtos;

namespace BlazorEcomm.Server.Services.CartService
{
    public interface ICartService
    {
        Task<ServiceResponse<List<CartProductResponse>>> GetCartProducts(List<CartItem> cartItem);
    }
}
