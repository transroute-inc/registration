#region

using System.Collections.Generic;
using System.Linq;
using Repository.Pattern.Repositories;
using Service.Pattern;
using TransRoute.Entities.Db;

#endregion

namespace TransRoute.Service
{
    /// <summary>
    ///     Add any custom business logic (methods) here
    /// </summary>
    public interface ICustomerProfileService : IService<CustomerProfile>
    {
        IEnumerable<CustomerProfile> CustomeProfileByAccountNo(string acctNo);
        IEnumerable<CustomerProfile> CustomeProfileByBvn(string email);
        IEnumerable<CustomerProfile> CustomeProfileByPhoneNo(string phoneNo);
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class CustomerProfileService : Service<CustomerProfile>, ICustomerProfileService
    {
        private readonly IRepositoryAsync<CustomerProfile> _repository;

        public CustomerProfileService(IRepositoryAsync<CustomerProfile> repository) : base(repository)
        {
            _repository = repository;
        }


        public override void Delete(object id)
        {
            // e.g. add business logic here before deleting
            base.Delete(id);
        }


        public IEnumerable<CustomerProfile> CustomeProfileByAccountNo(string acctNo)
        {
            return _repository.Queryable().Where(d => d.CustomerAccounnts.Any(e => e.AccountNo == acctNo));
        }

        public IEnumerable<CustomerProfile> CustomeProfileByBvn(string bvn)
        {
            return _repository.Queryable().Where(a => a.Bvn == bvn);
        }

        public IEnumerable<CustomerProfile> CustomeProfileByPhoneNo(string phoneNo)
        {
            return _repository.Queryable().Where(a => a.PhoneNo == phoneNo);
        }
 
    }
}