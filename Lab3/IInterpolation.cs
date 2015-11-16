using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab3 {
	internal interface IInterpolation {
		List<DataPoint> InterpolateAll(Data data);
		double Interpolate(double x, Data data);
	}
}