using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;


namespace TTTT.Modles
{
    public class ProductDatabaseInitializer : DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            GetCategories().ForEach(c => context.Categories.Add(c));
            GetProducts().ForEach(p => context.Products.Add(p));
        }


        private static List<Category> GetCategories()
        {
            var categories = new List<Category> {
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "A"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "B"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "C"
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "D"
                },
                new Category
                {
                    CategoryID = 5,
                    CategoryName = "E"
                },
            };

            return categories;
        }



        private static List<Product> GetProducts()
        {
            var products = new List<Product> {
                new Product
                {
                    ProductID = 1,
                    ProductName = "A01",
                    Description = "A01商品簡介",
                    ImagePath="01.png",
                    UnitPrice = 320,
                    CategoryID = 5,
               },
                new Product
                {
                    ProductID = 2,
                    ProductName = "A02",
                    Description = "A02商品簡介",
                    ImagePath="02.png",
                    UnitPrice = 560,
                    CategoryID = 5,
               },
                new Product
                {
                    ProductID = 3,
                    ProductName = "A03",
                    Description = "A03商品簡介",
                    ImagePath="03.png",
                    UnitPrice = 420,
                    CategoryID = 5,
                },
                new Product
                {
                    ProductID = 4,
                    ProductName = "B01",
                    Description = "B01商品簡介",
                    ImagePath="04.png",
                    UnitPrice = 200,
                    CategoryID = 5,
                },
                new Product
                {
                    ProductID = 5,
                    ProductName = "B03",
                    Description = "B03商品簡介",
                    ImagePath="05.png",
                    UnitPrice = 120,
                    CategoryID = 5,
                },
                new Product
                {
                    ProductID = 6,
                    ProductName = "AB",
                    Description = "AB商品簡介",
                    ImagePath="06.png",
                    UnitPrice = 300,
                    CategoryID = 5,
                },
                new Product
                {
                    ProductID = 7,
                    ProductName = "AB01",
                    Description = "AB01商品簡介",
                    ImagePath="07.png",
                    UnitPrice = 450,
                    CategoryID = 5,
                },
                
            };

            return products;
        }





    }
}
