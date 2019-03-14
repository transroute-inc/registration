using System;
using System.Linq.Expressions;
using Repository.Pattern.Ef6;
using TransRoute.Entities.Db;

namespace TransRoute.Repository.Queries
{
    public class ArchiveNoQuery : QueryObject<ArchiveNo>
    {
      
        public string PhoneNo { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public override Expression<Func<ArchiveNo, bool>> Query()
        {
            return (x =>
                //  x.OrderDetails.Sum(y => y.UnitPrice) > Amount &&
                
                    x.DateCreated >= FromDate &&
                    x.DateCreated <= ToDate);
            //x.ShipCountry == Country);
        }
    }
}