using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabDays.CashCow.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime JoiningDate { get; set; }
        public string TokenIdentifier { get; set; }
        public decimal SubscriptionAmount { get; set; }
    }
}
