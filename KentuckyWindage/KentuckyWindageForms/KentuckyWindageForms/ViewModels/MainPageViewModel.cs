using System;
using System.Collections.Generic;
using System.Text;
using KentuckyWindageForms.Models;
using KentuckyWindageForms.Services;
using Xamarin.Forms;

namespace KentuckyWindageForms.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly InputModel _input = new InputModel();
        private AdjustmentModel _adjustments = new AdjustmentModel();

        public MainPageViewModel()
        {
            Commands.Add("Calculate", new Command(Calculate));
        }

        public void Calculate()
        {
            // Declarations
            var calcService = new WindageCalculator(_input);

            // Perform Calculation
            _adjustments = calcService.Calculate();

            // Fire updates
            OnPropertyChanged(nameof(MoaElevation));
            OnPropertyChanged(nameof(MoaWindage));
        }
        
        public bool IsLeft
        {
            get => _input.WindDirection == WindDirection.Left;
            set
            {
                _input.WindDirection = value ? WindDirection.Left : WindDirection.Right;
                OnPropertyChanged(nameof(IsLeft));
            }
        }
        public decimal TargetSizeInches
        {
            get => _input.TargetSizeInches;
            set
            {
                _input.TargetSizeInches = value;
                OnPropertyChanged(nameof(TargetSizeInches));
            }
        }
        public decimal TargetSizeMilDots
        {
            get => _input.TargetSizeMilDots;
            set
            {
                _input.ElevationInches = value;
                OnPropertyChanged(nameof(TargetSizeMilDots));
            }
        }
        public decimal WindageInches
        {
            get => _input.WindageInches;
            set
            {
                _input.ElevationInches = value;
                OnPropertyChanged(nameof(WindageInches));
            }
        }
        public decimal ElevationInches
        {
            get => _input.ElevationInches;
            set
            {
                _input.ElevationInches = value;
                OnPropertyChanged(nameof(ElevationInches));
            }
        }

        // Results
        public string MoaElevation => $"Elevation should be {_adjustments.MoaElevation}";

        public string MoaWindage => $"Windage should be {_adjustments.MoaWindage}";
    }
}
