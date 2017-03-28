using System.Collections.Generic;
using IITInventoryManagementSystem.Models;

namespace IITInventoryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IdentitySample.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "IdentitySample.Models.ApplicationDbContext";
        }

        protected override void Seed(IdentitySample.Models.ApplicationDbContext context)
        {
            List<Category> categories = new List<Category>
            {
                new Category {Name = "Pen"},
                new Category{Name = "Computer"},
                new Category{Name = "Paper"},
                new Category{Name = "Book"},
            };
            categories.ForEach(s => context.Categories.AddOrUpdate(s));
            context.SaveChanges();

            List<ItemCategory> itemCategories = new List<ItemCategory>
            {
                new ItemCategory {Name = "EconoDX", Description = "Old is Gold",ImagePath = "",Category = categories.ElementAt(0)},
                new ItemCategory {Name = "RedLeaf",Description = "Write Swiftly",ImagePath = "",Category = categories.ElementAt(0)},
                new ItemCategory {Name = "ASUS", Description = "User Friendly Structure",ImagePath = "",Category = categories.ElementAt(1)},
                new ItemCategory {Name = "Apple",Description = "Fast Performance",ImagePath = "",Category = categories.ElementAt(1)},
                new ItemCategory {Name = "Learn C", Description = "Written By Herverd Schield",ImagePath = "",Category = categories.ElementAt(3)},
                new ItemCategory {Name = "Learn Java",Description = "Written by Details",ImagePath = "",Category = categories.ElementAt(3)},
                new ItemCategory {Name = "Kornofuli", Description = "Best writing Practice",ImagePath = "",Category = categories.ElementAt(2)},
            };
            itemCategories.ForEach(s => context.ItemCategories.AddOrUpdate(s));
            context.SaveChanges();

            List<Sector> sectors=new List<Sector>
            {
                new Sector {Name = "University of Dhaka", Description = "The best university in Bangladesh",ImagePath = "" },
                new Sector {Name = "ABC of Korea", Description = "A korea based organization that funds in education",ImagePath = "" }
            };

            sectors.ForEach(s => context.Sectors.AddOrUpdate(s));
            context.SaveChanges();

            List<Voucher> vouchers = new List<Voucher>
            {
                new Voucher {Name = "Yearly Arrival_2017", Description = "",FilePath = "",Sector = sectors.ElementAt(1)},
                new Voucher {Name = "Summer Arrival_2017", Description = "",FilePath = "",Sector = sectors.ElementAt(1) },
            };

            vouchers.ForEach(s => context.Vouchers.AddOrUpdate(s));
            context.SaveChanges();

            List<ItemArrival> itemArrivals=new List<ItemArrival>
            {
                new ItemArrival {Date =  DateTime.Now,Voucher = vouchers.ElementAt(1)},
                new ItemArrival {Date =  DateTime.Now,Voucher = vouchers.ElementAt(0)}
            };
            itemArrivals.ForEach(s => context.ItemArrivals.AddOrUpdate(s));
            context.SaveChanges();

            List<Item> items=new List<Item>
            {
                new Item {IsAvailable = false,Location = "Room-303",ItemCategory =itemCategories.ElementAt(2),Arrival = itemArrivals.ElementAt(0)},
                new Item {IsAvailable = false,Location = "Room-304",ItemCategory =itemCategories.ElementAt(1),Arrival = itemArrivals.ElementAt(1)},
                new Item {IsAvailable = false,Location = "Room-303",ItemCategory =itemCategories.ElementAt(3),Arrival = itemArrivals.ElementAt(0)},
                new Item {IsAvailable = true,Location = "Room-302",ItemCategory =itemCategories.ElementAt(2),Arrival = itemArrivals.ElementAt(0)},
                new Item {IsAvailable = true,Location = "Room-303",ItemCategory =itemCategories.ElementAt(4),Arrival = itemArrivals.ElementAt(0)},
                new Item {IsAvailable = true,Location = "Room-303",ItemCategory =itemCategories.ElementAt(1),Arrival = itemArrivals.ElementAt(0)},
                new Item {IsAvailable = true,Location = "Room-304",ItemCategory =itemCategories.ElementAt(3),Arrival = itemArrivals.ElementAt(1)},
                new Item {IsAvailable = true,Location = "Room-303",ItemCategory =itemCategories.ElementAt(2),Arrival = itemArrivals.ElementAt(1)}
            };
            items.ForEach(s => context.Items.AddOrUpdate(s));
            context.SaveChanges();

            List<RequisitionSlip> requisitionSlips = new List<RequisitionSlip>
            {
                new RequisitionSlip {Purpose = "Educational",ApplicationDate = DateTime.Now,RecommendationDate = DateTime.Now,VerificationDate = DateTime.Now,ApplicantId ="",RecommenderId = "",VerifierId = "",RejectionCause=""},
            };
            requisitionSlips.ForEach(s => context.RequisitionSlips.AddOrUpdate(s));
            context.SaveChanges();

            List<RequisedItem> requisedItems = new List<RequisedItem>
            {
                new RequisedItem {Item = items.ElementAt(0),RequisitionSlip= requisitionSlips.ElementAt(0)},
                new RequisedItem {Item = items.ElementAt(1),RequisitionSlip= requisitionSlips.ElementAt(0)},
                new RequisedItem {Item = items.ElementAt(2),RequisitionSlip= requisitionSlips.ElementAt(0)}
            };
            requisedItems.ForEach(s => context.RequisedItems.AddOrUpdate(s));
            context.SaveChanges();


            List<Cart> carts = new List<Cart>
            {
                new Cart {AddingTime = DateTime.Now,Item = items.ElementAt(3)}

            };
            carts.ForEach(s => context.Carts.AddOrUpdate(s));
            context.SaveChanges();

        }
    }
}
