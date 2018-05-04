using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Model.Core
{
    public class Member
    {
        public long Id { get; set; }

        public long FirmId { get; set; }

        public string TCIdentifier { get; set; }

        public string Name { get; set; }

        public string MiddleName { get; set; }

        public string Surname { get; set; }

        public DateTime Birthdate { get; set; }

        public string Email { get; set; }

        public long CompanyId { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public long MemberTypeId { get; set; }

        public RecordStatusEnum Status { get; set; }


    }
}
