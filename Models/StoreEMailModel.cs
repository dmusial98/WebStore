﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Models
{
    public class StoreEMailModel
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public string EmailContent { get; set; }
    }
}
