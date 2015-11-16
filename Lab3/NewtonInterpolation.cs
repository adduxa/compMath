using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab3 {
	internal class NewtonInterpolation : IInterpolation {
		public List<DataPoint> InterpolateAll(Data data) {
			var interpolatedPoints = new List<DataPoint>();

			for(var x = data.Start; x < data.End; x += (data.End - data.Start)/Data.STEPS) {
				var res = data.Points[0].YValues[0];
				for(var i = 1; i < data.Steps; i++) {
					double f = 0;
					for(var j = 0; j <= i; j++) {
						double den = 1;
						for(var k = 0; k <= i; k++) {
							if(k != j) {
								den *= (data.Points[j].XValue - data.Points[k].XValue);
							}
						}
						f += data.Points[j].YValues[0]/den;
					}
					for(var k = 0; k < i; k++) {
						f *= (x - data.Points[k].XValue);
					}
					res += f;
				}
				interpolatedPoints.Add(new DataPoint(x, res));
			}

			return interpolatedPoints;
		}

		public double Interpolate(double x, Data data) {
			var res = data.Points[0].YValues[0];
			for(var i = 1; i < data.Steps; i++) {
				double f = 0;
				for(var j = 0; j <= i; j++) {
					double den = 1;
					for(var k = 0; k <= i; k++) {
						if(k != j) {
							den *= (data.Points[j].XValue - data.Points[k].XValue);
						}
					}
					f += data.Points[j].YValues[0]/den;
				}
				for(var k = 0; k < i; k++) {
					f *= x - data.Points[k].XValue;
				}
				res += f;
			}
			return res;
		}
	}
}