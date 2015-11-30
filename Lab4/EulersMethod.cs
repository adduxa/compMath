using System;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab4 {
	class EulersMethod {
		public DataPoint[] Solve(Func<double, double, double> func, double x0, double y0, double end, int steps) {
			var sectionLength = end - x0;
			var step = sectionLength / (steps - 1);
			DataPoint[] dataPoints = new DataPoint[steps];
			dataPoints[0] = new DataPoint(x0, y0);
			for(var i = 1; i < steps; i++) {
				dataPoints[i] = new DataPoint(x0 + step * i, dataPoints[i - 1].YValues[0] + func.Invoke(dataPoints[i - 1].XValue, dataPoints[i - 1].YValues[0]) * step);
			}
			return dataPoints;
		}
	}
}
