﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Data.Entities;

namespace WebStore.Models
{
    public class OpinionModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public string CriticLogin { get; set; }
        public DateTime Time { get; set; }
    }
}
