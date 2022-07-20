using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Categories;
using ProductShop.DTOs.CategoryProducts;
using ProductShop.DTOs.Products;
using ProductShop.DTOs.Users;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static IMapper mapper;
        public static void Main(string[] args)
        {
            mapper = new Mapper(new MapperConfiguration(config =>
            {
                config.AddProfile<ProductShopProfile>();
            }));

            using ProductShopContext dbContext = new ProductShopContext();

            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();

            // P01: 
            /* string jsonInput = File.ReadAllText(@"..\..\..\Datasets\users.json");
            Console.WriteLine(ImportUsers(dbContext, jsonInput)); */

            /* string jsonInput = File.ReadAllText(@"..\..\..\Datasets\products.json");
            Console.WriteLine(ImportProducts(dbContext, jsonInput)); */

            /* string jsonInput = File.ReadAllText(@"..\..\..\Datasets\categories.json");
            Console.WriteLine(ImportCategories(dbContext, jsonInput)); */

            /* string jsonInput = File.ReadAllText(@"..\..\..\Datasets\categories-products.json");
            Console.WriteLine(ImportCategoryProducts(dbContext, jsonInput)); */

            // P02:
            // File.WriteAllText(@"..\..\..\ExportResults\products-in-range.json", GetProductsInRange(dbContext));
            // File.WriteAllText(@"..\..\..\ExportResults\users-sold-products.json", GetSoldProducts(dbContext));
            // File.WriteAllText(@"..\..\..\ExportResults\users-and-products.json", GetUsersWithProducts(dbContext));


            dbContext.Dispose();
        }


        // Problem 01: Import Data -> Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            ICollection<ImportUserDto> usersDto =
                JsonConvert.DeserializeObject<List<ImportUserDto>>(inputJson);

            ICollection<User> users = new List<User>();
            foreach (ImportUserDto userDto in usersDto)
            {
                User user = mapper.Map<User>(userDto);
                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        // Problem 01: Import Data -> Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            ICollection<ImportProductDto> productDtos =
                JsonConvert.DeserializeObject<List<ImportProductDto>>(inputJson);

            ICollection<Product> products = new List<Product>();
            foreach (ImportProductDto productDto in productDtos)
            {
                products.Add(mapper.Map<Product>(productDto));
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        // Problem 01: Import Data -> Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            ICollection<ImportCategoryDto> categoryDtos =
                JsonConvert.DeserializeObject<List<ImportCategoryDto>>(inputJson);

            ICollection<Category> categories = new List<Category>();
            foreach (ImportCategoryDto categoryDto in categoryDtos)
            {
                categories.Add(mapper.Map<Category>(categoryDto));
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        // Problem 01: Import Data -> Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            ICollection<ImportCategoryProductsDto> categoryProductsDto =
                JsonConvert.DeserializeObject<IList<ImportCategoryProductsDto>>(inputJson);

            ICollection<CategoryProduct> categoryProducts = new List<CategoryProduct>();
            foreach (ImportCategoryProductsDto categoryProductDto in categoryProductsDto)
            {
                categoryProducts.Add(mapper.Map<CategoryProduct>(categoryProductDto));
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        // Problem 02: Export Data -> Export Products in Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            //ExportProductDto[] productDtos = context.Products
            //    .Where(p => p.Price >= 500 && p.Price <= 1000)
            //    .OrderBy(p => p.Price)
            //    .ProjectTo<ExportProductDto>()
            //    .ToArray();

            var productDtos = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                });

            return JsonConvert.SerializeObject(productDtos, Formatting.Indented);
        }

        // Problem 02: Export Data -> Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            ExportUserProductsDto[] users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ProjectTo<ExportUserProductsDto>(mapper.ConfigurationProvider)
                .ToArray();

            return JsonConvert.SerializeObject(users, Formatting.Indented);
        }

        // Problem 02: Export Data -> Export Categories by Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            ExportCategoriesByProductsCountDto[] categories = context.Categories
                .ProjectTo<ExportCategoriesByProductsCountDto>(mapper.ConfigurationProvider)
                .ToArray();

            return JsonConvert.SerializeObject(categories.OrderBy(c => c.ProductsCount), Formatting.Indented);
        }

        // Problem 02: Export Data -> Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            ExportUsersWithHisProductsDto[] users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                .OrderByDescending(u => u.ProductsSold.Count(p => p.BuyerId.HasValue))
                .ProjectTo<ExportUsersWithHisProductsDto>(mapper.ConfigurationProvider)
                .ToArray();

            ExportUsersInfo setDto = new ExportUsersInfo()
            {
                Users = users
            };


            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
            };

            return JsonConvert.SerializeObject(setDto, Formatting.Indented, settings);
        }
    }
}