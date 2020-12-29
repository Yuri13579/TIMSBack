using TIMSBack.Application.Common.Interfaces;
using TIMSBack.Domain.Common;
using TIMSBack.Domain.Entities;
using TIMSBack.Infrastructure.Identity;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using System.Data;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TIMSBack.Domain;
using TIMSBack.Domain.Entities.Auth;
using TIMSBack.Domain.Entities.Inventory;
using TIMSBack.Domain.Entities.Manufacturing;

namespace TIMSBack.Infrastructure.Persistence
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;
        private IDbContextTransaction _currentTransaction;

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            ICurrentUserService currentUserService,
            IDateTime dateTime) : base(options, operationalStoreOptions)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
           // Database.EnsureDeleted();   // удаляем бд со старой схемой
           // Database.EnsureCreated();   // создаем бд с новой схемой
        }

        public DbSet<TodoList> TodoLists { get; set; }

        public DbSet<TodoItem> TodoItems { get; set; }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDescription> ProductDescriptions { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategorys { get; set; }
        public DbSet<ProductOnHand> ProductOnHands { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<ProductTrademark> ProductTrademarks { get; set; }
        public DbSet<ProductUnit> ProductUnits { get; set; }
        public DbSet<Trademark> Trademarks { get; set; }
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CategoryCustomer> CategoryCustomers { get; set; }
        public DbSet<CategorySupplier> CategorySuppliers { get; set; }
        public DbSet<PriceTier> PriceTiers { get; set; }
        public DbSet<TermsOfPayment> TermsOfPayments { get; set; }
        public DbSet<CustomerPaymentHistory> CustomerPaymentHistories { get; set; }
        public DbSet<SupplierPaymentHistory> SupplierPaymentHistories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Status>  Statuses { get; set; }
        public DbSet<QuantityStatus> QuantityStatuses { get; set; }
        public DbSet<ShippingStatus> ShippingStatuses { get; set; }
        public DbSet<PaymentStatus> PaymentStatuses { get;  set; }
        public DbSet<WareHouse> WareHouses { get;  set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<Transfer> Transfers { get; set; }


        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        //{
        //    //foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        //    //{
        //    //    switch (entry.State)
        //    //    {
        //    //        case EntityState.Added:
        //    //            entry.Entity.CreatedBy = _currentUserService.UserId;
        //    //            entry.Entity.Created = _dateTime.Now;
        //    //            break;
        //    //        case EntityState.Modified:
        //    //            entry.Entity.LastModifiedBy = _currentUserService.UserId;
        //    //            entry.Entity.LastModified = _dateTime.Now;
        //    //            break;
        //    //    }
        //    //}

        //    return base.SaveChangesAsync(cancellationToken);
        //}

        public async Task BeginTransactionAsync()
        {
            if (_currentTransaction != null)
            {
                return;
            }

            _currentTransaction = await base.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted).ConfigureAwait(false);
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync().ConfigureAwait(false);

                _currentTransaction?.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
