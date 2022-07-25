using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

            /*  context.Database.EnsureDeleted();
              context.Database.EnsureCreated();*/

            // string input = File.ReadAllText("../../../Datasets/categories-products.json");

            var result = GetUsersWithProducts(context);
            Console.WriteLine(result);
        }


        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categoriesDto = JsonConvert.DeserializeObject<List<Category>>(inputJson);

            var categories = new List<Category>();
            foreach (var category in categoriesDto)
            {
                if (category.Name == null)
                {
                    continue;
                }
                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(p => p.Price > 500 && p.Price <= 1000)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .OrderBy(p => p.price)
                .ToList();

            var productSerilize = JsonConvert.SerializeObject(products, Formatting.Indented);

            return productSerilize;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                            .Select(u => new
                            {
                                u.FirstName,
                                u.LastName,
                                SoldProducts = u.ProductsSold
                                .Where(i => i.BuyerId != null)
                                .Select(ps => new
                                {
                                    ps.Name,
                                    ps.Price,
                                    BuyerFirstName = ps.Buyer.FirstName,
                                    BuyerLastName = ps.Buyer.LastName

                                })
                            })
                            .OrderBy(u => u.LastName)
                            .ThenBy(u => u.FirstName)
                            .ToList()
                            .Where(u => u.SoldProducts.Count() > 0);

            var jsonValue = JsonConvert.SerializeObject(users, Formatting.Indented);

            return jsonValue;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .OrderByDescending(c => c.CategoryProducts.Count())
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count(),
                    averagePrice = $"{c.CategoryProducts.Average(cp => cp.Product.Price):f2}",
                    totalRevenue = $"{c.CategoryProducts.Sum(cp => cp.Product.Price):f2}"
                }).ToList();

            var jsonValue = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return jsonValue;

        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Include(x => x.ProductsSold)
                .ToList()
                .Where(x => x.ProductsSold.Any(p => p.BuyerId != null))
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = new
                    {
                        Count = x.ProductsSold.Where(p => p.BuyerId != null).Count(),
                        Products = x.ProductsSold.Where(p => p.BuyerId != null).Select(p => new
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .ToList()
                    }
                })
                .OrderByDescending(x => x.SoldProducts.Count)
                .ToList();

            var result = new
            {
                UsersCount = users.Count(),
                Users = users
            };

            var jsonValue = JsonConvert.SerializeObject(result, Formatting.Indented);

            return jsonValue;
        }


    }
}