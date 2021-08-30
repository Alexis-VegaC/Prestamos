using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMoney.Models
{
    public class StoresMoney
    {
        public int StoresMoneyId { get; set; }
        public double Amount { get; set; }
        public string UserId { get; set; }

        public virtual List<Movement> Movements { get; set; }
    }
}
