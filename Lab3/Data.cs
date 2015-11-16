using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab3 {
	internal struct Data {
		public const double STEPS = 1000;
		public readonly string Name;
		public readonly Func<double, double> Func;
		public readonly double Start;
		public readonly double End;
		public readonly int Steps;
		public readonly double Step;

		public readonly List<DataPoint> Points;
		public readonly List<DataPoint> SourcePoints;
		public List<DataPoint> InterpolatedPoints {
			get; private set;
		}
		private readonly IInterpolation _interpolation;


		public Data(string name, Data data, IInterpolation interpolation)
			: this(name, data.Func, data.Start, data.End, data.Steps, interpolation) {}

		public Data(string name, Func<double, double> func, double start, double end, int steps, IInterpolation interpolation) {
			Name = name;
			Func = func;
			Start = start;
			End = end;
			Steps = steps;
			Step = (End - Start)/(steps - 1);

			Points = new List<DataPoint>();
			for(var x = Start; x <= End; x += Step) {
				Points.Add(new DataPoint(x, Func.Invoke(x)));
			}

			SourcePoints = new List<DataPoint>();
			for(var x = Start; x < End; x += (end - start)/STEPS) {
				SourcePoints.Add(new DataPoint(x, Func.Invoke(x)));
			}

			_interpolation = interpolation;
			InterpolatedPoints = new List<DataPoint>();
			InterpolatedPoints = _interpolation.InterpolateAll(this);
		}

		public Data Deviate() {
			var random = new Random();
			var randomPointNumber = random.Next(1, Points.Count);
			var ramdomPoint = Points[randomPointNumber - 1];
			ramdomPoint.SetValueY(ramdomPoint.YValues[0] - random.NextDouble()*2 + 1);

			InterpolatedPoints = _interpolation.InterpolateAll(this);
			return this;
		}

		public double Interpolate(double x) {
			return _interpolation.Interpolate(x, this);
		}
		
		public override string ToString() {
			return Name;
		}
	}
}