using Repository.Pattern.Ef6;
using TransRoute.Entities.Db;

namespace TransRoute.Repository.Queries
{
    public class CustomerSalesQuery : QueryObject<CustomerAccounnt>
    {
        public CustomerSalesQuery WithAccountType(string acctType)
        {
            And(x => x.AccountType == acctType);
            return this;
        }

        public CustomerSalesQuery WithBvn(string bvn)
        {
            And(x => x.Bvn == bvn);
            return this;
        }
    }
}