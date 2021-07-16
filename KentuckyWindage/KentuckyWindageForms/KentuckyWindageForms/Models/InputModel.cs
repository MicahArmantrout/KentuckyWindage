using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using KentuckyWindageForms.Attributes;

namespace KentuckyWindageForms.Models
{
    public class InputModel
    {
        [Positive] 
        public decimal TargetSizeInches { get; set; }
        [Positive]
        public decimal TargetSizeMilDots { get; set; }
        [Positive(AllowZero = true)]
        public int WindDirection { get; set; }
        [Positive]
        public int WindSpeedMph { get; set; }
    }
}
