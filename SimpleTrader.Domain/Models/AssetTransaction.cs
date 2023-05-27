using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Models
{
    public class AssetTransaction : DomainObject
    {
        [Required]
        public Account Account { get; set; }
        public bool IsPurchase { get; set; }
        public Stock Stock { get; set; }
        public int ShareAmount { get; set; }

    }
}
