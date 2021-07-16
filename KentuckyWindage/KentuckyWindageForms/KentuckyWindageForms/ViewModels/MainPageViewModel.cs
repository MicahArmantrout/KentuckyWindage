using System;
using System.Collections.Generic;
using System.Text;
using KentuckyWindageForms.Models;

namespace KentuckyWindageForms.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly InputModel _input;
        private readonly AdjustmentModel _adjustments;

        public MainPageViewModel()
        {
            /*
                MoaElevation = $"Elevation should be {elevation}",
                MoaWindage = $"Windage should be {windage}"
             */
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

    }
}
