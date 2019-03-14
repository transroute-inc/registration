using System;
using System.Collections.Generic;
using System.Linq;
using TransRoute.Repository.Models;
using TransRoute.Service;

namespace TransRoute.Console
{
    class ArchiveNoTest
    {
        private readonly IArchiveNoService _srv;

        public ArchiveNoTest(IArchiveNoService srv)
        {
            _srv = srv;
        }

       
        public IEnumerable<ArchiveNoVm> GetAll()
        {
            return (_srv.Queryable()).Where(f=>string.IsNullOrWhiteSpace(f.Phone)).Select(c=> new ArchiveNoDetail()
            {
                PhoneNo = c.Phone,
                CreatedDate = c.DateCreated,
                Id = c.Id
            });
        }
    }
}
