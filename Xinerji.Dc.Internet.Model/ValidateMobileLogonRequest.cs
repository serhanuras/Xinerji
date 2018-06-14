using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xinerji.Dc.Model.Base;
using Xinerji.Dc.Model.Enumurations;

namespace Xinerji.Dc.Internet.Model
{
    [Serializable]
    public class ValidateMobileLogonRequest : AbstractRequest
    {

        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Plaque { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 8)]
        public string TCIdentifier { get; set; }

        public LanguageEnum Language { get; set; }
    }
}
