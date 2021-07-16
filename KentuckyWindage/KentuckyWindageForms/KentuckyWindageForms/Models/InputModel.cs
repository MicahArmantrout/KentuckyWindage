using System;
using System.Collections.Generic;
using System.Text;

namespace KentuckyWindageForms.Models
{
    public class InputModel
    {
        public decimal TargetSizeInches { get; set; }
        public decimal TargetSizeMilDots { get; set; }
        public WindDirection WindDirection { get; set; }
        public decimal WindageInches { get; set; }
        public decimal ElevationInches { get; set; }
    }
}
