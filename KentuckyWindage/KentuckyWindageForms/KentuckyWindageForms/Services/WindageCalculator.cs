using System;
using System.Collections.Generic;
using System.Text;
using KentuckyWindageForms.Models;

namespace KentuckyWindageForms.Services
{
    public class WindageCalculator
    {
        private readonly InputViewModel input;

        public WindageCalculator(InputViewModel variables)
        {
            input = variables;
        }

        public void Calculate()
        {
            // Declarations
            var elevation = 0.0d; 
            var windage = 0.0d;

            // Calculations


            // Output results
            input.Adjustments = new Adjustments()
            {
                MoaElevation = $"Elevation should be {elevation}",
                MoaWindage = $"Windage should be {windage}"
            };
        }
    }
}
