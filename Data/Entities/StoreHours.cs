using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Data.Entities
{
    public class StoreHours
    {
        public int Id { get; set; }
        public DayOfWeek Day { get; set; }
        public string OpenHour { get; set; }
        public string CloseHour { get; set; }
        //public Store Store { get; set; }
        public int StoreId { get; set; }
    }
}
