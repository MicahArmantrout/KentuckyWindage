using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;
using KentuckyWindageForms.Extensions;
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
            Commands.Add(nameof(Calculate), new Command(execute: DoCalc, canExecute: IsFormValid));
        }

        public ICommand Calculate => Commands[nameof(Calculate)];
        
        private bool IsFormValid()
        {
            var isValid = _input.IsValid();

            Errors = isValid ? "" : "Inputs should all be non-zero";
            OnPropertyChanged(nameof(Errors));

            return isValid;
        }

        private void DoCalc()
        {
            // Declarations
            var calcService = new WindageCalculator(_input);

            // Perform Calculation
            _adjustments = calcService.Calculate();

            // Fire updates
            OnPropertyChanged(nameof(MoaElevation));
            OnPropertyChanged(nameof(MoaWindage));
        }


        public string Errors { get; set; }
        public bool IsRight
        {
            get => _input.WindDirection == WindDirection.Left;
            set
            {
                _input.WindDirection = value ? WindDirection.Right : WindDirection.Left;
                OnPropertyChanged(nameof(IsRight));
                OnPropertyChanged(nameof(DirectionText));
            }
        }
        public string DirectionText => _input.WindDirection.ToString();

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
                _input.TargetSizeMilDots = value;
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
        public string MoaElevation => _adjustments.MoaElevation > 0 ? $"Elevation should be {_adjustments.MoaElevation}" : "";

        public string MoaWindage => _adjustments.MoaElevation > 0 ? $"Windage should be {_adjustments.MoaWindage}" : "";
    }
}
