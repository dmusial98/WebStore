using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Models
{
    public class StoreHoursModel
    {
        public int Id { get; set; }
        public DayOfWeek Day { get; set; }
        public string OpenHour { get; set; }
        public string CloseHour { get; set; }
        public StoreModel Store { get; set; }
        public int StoreId { get; set; }
    }
}
