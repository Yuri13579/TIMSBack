﻿using System.Collections.Generic;
using TIMSBack.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace TIMSBack.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; set; }

        DbSet<TodoItem> TodoItems { get; set; }

        DbSet<Product> Products { get; set; }
        DbSet<ProductDescription> ProductDescriptions { get; set; }
        DbSet<ProductImage> ProductImages { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<ProductCategory> ProductCategorys { get; set; }
        DbSet<ProductOnHand> ProductOnHands { get; set; }
        DbSet<ProductPrice> ProductPrices { get; set; }
        DbSet<ProductTrademark> ProductTrademarks { get; set; }
        DbSet<ProductUnit> ProductUnits { get; set; }
        DbSet<Trademark> Trademarks { get; set; }

        DbSet<Domain.Entities.Customer> Customers { get; set; }
        DbSet<CategoryCustomer> CategoryCustomers { get; set; }
        DbSet<PriceTier> PriceTiers { get; set; }
        DbSet<TermsOfPayment> TermsOfPayments { get; set; }
        DbSet<CustomerPaymentHistory> CustomerPaymentHistories { get; set; }
        DbSet<Country> Countries { get; set; }
       
         DbSet<Status> Statuses { get; set; }
         DbSet<QuantityStatus> QuantityStatuses { get; set; }
         DbSet<ShippingStatus> ShippingStatuses { get;  set; }
         DbSet<PaymentStatus> PaymentStatuses { get;  set; }
         DbSet<WareHouse> WareHouses { get;  set; }
         DbSet<Domain.Entities.SalesOrder> SalesOrders { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}