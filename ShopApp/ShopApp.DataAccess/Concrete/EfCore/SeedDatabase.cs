﻿using Microsoft.EntityFrameworkCore;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.DataAccess.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new ShopContext();

            //Bekleyen migrations sayısı 0 ise
            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                //Daha önce bir category var mı?
                if (context.Categories.Count() == 0)
                {   
                    context.Categories.AddRange(Categories);
                }
                if (context.Products.Count() == 0)
                {
                    context.Products.AddRange(Products);
                    context.AddRange(ProductCategory);
                }
                context.SaveChanges();
            }
        }
        private static Category[] Categories = //Burdaan addRange içerisine gönderiyoruz
        {
            new Category() { Name="Telefon"},
            new Category() { Name="Bilgisayar"},
            new Category() { Name="Elektronik"}
        };

        private static Product[] Products = //Burdaan addRange içerisine gönderiyoruz
        {
            new Product(){ Name="Samsung S5", Price=2000, ImageUrl="1.jpg", Description="<p>güzel telefon</p>"},
            new Product(){ Name="Samsung S6", Price=3000, ImageUrl="2.jpg", Description="<p>güzel telefon</p>"},
            new Product(){ Name="Samsung S7", Price=4000, ImageUrl="3.jpg", Description="<p>güzel telefon</p>"},
            new Product(){ Name="Samsung S8", Price=5000, ImageUrl="4.jpg", Description="<p>güzel telefon</p>"},
            new Product(){ Name="Samsung S9", Price=6000, ImageUrl="5.jpg", Description="<p>güzel telefon</p>"},
            new Product(){ Name="IPhone 6", Price=4000, ImageUrl="6.jpg", Description="<p>güzel telefon</p>"},
            new Product(){ Name="IPhone 7", Price=5000, ImageUrl="7.jpg", Description="<p>güzel telefon</p>"}
        };

        private static ProductCategory[] ProductCategory =
        {
            new ProductCategory() { Product= Products[0],Category= Categories[0]},
            new ProductCategory() { Product= Products[0],Category= Categories[2]},
            new ProductCategory() { Product= Products[1],Category= Categories[0]},
            new ProductCategory() { Product= Products[1],Category= Categories[1]},
            new ProductCategory() { Product= Products[2],Category= Categories[0]},
            new ProductCategory() { Product= Products[2],Category= Categories[2]},
            new ProductCategory() { Product= Products[3],Category= Categories[1]}
        };
    }
}