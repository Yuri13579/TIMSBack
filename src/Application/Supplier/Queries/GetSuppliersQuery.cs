using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TIMSBack.Application.Common.Interfaces;
using TIMSBack.Application.Customer.Queries;

namespace TIMSBack.Application.Supplier.Queries
{
    public class GetSuppliersQuery : IRequest<List<SupplierDto>>
    {
    }

    public class GetSuppliersQueryHandler : IRequestHandler<GetSuppliersQuery, List<SupplierDto>>
    {
        private readonly IApplicationDbContext _context;


        public GetSuppliersQueryHandler(IApplicationDbContext context

        )
        {
            _context = context;

        }

        public async Task<List<SupplierDto>> Handle(GetSuppliersQuery request, CancellationToken cancellationToken)
        {
            var result = (
                from suppliers in _context.Suppliers
                join countries in _context.Countries on suppliers.CountryId equals countries.Id
                join categorySuppliers in _context.CategorySuppliers on suppliers.CategorySupplierId equals categorySuppliers.Id
                join termsOfPayments in _context.TermsOfPayments on suppliers.TermsOfPaymentId equals termsOfPayments.Id

                select new SupplierDto
                {
                    Id = suppliers.Id,
                    Name = suppliers.Name,
                    Email = suppliers.Email,
                    City = suppliers.City,
                    Country = countries.Name,
                    CategorySupplierId = categorySuppliers.Id,
                    CategorySupplier = categorySuppliers.Name,
                    TaxLocation = suppliers.TaxLocation,
                    TermsOfPaymentId = termsOfPayments.Id,
                    TermsOfPayment = termsOfPayments.Name
                    
                }).ToList();

            var supplierPaymentHistoricist = _context.SupplierPaymentHistories.ToList();
            result.ForEach(x => x.TheyOwnYou = supplierPaymentHistoricist.Where(y => y.SupplierId == x.Id).Select(z => z.TheyOwnYou).ToList().Sum());
            result.ForEach(x => x.YouOwnThem = supplierPaymentHistoricist.Where(y => y.SupplierId == x.Id).Select(z => z.YouOwnThem).ToList().Sum());
            result.ForEach(x => x.Balance = supplierPaymentHistoricist.Where(y => y.SupplierId == x.Id).Select(z => z.Balance).ToList().Sum());

            return await Task.FromResult(result);
        }
    }


}
