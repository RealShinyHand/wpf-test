using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Models
{
    public class Account : DomainObject
    {
        [Required]
        public User AccountHolder { get; set; }
        [DefaultValue(0.0)]
        public double Balance { get; set; }
        public IEnumerable<AssetTransaction> AssetTransactions { get; set; }

    }
}
