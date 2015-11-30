using System.Windows.Forms.DataVisualization.Charting;

namespace Lab4 {
	internal class NewtonInterpolation {
		public DataPoint[] InterpolateAll(DataPoint[] points, double start, double end) {
			DataPoint[] interpolatedPoints = new DataPoint[Data.ScreenViewSteps];
			for(var n = 0; n < Data.ScreenViewSteps; n++) {
				var x = start + n*(end - start)/Data.ScreenViewSteps;
				var res = points[0].YValues[0];
				for(var i = 1; i < points.Length; i++) {
					double f = 0;
					for(var j = 0; j <= i; j++) {
						double den = 1;
						for(var k = 0; k <= i; k++) {
							if(k != j) {
								den *= (points[j].XValue - points[k].XValue);
							}
						}
						f += points[j].YValues[0]/den;
					}
					for(var k = 0; k < i; k++) {
						f *= (x - points[k].XValue);
					}
					res += f;
				}
				interpolatedPoints[n] = new DataPoint(x, res);
			}
			return interpolatedPoints;
		}

		public double Interpolate(double x, DataPoint[] points, int steps) {
			var res = points[0].YValues[0];
			for(var i = 1; i < steps; i++) {
				double f = 0;
				for(var j = 0; j <= i; j++) {
					double den = 1;
					for(var k = 0; k <= i; k++) {
						if(k != j) {
							den *= (points[j].XValue - points[k].XValue);
						}
					}
					f += points[j].YValues[0]/den;
				}
				for(var k = 0; k < i; k++) {
					f *= x - points[k].XValue;
				}
				res += f;
			}
			return res;
		}
	}
}