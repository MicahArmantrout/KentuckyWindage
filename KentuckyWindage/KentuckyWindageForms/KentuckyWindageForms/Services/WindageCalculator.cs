using System;
using System.Collections.Generic;
using System.Text;
using KentuckyWindageForms.Models;

namespace KentuckyWindageForms.Services
{
    public class WindageCalculator
    {
        private readonly InputModel input;

        public WindageCalculator(InputModel variables)
        {
            input = variables;
        }

        public AdjustmentModel Calculate()
        {
            // Declarations
            var elevation = 0.0m; 
            var windage = 0.0m;

            // Calculations
            elevation = input.WindSpeedMph + input.WindDirection;
            windage = input.TargetSizeInches + input.TargetSizeMilDots;

            // Output results
            return new AdjustmentModel()
            {
                MoaElevation = elevation,
                MoaWindage = windage
            };
        }
    }
}
