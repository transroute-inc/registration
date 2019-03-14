#region

using System.Collections.Generic;
using Repository.Pattern.Repositories;
using Service.Pattern;
using TransRoute.Entities.Db;

#endregion

namespace TransRoute.Service
{
    /// <summary>
    ///     Add any custom business logic (methods) here
    /// </summary>
    public interface IArchiveNoService : IService<ArchiveNo>
    {
        decimal CustomerOrderTotalByYear(string customerId, int year);
        IEnumerable<ArchiveNo> CustomersByCompany(string companyName);
        IEnumerable<ArchiveNo> GetCustomerOrder(string country);
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class ArchiveNoService : Service<ArchiveNo>, IArchiveNoService
    {
        private readonly IRepositoryAsync<ArchiveNo> _repository;

        public ArchiveNoService(IRepositoryAsync<ArchiveNo> repository) : base(repository)
        {
            _repository = repository;
        }


        public override void Delete(object id)
        {
            // e.g. add business logic here before deleting
            base.Delete(id);
        }

        public decimal CustomerOrderTotalByYear(string customerId, int year)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ArchiveNo> CustomersByCompany(string companyName)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ArchiveNo> GetCustomerOrder(string country)
        {
            throw new System.NotImplementedException();
        }
    }
}