using System.Collections.Generic;
using System.Linq;
using Repository.Pattern.Repositories;
using TransRoute.Entities.Db;
using TransRoute.Repository.Models;

namespace TransRoute.Repository.Repositories
{
    // Exmaple: How to add custom methods to a repository.
    public static class ArchiveNoRepository
    {
        //public static decimal GetCustomerOrderTotalByYear(this IRepository<ArchiveNo> repository, string customerId, int year)
        //{
        //    return repository
        //        .Queryable()
        //        .Where(c => c.CustomerID == customerId)
        //        .SelectMany(c => c.Orders.Where(o => o.OrderDate != null && o.OrderDate.Value.Year == year))
        //        .SelectMany(c => c.OrderDetails)
        //        .Select(c => c.Quantity*c.UnitPrice)
        //        .Sum();
        //}

        public static IEnumerable<ArchiveNo> CustomersByCompany(this IRepositoryAsync<ArchiveNo> repository, string companyName)
        {
            return repository
                .Queryable()
                .Where(x => x.Phone.Contains(companyName))
                .AsEnumerable();
        }

        //public static IEnumerable<CustomerOrder> GetCustomerOrder(this IRepository<Customer> repository, string country)
        //{
        //    var customers = repository.GetRepository<Customer>().Queryable();
        //    var orders = repository.GetRepository<Order>().Queryable();

        //    var query = from c in customers
        //        join o in orders on new {a = c.CustomerID, b = c.Country}
        //            equals new {a = o.CustomerID, b = country}
        //        select new CustomerOrder
        //        {
        //            CustomerId = c.CustomerID,
        //            ContactName = c.ContactName,
        //            OrderId = o.OrderID,
        //            OrderDate = o.OrderDate
        //        };

        //    return query.AsEnumerable();
        //}
    }
}