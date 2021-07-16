using System;
using System.Collections.Generic;
using System.Text;

namespace KentuckyWindageForms.Models
{
    public class InputViewModel : ViewModelBase
    {
        public decimal TargetSizeInches { get; set; }
        public decimal TargetSizeMilDots { get; set; }
        public WindDirection WindDirection { get; set; }
        public decimal WindageInches { get; set; }
        public decimal ElevationInches { get; set; }
        public Adjustments Adjustments { get; set; }

        public bool IsLeft
        {
            get => WindDirection == WindDirection.Left;
            set => WindDirection = value ? WindDirection.Left : WindDirection.Right;
        }
    }

    public class Adjustments
    {
        public string MoaWindage { get; set; }
        public string MoaElevation { get; set; }
    }
}
