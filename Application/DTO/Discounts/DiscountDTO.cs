﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Discounts
{
    public class DiscountDTO
    {
        public string Product { get; set; }
        public int DiscountPercent { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}