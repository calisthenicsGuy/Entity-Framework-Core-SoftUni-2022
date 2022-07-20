using AutoMapper;
using ProductShop.DTOs.Categories;
using ProductShop.DTOs.CategoryProducts;
using ProductShop.DTOs.Products;
using ProductShop.DTOs.Users;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImportUserDto, User>();
            this.CreateMap<ImportProductDto, Product>();
            this.CreateMap<ImportCategoryDto, Category>();
            this.CreateMap<ImportCategoryProductsDto, CategoryProduct>();

            this.CreateMap<Product, ExportProductDto>()
                .ForMember(d => d.Seller, mo => mo.MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));

            this.CreateMap<Product, ExportSoldProductDto>()
                .ForMember(d => d.BuyerFirstName, mo => mo.MapFrom(s => s.Buyer.FirstName))
                .ForMember(d => d.BuyerLastName, mo => mo.MapFrom(s => s.Buyer.LastName));
            this.CreateMap<User, ExportUserProductsDto>()
                .ForMember(d => d.SoldProducts, mo => mo.MapFrom(s => s.ProductsSold
                .Where(p => p.BuyerId.HasValue)));

            this.CreateMap<Category, ExportCategoriesByProductsCountDto>()
                .ForMember(d => d.ProductsCount, 
                    mo => mo.MapFrom(s => s.CategoryProducts.Count))
                .ForMember(d => d.AveragePrice,
                    mo => mo.MapFrom(s => s.CategoryProducts.Average(p => p.Product.Price)))
                .ForMember(d => d.TotalRevenue, 
                    mo => mo.MapFrom(s => s.CategoryProducts.Sum(p => p.Product.Price)));


            this.CreateMap<Product, ExportSingleProductForUserDto>();
            this.CreateMap<User, ExportSoldProductsForUserDto>()
                .ForMember(d => d.Products, mo => mo.MapFrom(s => s.ProductsSold.Where(p => p.BuyerId.HasValue)));

            this.CreateMap<User, ExportUsersWithHisProductsDto>()
                .ForMember(d => d.SoldProducts, mo => mo.MapFrom(s => s));
        }
    }
}
