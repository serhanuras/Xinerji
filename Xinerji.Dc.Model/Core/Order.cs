using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Core
{
    public class Order
    {
        public long Id { get; set; }

        public long FirmId { get; set; }

        public long TripId { get; set; }

        public string Title { get; set; }

        public string ConsignmentNo { get; set; }

        public string ReceiptNo { get; set; }

        public string Description { get; set; }

        public long CityId { get; set; }

        public long BranchId { get; set; }

        public string CompanyName { get; set; }

        public string BranchName { get; set; }

        public long DeliveryStatusId { get; set; }

        public string DeliveryStatus { get; set; }

        public long OrderTypeId { get; set; }

        public RecordStatusEnum Status { get; set; }
    }
}
