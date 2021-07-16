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
            // Calculations
            var dist = DistanceToTargetInYards(input.TargetSizeInches, input.TargetSizeMilDots);
            var adj = FindWindageAdjustment(input.WindSpeedMph, dist, input.WindDirection);
            var dir = GetWindDirection(input.WindDirection);
            var drop = GetBulletDrop(dist);

            // Output results
            return new AdjustmentModel()
            {
                MoaElevation = drop,
                MoaWindage = adj,
                MoaDirection = dir,
                MoaDistance = dist
            };
        }

        public decimal DistanceToTargetInYards(decimal targetSizeInInches, decimal targetSizeInMilDots)
        {
            decimal factor1 = targetSizeInInches * 27.80m;
            decimal result = factor1 / targetSizeInMilDots;
            return result;
        }
        public decimal FindWindageAdjustment(int windspeed, decimal distance, int windDirection)
        {
            decimal distanceInHundredsOfYards = distance / 100;
            decimal factor1 = windspeed * distanceInHundredsOfYards;
            decimal clicks = factor1 / 10;
            var correctionAmount = this.WindageCorrection(windDirection);
            return clicks * correctionAmount;
        }
        public decimal WindageCorrection(int windDirection)
        {
            List<int> fullCorrections = new List<int> { 10, 9, 8, 2, 3, 4 };
            List<int> halfCorrections = new List<int> { 11, 1, 7, 5 };
            if (fullCorrections.Contains(windDirection))
            {
                return 1m;
            }
            else if (halfCorrections.Contains(windDirection))
            {
                return 0.5m;
            }
            else return 0m;
        }
        public WindDirection GetWindDirection(int windDirection)
        {
            List<int> leftWinds = new List<int> { 11, 10, 9, 8, 7 };
            List<int> rightWinds = new List<int> { 1, 2, 3, 4, 5 };
            if (leftWinds.Contains(windDirection))
            {
                return WindDirection.Right;
            }
            else if (rightWinds.Contains(windDirection))
            {
                return WindDirection.Left;
            }
            else
                return WindDirection.Center;
        }
        public int GetBulletDrop(decimal distance)
        {
            if (distance > 500)
                return 41;
            if (distance > 400)
                return 26;
            if (distance > 300)
                return 15;
            if (distance > 200)
                return 6;
            return 0;
        }
    }
}
