using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Base;

namespace Xinerji.Dc.Internet.Model
{
    [Serializable]
    public class ValidateLogonRequest : AbstractRequest
    {

        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Username { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 8)]
        public string Password { get; set; }
    }
}
