using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
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
    }
}