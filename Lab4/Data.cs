using System;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab4 {
	internal class Data {
		public const int ScreenViewSteps = 1000;
		public readonly string Name;

		private readonly Func<double, double, double> _func;
		
		private readonly NewtonInterpolation _interpolation;
		private readonly EulersMethod _em;
		public DataPoint[] SourcePoints;
		public DataPoint[] InterpolatedPoints;

		public Data(string name, Func<double, double, double> func, EulersMethod em, NewtonInterpolation interpolation) {
			Name = name;
			_func = func;
			_em = em;
			_interpolation = interpolation;
		}
		
		public double Interpolate(double x, int steps) {
			return _interpolation.Interpolate(x, SourcePoints, steps);
		}

		public void Solve(double x0, double y0, double end, int steps) {
			SourcePoints = _em.Solve(_func, x0, y0, end, steps);
			InterpolatedPoints = _interpolation.InterpolateAll(SourcePoints, x0, end);
		}
		
		public override string ToString() {
			return Name;
		}

	}
}