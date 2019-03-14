using Repository.Pattern.Ef6;
using TransRoute.Entities.Db;

namespace TransRoute.Repository.Queries
{
    public class CustomerProfileQuery : QueryObject<CustomerProfile>
    {
        public CustomerProfileQuery WithCertificate(string certificate)
        {
            And(x => x.Certificate == certificate);
            return this;
        }

        public CustomerProfileQuery WithBvn(string bvn)
        {
            And(x => x.Bvn == bvn);
            return this;
        }
    }
}