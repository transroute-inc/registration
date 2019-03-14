using System;

namespace TransRoute.Repository.Models
{
    public class ArchiveNoVm
    {
        public string PhoneNo { get; set; }
    }

    public class ArchiveNoDetail : ArchiveNoVm
    {
        public long Id { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}