using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Core;

namespace Xinerji.Dc.Internet.Model
{
    public class TripOrder
    {
        public long OrderId { get; set; }

        public string Title { get; set; }

        public string ConsignmentNo { get; set; }

        public string ReceiptNo { get; set; }

        public string Description { get; set; }

        public string CompanyName { get; set; }

        public string BranchName { get; set; }

        public string Location { get; set; }

        public string Adress { get; set; }

        public long DeliveryStatusId { get; set; }

        public long DeliverySubStatusId { get; set; }

        public string DeliveryStatus { get; set; }

        public List<OrderRepresenter> OrderRepresenterList { get; set; }

        public List<OrderDetail> OrderDetailList { get; set; }
    }
}
