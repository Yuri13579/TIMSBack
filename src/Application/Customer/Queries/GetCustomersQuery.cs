using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TIMSBack.Application.Common.Interfaces;
using TIMSBack.Application.ProductLists.Queries.GetProducts;
using TIMSBack.Domain.Entities;

namespace TIMSBack.Application.Customer.Queries
{ 
    public class GetCustomersQuery : IRequest<List<CustomerDto>>
    {
    }

    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, List<CustomerDto>>
    {
        private readonly IApplicationDbContext _context;


        public GetCustomersQueryHandler(IApplicationDbContext context

        )
        {
            _context = context;

        }

        public async Task<List<CustomerDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var result = (
                from customers in _context.Customers
                join countries in _context.Countries on customers.CountryId equals countries.Id
                join categoryCustomers in _context.CategoryCustomers on customers.CategoryCustomerId equals categoryCustomers.Id
                join priceTiers in _context.PriceTiers on customers.PriceTierId equals priceTiers.Id
                join termsOfPayments in _context.TermsOfPayments on customers.TermsOfPaymentId equals termsOfPayments.Id

                select new CustomerDto
                {
                    Id = customers.Id,
                    Name = customers.Name,
                    Email = customers.Email,
                    City = customers.City,
                    Country = countries.Name,
                    CategoryCustomerId = categoryCustomers.Id,
                    CategoryCustomer = categoryCustomers.Name,
                    PriceTierId = priceTiers.Id,
                    PriceTier = priceTiers.Name,
                    TaxLocation = customers.TaxLocation,
                    TermsOfPaymentId = termsOfPayments.Id,
                    TermsOfPayment = termsOfPayments.Name


                }).ToList();

            var customerPaymentHistoricist = _context.CustomerPaymentHistories.ToList();
            result.ForEach(x=> x.TheyOwnYou = customerPaymentHistoricist.Where(y=> y.CustomerId == x.Id).Select(z=> z.TheyOwnYou).ToList().Sum());
            result.ForEach(x => x.YouOwnThem = customerPaymentHistoricist.Where(y => y.CustomerId == x.Id).Select(z => z.YouOwnThem).ToList().Sum());
            result.ForEach(x => x.Balance = customerPaymentHistoricist.Where(y => y.CustomerId == x.Id).Select(z => z.Balance).ToList().Sum());

            return await Task.FromResult(result);
        }
    }
}
