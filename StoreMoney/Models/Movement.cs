using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMoney.Models
{
    public class Movement
    { 
        public int MovementId { get; set; }
        public string Operation { get; set; }
        public DateTime Date { get; set; }
        public double Quantity { get; set; }

        public string Description { get; set; }

        public int StoreMoneyId { get; set; }

        public virtual StoresMoney StoreMoney { get; set; }
    }
}
