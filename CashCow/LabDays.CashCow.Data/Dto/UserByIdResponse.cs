using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabDays.CashCow.Data.Dto
{
    public class UserByIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime JoiningDate { get; set; }

        public string CashCowCode { get; set; }
    }
}
